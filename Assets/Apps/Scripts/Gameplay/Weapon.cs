using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponDataScriptable weaponData;
    [SerializeField] private float cooldown;


    private void Awake()
    {
        cooldown = 0;
    }

    private void Update()
    {
        if (!IsOnCooldown()) return;

        cooldown -= Time.deltaTime;
        if (cooldown < 0) cooldown = 0;
    }

    public void Shoot()
    {
        if (IsOnCooldown()) return;

        CreateProjectile();
        AddCooldown();
    }

    private void AddCooldown()
    {
        cooldown = 1f / weaponData.fireRate;
    }

    private void CreateProjectile()
    {
        Instantiate(weaponData.projectilePrefab, transform.position, transform.rotation);
    }

    private bool IsOnCooldown() => cooldown > 0;
}