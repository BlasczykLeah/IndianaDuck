using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    //public bool revert;
    //public bool used;

    public bool won = false;
    public GameObject black;
    public GameObject duck;

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !used)
        {
            used = true;
            GameObject temp = other.transform.Find("Camera Holder").gameObject;

            if (revert)
            {
                temp.transform.position = Vector3.zero;
                temp.transform.Rotate(Vector3.zero);
            }
            else
            {
                temp.transform.position = new Vector3(0, 0, -0.15F);
                temp.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }*/

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
