using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class EnemyPatrol : MonoBehaviour
{
    public bool stunned;
    public float stunTime;
    float stunCounting;

    [Header("Patrol Properties")]
    public Vector3[] movementCorners;    // points of movement
    public Vector3 playerLocation;
    public int currentPoint;
    public bool movementLoops;      // if movement loops, go from last point -> first point, else go from last point -> second last point (reverse order)
    bool reverse;
    bool isMoving;
    public float moveSpeed = 3.5F;

    [Header("Vision Properties")]
    public float visionRadius;
    [Range(0, 360)]
    public float visionAngle;
    bool playerSpotted = false;
    public float trackingCooldown;
    public float resetNumber;
    public LayerMask targetMask;
    public LayerMask obstacleMask;

    Rigidbody rb;
    NavMeshAgent agent;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        MoveToPoint(currentPoint);
        StartCoroutine("DelayTargetFinder", 0.2F);
    }

    void Update()
    {
        // if movementCorners.length = 1, no moving to targets only if targets player then go back

        FindTarget();

        if (stunned)
        {
            agent.speed = 0;
            stunCounting -= Time.deltaTime;
            if (stunCounting < 0)
            {
                // reset stun
                stunned = false;
                agent.speed = moveSpeed;
                stunCounting = stunTime;
            }
        }

        if (playerSpotted)
        {
            trackingCooldown -= Time.deltaTime;
            if(trackingCooldown < 0)
            {
                playerSpotted = false;
                trackingCooldown = resetNumber;
                MoveToPoint(currentPoint);
            }
        }
        else
        {
            if (agent.remainingDistance == 0 && agent.pathStatus == NavMeshPathStatus.PathComplete && isMoving)
            {
                isMoving = false;
                UpdateDestination();
                MoveToPoint(currentPoint);
            }
        }
    }

    #region Field of View

    public Vector3 AngleDirection(float angle, bool angleIsGlobal)
    {
        if (!angleIsGlobal) angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }

    void FindTarget()
    {
        Collider[] targetFound = Physics.OverlapSphere(transform.position, visionRadius, targetMask);

        if(targetFound.Length > 0)
        {
            Vector3 directionToTarget = (targetFound[0].transform.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, directionToTarget) < visionAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, targetFound[0].transform.position);
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                {
                    playerSpotted = true;
                    trackingCooldown = resetNumber;

                    playerLocation = targetFound[0].transform.position;
                    MoveToPlayer();
                }
            }
        }
        //StartCoroutine("DelayTargetFinder", 0.2F);
    }

    IEnumerator DelayTargetFinder(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindTarget();
        }
    }

    #endregion

    #region Movements

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

    void MoveToPoint(int pointIndex)
    {
        isMoving = true;
        agent.SetDestination(movementCorners[pointIndex]);
    }

    void MoveToPlayer()
    {
        if (playerLocation != null) agent.SetDestination(playerLocation);
        else MoveToPoint(currentPoint);
    }
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if((LayerMask.GetMask("Ground") & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            rb.isKinematic = true;
        }
    }
}
