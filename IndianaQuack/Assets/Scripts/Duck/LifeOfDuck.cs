using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeOfDuck : MonoBehaviour
{
    public Vector3 spawn;
    public GameObject blackScreen;
    public bool dying = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
