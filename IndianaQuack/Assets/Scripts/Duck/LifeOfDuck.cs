using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeOfDuck : MonoBehaviour
{
    public Transform spawnPoint;
    Vector3 spawn;
    public GameObject blackScreen;
    public bool dying = false;

    void Start()
    {
        if (spawnPoint == null) spawn = Vector3.zero;
        else UpdateSpawn(spawnPoint);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!dying)
        {
            if (collision.gameObject.CompareTag("Deetth") || collision.gameObject.CompareTag("Enemy"))
            {
                GetComponent<DuckMove>().enabled = false;
                dying = true;
                blackScreen.SetActive(true);
            }
        }
    }

    public void MoveToSpawn()
    {
        transform.position = spawn;
    }

    public void EnableControls()
    {
        GetComponent<DuckMove>().enabled = true;
        dying = false;
    }

    public void UpdateSpawn(Transform t)
    {
        spawn = new Vector3(t.position.x, t.position.y, t.position.z);
    }
}
