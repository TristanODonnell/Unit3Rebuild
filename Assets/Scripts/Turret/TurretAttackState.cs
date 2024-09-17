using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackState : TurretState
{
    private Transform target;
    private HealthModule targetHealthModule;

    public TurretAttackState(TurretController turret, Transform target) : base(turret) 
    
    {
        this.target = target;
    }

    

    public override void OnStateEnter()
    {
        targetHealthModule = target.GetComponent<HealthModule>();
    }

    public override void OnStateExit() 
    {
        //turretController.DisableLaser();
    }

    public override void OnStateRun()
    {
        
        
        if (targetHealthModule != null)
        {
            turretController.ShootLaser(target);
        }
      else
        {  
           turretController.SwitchState(new TurretIdleState(turretController));
       }
        
    } 
}
  