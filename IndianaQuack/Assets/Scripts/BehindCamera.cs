using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindCamera : MonoBehaviour
{
    CameraAutoZoom zoom;
    public bool canCheckStay;

    private void Awake()
    {
        zoom = transform.parent.GetComponent<CameraAutoZoom>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Enemy") && !other.CompareTag("Player"))
        {
            zoom.zoomingOut = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy") && !other.CompareTag("Player") && canCheckStay)
        {
            zoom.zoomingOut = zoom.zoomingIn = false;
        }
    }
}
