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

    BehindCamera bc;
    public InBetweenCollision ibc;

    // Start is called before the first frame update
    void Awake()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), transform.GetChild(0).GetComponent<Collider>());
        Physics.IgnoreCollision(transform.GetChild(0).GetComponent<Collider>(), ibc.GetComponent<Collider>());
        bc = transform.GetChild(0).GetComponent<BehindCamera>();
        
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
            if (other == ibc.GetComponent<Collider>())
            {
                ibc.hittingCamera = true;
            }
            else
            {
                bc.canCheckStay = false;

                isColliding = true;
                zoomingIn = true;
                if (zoomingOut) zoomingOut = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Enemy") && !other.CompareTag("Player"))
        {
            if (other == ibc.GetComponent<Collider>())
            {
                ibc.hittingCamera = false;
            }
            else
            {
                bc.canCheckStay = true;

                isColliding = false;
                zoomingIn = false;
            }
        }
    }
}
