using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource quack;
    public AudioSource clock;
    public AudioSource rock;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Courage()
    {
        quack.Play();
    }

    public void Time()
    {
        clock.Play();
    }

    public void StopTime()
    {
        clock.Stop();
    }

    public void RollRock()
    {
        rock.Play();
    }
}
