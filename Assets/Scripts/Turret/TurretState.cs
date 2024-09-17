using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretState
{
    protected TurretController turretController;
    public abstract void OnStateEnter();
    public abstract void OnStateRun();
    public abstract void OnStateExit();
    public TurretState(TurretController turretController)
    {
        this.turretController = turretController;
    }
    // Start is called before the first frame update
}
