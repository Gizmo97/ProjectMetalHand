using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HLB_code : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject osuma;
    public GameObject osuma2;
    public float range = 300f;
    public float speed = 10f;
    public int Damage = 100;
    public float radius = 10f;
    public float force = 700f;

    void Start()
    {
        rb.velocity = transform.forward * speed;
        rb.AddForce(0, range, 0);
        transform.rotation = Random.rotation;
    }

    void OnTriggerEnter (Collider hit)
    {
        GameObject impact = Instantiate(osuma, transform.position, transform.rotation);
        GameObject impact2 = Instantiate(osuma2, transform.position, transform.rotation);

        Collider[] collidersToDestoyr = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToDestoyr)
        {
            Enemy enemy = nearbyObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
            }
            destructive dest = nearbyObject.GetComponent<destructive>();
            if (dest != null)
            {
                dest.TakeDamage(Damage);
            }
            
            
        }
        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb1 = nearbyObject.GetComponent<Rigidbody>();
            if (rb1 != null)
            {
                rb1.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject);
        Destroy(impact, 0.5f);
        Destroy(impact2, 0.5f);
    }
}
