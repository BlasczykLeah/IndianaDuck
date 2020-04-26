using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public bool inGame;

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GoToStartAnim()
    {
        SceneManager.LoadScene(2);
    }

    public void title()
    {
        SceneManager.LoadScene(0);
    }
}
