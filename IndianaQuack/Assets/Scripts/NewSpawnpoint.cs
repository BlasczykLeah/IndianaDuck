using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class NewSpawnpoint : MonoBehaviour
{
    public bool activated = false;
    public Transform mySpawnpoint;
    AudioManager AM;

    private void Start()
    {
        AM = AudioManager.instance;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && !activated)
        {
            AM.StopTime();
            collision.gameObject.GetComponent<LifeOfDuck>().spawnPoint = mySpawnpoint;
            activated = true;
        }
    }
}
