using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public bool won = false;
    public GameObject black;
    public GameObject duck;

    private void OnTriggerEnter(Collider other)
    {
        if (!won)
        {
            black.SetActive(true);
            won = true;
            duck.GetComponent<DuckMove>().enabled = false;
        }
    }
}
