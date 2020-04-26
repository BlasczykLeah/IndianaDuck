using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class NewSpawnpoint : MonoBehaviour
{
    public bool activated = false;
    public Transform mySpawnpoint;
    AudioManager AM;
    public Button myButton;

    private void Start()
    {
        AM = AudioManager.instance;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && !activated)
        {
            AM.StopTime();
            if(myButton != null) myButton.mySound = false;
            collision.gameObject.GetComponent<LifeOfDuck>().spawnPoint = mySpawnpoint;
            activated = true;
        }
    }
}
