using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBetweenCollision : MonoBehaviour
{
    public bool hittingCamera;
    public CameraAutoZoom c;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("MainCamera") && !hittingCamera)
        {
            c.zoomingIn = true;
        }
    }
}
