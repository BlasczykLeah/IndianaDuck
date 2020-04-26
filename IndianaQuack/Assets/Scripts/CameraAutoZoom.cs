using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoZoom : MonoBehaviour
{
    public Transform defaultCameraSpot;
    public Transform duckMidSpot;

    public float moveSpeed;
    public bool isColliding;

    public bool zoomingIn = false;
    public bool zoomingOut = false;

    float waitingTime = 0.5F;

    // Start is called before the first frame update
    void Awake()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), transform.GetChild(0).GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomingIn)
        {
            waitingTime = 0.5F;

            if (zoomingOut)
            {
                zoomingIn = false;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, duckMidSpot.position, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, duckMidSpot.position) < 0.001F)
                {
                    zoomingIn = false;
                }
            }
        }

        if (zoomingOut)
        {
            if (zoomingIn)
            {
                zoomingOut = false;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, defaultCameraSpot.position, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, defaultCameraSpot.position) < 0.001F)
                {
                    zoomingOut = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Enemy") && !other.CompareTag("Player"))
        {
            isColliding = true;
            zoomingIn = true;
            if (zoomingOut) zoomingOut = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Enemy") && !other.CompareTag("Player"))
        {
            isColliding = false;
            zoomingIn = false;
        }
    }
}
