using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TurretController : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float radius;
    public float laserDistance = 50f;
    public LineRenderer lineRenderer;
    public LayerMask layerMask;
    public Transform shootPoint;
    private Transform currentTarget;

    private TurretState currentState;
    private TurretIdleState idleState;
    private TurretAttackState attackState;
    private void Start()
    {
        idleState = new TurretIdleState(this);
        currentState = idleState;
        currentState.OnStateEnter();

        lineRenderer.enabled = true;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, shootPoint.position);
        lineRenderer.SetPosition(1, shootPoint.position + shootPoint.forward * laserDistance);
    }
    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnStateRun();
        }
    }
    public void SwitchState(TurretState newState)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = newState;
        currentState.OnStateEnter();
        Debug.Log($"Switching from {currentState.GetType().Name} to {newState.GetType().Name}");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player inside trigger");
            SetTarget(other.transform);
        }
    }
    public void SetTarget(Transform target)
    {
        currentTarget = target;
        SwitchState(new TurretAttackState(this, currentTarget));
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("left trigger");
        SwitchState(idleState); //switch back to idle state 
    }
    public void ShootLaser(Transform currentTarget)
    {
        RaycastHit hit;
        RaycastHit hit2;
        float distance = laserDistance;

        if (Physics.SphereCast(shootPoint.position, radius, transform.forward, out hit, distance, layerMask))
        {
            lineRenderer.SetPosition(0, shootPoint.position);
            lineRenderer.SetPosition(1, hit.point);
            if (Physics.Raycast(shootPoint.position, hit.transform.position - shootPoint.position, out hit2, Mathf.Infinity))  //lab help 
            {
                Debug.Log("Did Hit" + hit2.collider.name);
                lineRenderer.SetPosition(0, shootPoint.position);
                lineRenderer.SetPosition(1, hit2.point);
                if (hit2.transform == currentTarget)
                {
                    HealthModule targetHealthModule = currentTarget.GetComponent<HealthModule>();
                    if (targetHealthModule != null)
                    {
                        targetHealthModule.Damage(5);
                    }
                }
            }
        }
        else
        {
            lineRenderer.SetPosition(0, shootPoint.position);
            lineRenderer.SetPosition(1, shootPoint.position + shootPoint.forward * laserDistance);
        }
    }
    public void DisableLaser()
    {
        lineRenderer.enabled = false;
    }
    public void EnableLaser()
    {
        lineRenderer.enabled = true;
    }
}
