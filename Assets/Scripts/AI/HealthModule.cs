using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class HealthModule : MonoBehaviour
{
    private SpawnSystem spawnSystem;
    private Pickable pickable;

    public int maxHealthPoints;
    public int healthPoints;
    public bool isDead;

    public UnityEvent<int> OnHealthChanged;
    public Action<int> OnCSharpHealthChanged;

    void Start()
    {
        healthPoints = maxHealthPoints;
    }
    void Update()
    {

    }
    public void Damage(int damageCaused)
    {
        healthPoints -= damageCaused;
        OnHealthChanged.Invoke(healthPoints);
        //OnCSharpHealthChanged?.Invoke(healthPoints);
        if (healthPoints <= 0 && !isDead)
        {
            Die();
        }
    }
    private void Die()
    {
        isDead = true;
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
             GameManager.Singleton.FailedLevel();
        }
        else if (gameObject.layer == LayerMask.NameToLayer("Interactables"))
        {
             GameManager.Singleton.FailedLevel();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
