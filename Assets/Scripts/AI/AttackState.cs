using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AIState
{

    private float damageCooldownTimer;
    
    private Transform target;
    private HealthModule targetHealthModule;


    public override void OnStateEnter()
    {
        targetHealthModule = target.GetComponent<HealthModule>();
    }

    public override void OnStateExit()
    {
       
    }

    public override void OnStateRun()
    {
        if (damageCooldownTimer >= 0)
        {
            //cooldown activated
            damageCooldownTimer -=Time.deltaTime;
        }

        else
        { 
            damageCooldownTimer = 3f;
         if(targetHealthModule != null)

         {
            targetHealthModule.Damage(5);
         }
            //reset timer;
           
        }
       

        

        if(Vector3.Distance(target.position, controller.transform.position) >= 2f)
        {
            controller.ChangeState(new ChaseState(target, controller));
        }
        //IF WE ARE FAR FROM PLAYER
        //GO BACK TO CHASESTATE

    }

    public AttackState(Transform newTarget, AIController aicontroller) : base(aicontroller)
    {
        target = newTarget;
    }
}
