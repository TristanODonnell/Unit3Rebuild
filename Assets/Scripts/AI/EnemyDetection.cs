using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private AIController controller;
    private void OnTriggerEnter(Collider other)
    {
        
        controller.ChangeState(new ChaseState(other.transform, controller));
        Debug.Log(other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        controller.ChangeState(new PatrolState(controller));
    }
}
