using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretIdleState : TurretState
{
    public TurretIdleState(TurretController turretController) : base(turretController) { }

    public override void OnStateEnter()
    {
        turretController.EnableLaser();
    }
    public override void OnStateExit()
    {

    }
    public override void OnStateRun()
    {

    }
}
