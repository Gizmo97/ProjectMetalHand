using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructive : MonoBehaviour
{
    public GameObject destVersion;
    public GameObject inside;
    public int hp = 1;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject dest = Instantiate(destVersion, transform.position, transform.rotation);
        for (int i = 5; i > 0; i--)
        {
            GameObject money = Instantiate(inside, transform.position, transform.rotation);
            Destroy(money, 90f);
        }
        Destroy(gameObject);
        Destroy(dest, 3f);
    }
}
