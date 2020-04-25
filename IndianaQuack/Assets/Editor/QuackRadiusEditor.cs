using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(QuackOfCourage))]
public class QuackRadiusEditor : Editor
{
    void OnSceneGUI()
    {
        QuackOfCourage quack = (QuackOfCourage)target;
        Handles.color = Color.yellow;
        Handles.DrawWireArc(quack.transform.position, Vector3.up, Vector3.forward, 360, quack.quackRadius);
    }
}