using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public float timeLeft, maxTime;
    public bool startTimer;
    public Animator anim;
    public bool boulder;
    public Boulder b;

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

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(!startTimer) anim.SetBool("Open", true);
            startTimer = true;
            timeLeft = maxTime;

            if (boulder)
            {
                b.rollBoulder();
                boulder = false;
            }
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
            anim.SetBool("Open", false);
        }
    }
}
