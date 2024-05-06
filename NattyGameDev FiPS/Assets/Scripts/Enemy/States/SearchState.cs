using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState
{
    private float SearchTimer; //How long has the enemy been searching
    private float MaxSearchTimer = 10f; //How long the enemy will continue to search

    private float MoveTimer;
    private float MaxMoveTimer;

    public override void Enter()
    {
        enemy.Agent.SetDestination(enemy._PlayerLastKnownPos);    
    }
    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            _StateMachine.ChangeState(new AttackState());
        }

        if(enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance)
        {
            SearchTimer += Time.deltaTime;
            MoveTimer += Time.deltaTime;
            if (SearchTimer > MaxSearchTimer)
            {
                _StateMachine.ChangeState(new PatrolState());
            }
            if(MoveTimer > Random.Range(2, 5))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere) * 10);
                MoveTimer = 0;
            }

        }
    }

    public override void Exit()
    {
        
    }

}
