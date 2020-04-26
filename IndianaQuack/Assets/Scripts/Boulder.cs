using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    public Collider[] playerColliders;
    public Collider ignoreThis;



    void Start()
    {
        foreach(Collider c in playerColliders) Physics.IgnoreCollision(c, ignoreThis);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetBold()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoulderStop"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
