using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscript : MonoBehaviour
{
    public Transform firePoint;
    public LineRenderer line;
    public GameObject shoot;
    public GameObject osuma;
    public float range = 100f;
    public float fireRate = 5f;
    public int damage = (int)100f;
    public float force = 700f;
    public float radius = 1f;

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            if (enemy == null)
                {
                GameObject impact = Instantiate(osuma, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 2.5f);
                }
            destructive dest = hit.transform.GetComponent<destructive>();
            if (dest != null)
            {
                dest.TakeDamage(damage);
            }
            Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, hit.transform.position, radius);
            }
            line.SetPosition(0, firePoint.transform.position);
            line.SetPosition(1, hit.point);
        }else
        {
            line.SetPosition(0, firePoint.transform.position);
            line.SetPosition(1, firePoint.position + firePoint.forward * range);
        }
        line.enabled = true;

        yield return new WaitForSeconds(10f * Time.deltaTime);

        line.enabled = false;
    }
}
