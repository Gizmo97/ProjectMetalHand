using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject osuma;
    public GameObject osuma2;
    public float range = 300f;
    public float speed = 10f;
    public int Damage = 100;
    public float radius = 15f;
    public float force = 700f;
    public float duration = 10f;

    void Start()
    {
        rb.velocity = transform.forward * speed;
        rb.AddForce(0, range, 0);
        transform.rotation = Random.rotation;
    }

    void OnTriggerEnter(Collider hit)
    {
        rb.useGravity = false;
        rb.velocity = new Vector3(0f, 0f, 0f);
        gameObject.GetComponent<SphereCollider>().enabled = false;
        StartCoroutine(Suck());
    }

    public IEnumerator Suck()
    {
        GameObject impact2 = Instantiate(osuma2, transform.position, transform.rotation);
        while (duration > 0)
        {
            GameObject impact = Instantiate(osuma, transform.position, transform.rotation);

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
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(force, transform.position, radius);
                }
            }

            Destroy(impact, 1f);

            yield return new WaitForSeconds(0.1f);
            duration -= 0.1f;
        }
        if (duration <= 0f)
        {
            Destroy(impact2);
            Destroy(gameObject);
        }
    }
}
