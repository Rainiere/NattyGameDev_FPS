using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int WaypointIndex;
    public override void Enter()
    {

    }

    public override void Perform()
    {
        PatrolCycle();
    }

    public override void Exit() 
    {
    
    }  
  
    public void PatrolCycle()
    {
        //Implement patrol logic
        if(enemy.Agent.remainingDistance < 0.2f)
        {
            if(WaypointIndex < enemy.path.waypoints.Count - 1)
            {
                WaypointIndex++;
            } else
            {
                WaypointIndex = 0;
            }
            enemy.Agent.SetDestination(enemy.path.waypoints[WaypointIndex].position);
        }
    }
}
