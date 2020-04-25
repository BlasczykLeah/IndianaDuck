using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public float timeLeft, maxTime;
    public bool startTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            setTime();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            startTimer = true;
        }
    }

    void setTime()
    {
        //timeLeft = maxTime;
        timeLeft -= Time.deltaTime;

        if(timeLeft <= 0)
        {
            startTimer = false;
            timeLeft = maxTime;
        }
    }
}
