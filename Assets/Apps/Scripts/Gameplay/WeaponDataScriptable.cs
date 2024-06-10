using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Scriptable Object/Weapon Data" )]
public class WeaponDataScriptable : ScriptableObject
{
    public GameObject projectilePrefab;
    public int fireRate; //number of projectile per second
}