using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public new string name;
    public string subName;
    public string description;
    public int currentXp;
    public int xpToLevel2;
    public int xpToLevel3;
    public int xpToLevel4;
    public int xpToLevel5;
    public int level;
    public ShotType shotType;
    [SerializeField]
    public GameObject ammo;
    public int damage;
    public float fireRate;
    public float range;
    public int maxAmmo;
    public int currentAmmo;
    public Sprite picture;

    public enum ShotType
    {
        Auto,
        single
    }
}
