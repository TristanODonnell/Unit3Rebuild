using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon Data")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private string weaponName;
    [SerializeField] private float damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject weaponModel;

    public string WeaponName => weaponName;
    public float GetFireRate() => fireRate;
    public float GetBulletSpeed() => bulletSpeed;
    public float GetDamage() => damage;

    public GameObject GetWeaponModel() => weaponModel;  
}
