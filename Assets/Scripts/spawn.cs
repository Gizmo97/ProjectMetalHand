using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject spawned;
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;
    public GameObject spawnPoint4;
    public GameObject spawnPoint5;
    public GameObject spawnPoint6;
    public GameObject spawnPoint7;
    public GameObject spawnPoint8;
    public GameObject spawnPoint9;
    void OnTriggerEnter (Collider hit)
    {
        Instantiate(spawned, spawnPoint1.transform.position, spawnPoint1.transform.rotation);
        Instantiate(spawned, spawnPoint2.transform.position, spawnPoint2.transform.rotation);
        Instantiate(spawned, spawnPoint3.transform.position, spawnPoint3.transform.rotation);
        Instantiate(spawned, spawnPoint4.transform.position, spawnPoint4.transform.rotation);
        Instantiate(spawned, spawnPoint5.transform.position, spawnPoint5.transform.rotation);
        Instantiate(spawned, spawnPoint6.transform.position, spawnPoint6.transform.rotation);
        Instantiate(spawned, spawnPoint7.transform.position, spawnPoint7.transform.rotation);
        Instantiate(spawned, spawnPoint8.transform.position, spawnPoint8.transform.rotation);
        Instantiate(spawned, spawnPoint9.transform.position, spawnPoint9.transform.rotation);
    }
}
