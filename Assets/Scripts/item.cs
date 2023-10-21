using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public int amount = 1;
    public BoxCollider boxcollider;
    public Rigidbody rb;

    public void Update()
    {
        Collider[] follow = Physics.OverlapSphere(transform.position, 6f);

        foreach (Collider nearbyObject in follow)
        {
            PlayerMove player = nearbyObject.GetComponent<PlayerMove>();
            if (player != null)
            {
                boxcollider.enabled = false;
                rb.useGravity = false;
                Vector3 a = transform.position;
                Vector3 b = player.transform.position;
                transform.position = Vector3.Lerp(a, b, 0.1f);
            }
            else
            {
                boxcollider.enabled = true;
                rb.useGravity = true;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        PlayerMove player = other.GetComponent<PlayerMove>();
        if(player != null)
        {
            Destroy(gameObject);
            player.GetMoney(amount);
        }
    }
}