using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class NewSpawnpoint : MonoBehaviour
{
    public bool activated = false;
    public Vector3 mySpawnpoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<LifeOfDuck>().spawn = mySpawnpoint;
            this.enabled = false;
        }
    }
}
