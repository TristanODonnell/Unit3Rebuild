using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehavior : MonoBehaviour
{
    [SerializeField] private ObjectPool bulletsPool;
    [SerializeField] private List<WeaponData> inventory = new List<WeaponData>();
    [SerializeField] private WeaponData equippedWeapon;


    [Header("Shooting Settings")]
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private Transform weaponTip;
    [SerializeField] private GameObject currentWeaponModel;

    [SerializeField] private Camera myCamera;

    private void Start()
    {
        ChangeWeapon(0);
    }


    public void ShootWeapon()
       
    {
        PooledObject pooledObj = bulletsPool.RetrievePoolObject();
        Rigidbody projectileClone = pooledObj.GetRigidbody();
        projectileClone.position = weaponTip.position;
         projectileClone.rotation = weaponTip.rotation;
         projectileClone.AddForce(myCamera.transform.forward * equippedWeapon.GetBulletSpeed(), ForceMode.Impulse);

        
        // set damage on a possible bullet script 

        Bullet bulletScript = projectileClone.GetComponent<Bullet>();
        if(bulletScript != null )
        {
            bulletScript.Initialize(equippedWeapon);
        }

        //start cooldown here with a timer maybe, from the fire rate in the equipped weapon 

        pooledObj.ResetPooledObject(4F);
    }

    public void ChangeWeapon(int index)
    {
        index = Mathf.Clamp(index, 0, inventory.Count - 1);
        equippedWeapon = inventory[index];
        Debug.Log("my weapon is now" + equippedWeapon.WeaponName);


        if (currentWeaponModel != null)
        {
            Destroy(currentWeaponModel);
        }

        currentWeaponModel = Instantiate(equippedWeapon.GetWeaponModel(), weaponTip.position, weaponTip.rotation, weaponTip);

        currentWeaponModel.transform.localPosition = Vector3.zero;
        currentWeaponModel.transform.localRotation = Quaternion.identity;
        currentWeaponModel.transform.localScale = Vector3.one;

        currentWeaponModel.transform.localRotation = Quaternion.Euler(0, 180, 0);

    }
}
