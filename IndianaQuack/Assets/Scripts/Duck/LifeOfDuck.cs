using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeOfDuck : MonoBehaviour
{
    public Transform spawnPoint;
    Vector3 spawn;
    public GameObject blackScreen;
    public bool dying = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Deetth") || collision.gameObject.CompareTag("Enemy"))
        {
            if (!dying)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<DuckMove>().enabled = false;
                GetComponent<DuckJump>().enabled = false;
                GetComponent<Animator>().SetBool("Run", false);
                GetComponent<Animator>().SetBool("Fly", false);

                dying = true;
                blackScreen.SetActive(true);
            }
        }
    }

    public void MoveToSpawn()
    {
        transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
    }

    public void EnableControls()
    {
        GetComponent<DuckJump>().enabled = true;
        GetComponent<DuckMove>().enabled = true;
        dying = false;
        blackScreen.SetActive(false);
    }
}
