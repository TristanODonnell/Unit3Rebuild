using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatrolState : AIState
{
    private int waypointIndex;
    private float distanceToStop;
    public override void OnStateEnter()
    {
        controller.GetAgent().SetDestination(controller.GetWaypoint(waypointIndex).position);
    }

    public override void OnStateExit()
    {
    
    }

    public override void OnStateRun()
    {
        if (controller.GetAgent().remainingDistance < distanceToStop)
        {
            waypointIndex++;
            if (waypointIndex >= controller.TotalAmountOfWayPoints())
            {
                waypointIndex = 0;
            }
            controller.GetAgent().SetDestination(controller.GetWaypoint(waypointIndex).position);
        }
    }


    public PatrolState(AIController con) : base(con)
    {
        controller = con;
        distanceToStop = 2f;
    }
}
