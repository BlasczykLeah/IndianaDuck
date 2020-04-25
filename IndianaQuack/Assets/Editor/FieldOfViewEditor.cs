using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyPatrol))]
public class FieldOfViewEditor : Editor
{
    void OnSceneGUI()
    {
        EnemyPatrol enemy = (EnemyPatrol)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(enemy.transform.position, Vector3.up, Vector3.forward, 360, enemy.visionRadius);

        Vector3 viewA = enemy.AngleDirection(-enemy.visionAngle / 2, false);
        Vector3 viewB = enemy.AngleDirection(enemy.visionAngle / 2, false);

        Handles.DrawLine(enemy.transform.position, enemy.transform.position + viewA * enemy.visionRadius);
        Handles.DrawLine(enemy.transform.position, enemy.transform.position + viewB * enemy.visionRadius);
    }
}
