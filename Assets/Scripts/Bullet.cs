using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private WeaponData weaponData;

    public void Initialize(WeaponData data)
    {
        weaponData = data;
    }

    private void OnCollisionEnter(Collision collision)
    {
        HealthModule healthModule = collision.gameObject.GetComponent<HealthModule>();
        if (healthModule != null )
        {
          healthModule.Damage((int)weaponData.GetDamage());
           
        }    
    }
}
