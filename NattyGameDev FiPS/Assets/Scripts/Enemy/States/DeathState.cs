using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : BaseState
{
    private float DestroyTimer = 0;
    private Quaternion CurrentRotation;// = enemy.transform.rotation;
    private Quaternion EndRotation;

    public override void Enter()
    {

        CurrentRotation = enemy.gameObject.transform.rotation;
        EndRotation = new Quaternion(90, 90, 90, 90);
        enemy.Agent.SetDestination(enemy.gameObject.transform.position);
        Debug.Log(enemy.gameObject);
        enemy.gameObject.transform.rotation = Quaternion.Lerp(CurrentRotation, EndRotation, 0.5f);
    }

    public override void Exit()
    {

    }

    public override void Perform()
    {
        DestroyTimer += Time.deltaTime;
        if (DestroyTimer >= 5)
        {
           Object.Destroy(enemy.gameObject);
        }
    }
}
