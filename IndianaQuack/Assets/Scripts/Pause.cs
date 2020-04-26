using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool paused = false;
    bool optionsOpen = false;
    public GameObject pauseScreen;
    public GameObject optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            pauseGame();
        }
    }

    void pauseGame()
    {
        if (paused)
        {
            Cursor.visible = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            if (optionsOpen)
            {
                optionsOpen = false;
                optionsMenu.SetActive(false);
            }
            Cursor.visible = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void BackToGame()
    {
        paused = false;
        pauseGame();
    }

    public void OptionsPage()
    {
        optionsOpen = !optionsOpen;

        if (optionsOpen) optionsMenu.SetActive(true);
        else optionsMenu.SetActive(false);
    }

    public void ToTitle()
    {
        SceneManager.LoadScene(0);
    }
}
