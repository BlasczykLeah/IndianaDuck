using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float xAxiz = 0, yAxiz = 0;
    public float power = 1;

    void Start()
    {
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        float rotVert = -Input.GetAxis("Mouse Y");
        yAxiz += rotVert;

        if(yAxiz > -12 && yAxiz < 12)
        {
            transform.RotateAround(transform.position, transform.right, rotVert * power);
        }
        else
        {
            if (yAxiz < -12)
                yAxiz = -12;
            if (yAxiz > 12)
                yAxiz = 12;
        }

        float rotHor = -Input.GetAxis("Mouse X");
        transform.RotateAround(transform.position, -Vector3.up, rotHor * power);
    }
}
