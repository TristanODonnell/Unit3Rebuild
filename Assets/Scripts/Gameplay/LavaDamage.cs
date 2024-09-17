using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LavaDamage : MonoBehaviour
{
    [SerializeField] private LayerMask lavaLayer;
    [SerializeField] private int damageAmount;
    [SerializeField] private float damageInterval = 1.0f;
    private float damageTimer = 0.0f;
    private HealthModule healthModule;
    private void Start()
    {
        PlayerInput player = FindObjectOfType<PlayerInput>();
        healthModule = player.GetComponent<HealthModule>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (((1 << other.gameObject.layer) & lavaLayer) != 0)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                if (healthModule != null)
                {
                    healthModule.Damage(damageAmount);
                }
                damageTimer = 0.0f;
            }
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
