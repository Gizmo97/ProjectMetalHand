using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eternal_Abyss : MonoBehaviour
{
    public GameObject respawner;

    void OnTriggerEnter(Collider other)
    {
        other.transform.position = respawner.transform.position;
    }
}
