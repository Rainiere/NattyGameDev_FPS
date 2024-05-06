using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float MoveTimer;   //Timer to make the enemy move slightly, to add variation, make them more difficult to hit, etc.
    private float LosePlayerTimer; //Timer to determine whether the enemy needs to go to the Searching state
    private float ShotTimer;
    private float TimeUntillPlayerIsLost = 7f;

    public override void Enter()
    {

    }
    public override void Perform() 
    {
        if (enemy.CanSeePlayer())
        {
            LosePlayerTimer = 0;
            MoveTimer += Time.deltaTime;
            ShotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            enemy.transform.eulerAngles = new Vector3(0, enemy.transform.eulerAngles.y, 0);
            enemy.GunModel.transform.LookAt(enemy.Player.transform);
            if (MoveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                MoveTimer = 0;
            }
            if (ShotTimer >= enemy.FireRate)
            {
                Shoot(); 
            }
            enemy._PlayerLastKnownPos = enemy.Player.transform.position;
        }
        else
        {
            enemy.GunModel.transform.rotation = new Quaternion(0, 0, 0, 0);
            LosePlayerTimer += Time.deltaTime;
            if (LosePlayerTimer > TimeUntillPlayerIsLost)
            {
                //Change to the Search state
                Debug.Log("Switchu!");
                _StateMachine.ChangeState(new SearchState());
                LosePlayerTimer = 0;
            }
        }
    }

    public override void Exit()
    {

    }

    public void Shoot()
    {
        Transform GunBarrel = enemy.GunBarrel;
        GameObject Bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, GunBarrel.position, enemy.transform.rotation);
        Vector3 ShootDirection = (enemy.Player.transform.position - GunBarrel.transform.position).normalized;
        Bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f,3f),Vector3.up) * ShootDirection * 40;
        Debug.Log("Pew!");
        ShotTimer = 0;
    }

}
