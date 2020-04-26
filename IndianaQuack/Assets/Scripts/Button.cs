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
    AudioManager AM;

    // Start is called before the first frame update
    void Start()
    {
        AM = AudioManager.instance;
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
            if (!startTimer && !boulder)
            {
                AM.Time();
                anim.SetBool("Open", true);
                //AM.Time();
            }
            startTimer = true;
            timeLeft = maxTime;

            if (boulder)
            {
                anim.SetBool("Open", true);
                maxTime = 99999999;
                b.rollBoulder();
                boulder = false;

            }
        }
    }

    void setTime()
    {
        //timeLeft = maxTime;
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            startTimer = false;
            //AM.StopTime();
            timeLeft = maxTime;
            anim.SetBool("Open", false);
        }
    }
}
