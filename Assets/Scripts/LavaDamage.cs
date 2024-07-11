using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LavaDamage : MonoBehaviour
{
    [SerializeField] private LayerMask lavaLayer;
    [SerializeField] private int damageAmount;
    [SerializeField] private float damageInterval = 1.0f;
    private float damageTimer = 0.0f;

    private void OnTriggerStay(Collider other)
    {

        Debug.Log("OnTriggerStay called with: " + other.name);
        if (((1 << other.gameObject.layer) & lavaLayer) != 0)
            {
            Debug.Log(other.name + " is in the lava layer");

            damageTimer += Time.deltaTime;
           // Debug.Log("Damage timer: " + damageTimer + "/" + damageInterval);
            if (damageTimer >= damageInterval)
                {
                    HealthModule healthModule = other.GetComponent<HealthModule>();
                    if(healthModule != null )
                    {
                    Debug.Log("Applying damage to " + other.name);
                    healthModule.Damage(damageAmount);
                    }
                    else
                     {
                    Debug.Log("HealthModule not found on: " + other.name);
                     }
                damageTimer = 0.0f;
                }
            }
        else
        {
            Debug.Log(other.name + " is not in the lava layer");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit called with: " + other.name);
        if (((1 << other.gameObject.layer) & lavaLayer) != 0)
        {
            damageTimer = 0.0f; 
        }
    }
}
