using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Properties")]
    public Vector3[] movementCorners;    // points of movement
    public Vector3 playerLocation;
    public int currentPoint;
    public bool movementLoops;      // if movement loops, go from last point -> first point, else go from last point -> second last point (reverse order)
    bool reverse;
    bool isMoving;

    [Header("Vision Properties")]

    Rigidbody rb;
    NavMeshAgent agent;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        MoveToPoint(currentPoint);
    }

    void Update()
    {
        if (agent.remainingDistance == 0 && agent.pathStatus == NavMeshPathStatus.PathComplete && isMoving) // agent.remainingDistance == 0
        {
            isMoving = false;
            UpdateDestination();
            MoveToPoint(currentPoint);
        }
    }

    void MoveToPoint(int pointIndex)
    {
        isMoving = true;
        agent.SetDestination(movementCorners[pointIndex]);
    }

    void UpdateDestination()
    {
        if (!reverse) currentPoint++;
        else currentPoint--;

        if(currentPoint >= movementCorners.Length || currentPoint < 0)
        {
            if (movementLoops) currentPoint = 0;
            else
            {
                if (reverse) currentPoint += 2;
                else currentPoint -= 2;
                reverse = !reverse;
            }
        }
    }

    void MoveToPlayer()
    {
        if (playerLocation != null) agent.SetDestination(playerLocation);
        else MoveToPoint(currentPoint);
    }
}
