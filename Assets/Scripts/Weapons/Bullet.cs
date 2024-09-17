using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool isReturning = false;
    private WeaponData weaponData;

    public void Initialize(WeaponData data)
    {
        weaponData = data;
    }
    private void OnCollisionEnter(Collision collision)
    {
        HealthModule healthModule = collision.gameObject.GetComponent<HealthModule>();
        if (healthModule != null)
        {
            healthModule.Damage((int)weaponData.GetDamage());
        }
    }
    public void ResetBullet() // Reset the bullet's state
    {
        isReturning = false;
        // Reset any bullet-specific logic or state here (e.g., velocity, position, etc.)
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        // Add other properties to reset, if needed
    }
}
