using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChase : MonoBehaviour
{
    //public bool revert;
    //public bool used;

    bool won = false;
        public GameObject black;

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
        if (other.CompareTag("Player") && !won)
        {
            black.SetActive(true);
            won = true;
        }
    }
}
