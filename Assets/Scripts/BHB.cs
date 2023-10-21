using System.Collections;
using UnityEngine;

public class BHB : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
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
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(10f * Time.deltaTime);
    }
}
