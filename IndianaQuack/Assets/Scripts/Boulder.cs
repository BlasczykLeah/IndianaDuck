using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    public Collider[] playerColliders;
    public Collider ignoreThis;
    public Button myButton;

    Vector3 startingPoint;

    void Start()
    {
        foreach(Collider c in playerColliders) Physics.IgnoreCollision(c, ignoreThis);
        startingPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rollBoulder()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public void resetBold()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = startingPoint;
        myButton.boulder = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoulderStop"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
