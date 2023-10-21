using System.Collections;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField]
    protected Weapon weapon;
    [SerializeField]
    public Transform firePoint;
    public float fireRate = 1f;
    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot ()
    {
        Instantiate(weapon.ammo, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(10f * Time.deltaTime);
    }
}
