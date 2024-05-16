using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : BaseState
{
    private float DestroyTimer = 0;
    //private Quaternion CurrentRotation;// = enemy.transform.rotation;
    //private Quaternion EndRotation;
    //private float RotationTimer = 0;
    
    private Animator _Animator;

    public override void Enter()
    {

        //CurrentRotation = enemy.gameObject.transform.rotation;
        //EndRotation = new Quaternion(45, enemy.gameObject.transform.rotation.y, enemy.gameObject.transform.rotation.z, enemy.gameObject.transform.rotation.w);
        enemy.Agent.SetDestination(enemy.gameObject.transform.position);
        _Animator = enemy.gameObject.GetComponent<Animator>();
        _Animator.enabled = true;
        _Animator.SetBool("IsDead", true);
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
