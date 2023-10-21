using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LevelSystem LS;
    public int hp = 100;
    public int XP = 10;
    // Start is called before the first frame update
    public void TakeDamage (int Damage)
    {
        hp -= Damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
        LS.AddXP(XP);
    }
}