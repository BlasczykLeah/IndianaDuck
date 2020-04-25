using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuackOfCourage : MonoBehaviour
{
    public float quackRadius;
    public LayerMask layer;

    public bool hasQuacked = false;
    public float quackCooldown = 2F;
    float quackWaitTime;

    public float delayQuack = 0.2F;

    // Start is called before the first frame update
    void Start()
    {
        quackWaitTime = quackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasQuacked)
        {
            quackWaitTime -= Time.deltaTime;
            if(quackWaitTime < 0)
            {
                quackWaitTime = quackCooldown;
                hasQuacked = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                hasQuacked = true;
                Debug.Log("QUACK");
                Invoke("StunEm", delayQuack);
            }
        }
    }

    void StunEm()
    {
        Collider[] targetFound = Physics.OverlapSphere(transform.position, quackRadius, layer);
        if (targetFound.Length > 0)
        {
            for (int i = 0; i < targetFound.Length; i++)
            {
                if (targetFound[i].CompareTag("Enemy")) targetFound[i].GetComponent<EnemyPatrol>().stunned = true;
            }
        }
        else hasQuacked = false;
    }
}
