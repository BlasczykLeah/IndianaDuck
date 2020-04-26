using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public LifeOfDuck lod;

    public void Step1()
    {
        lod.MoveToSpawn();
    }
    public void Step2()
    {
        lod.EnableControls();
        //gameObject.SetActive(false);
    }
}
