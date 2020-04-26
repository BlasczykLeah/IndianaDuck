using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class NewSpawnpoint : MonoBehaviour
{
    public bool activated = false;
    public Transform mySpawnpoint;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && !activated)
        {
            collision.gameObject.GetComponent<LifeOfDuck>().spawnPoint = mySpawnpoint;
            activated = true;
        }
    }
}
