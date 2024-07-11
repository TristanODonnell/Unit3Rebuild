using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : AIState
{
    private Transform target;
    public override void OnStateEnter()
    {
      
    }

    public override void OnStateExit()
    {

    }

    public override void OnStateRun()
    {
        controller.GetAgent().SetDestination(target.position);
        if (controller.GetAgent().remainingDistance < 2f)
        {
            controller.ChangeState(new AttackState(target, controller));
        }
    }

    public ChaseState(Transform newTarget, AIController con) : base(con)
    {
        controller = con;
        target = newTarget;
    }
}
