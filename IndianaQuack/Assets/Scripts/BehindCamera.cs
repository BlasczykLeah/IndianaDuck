using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindCamera : MonoBehaviour
{
    CameraAutoZoom zoom;

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
}
