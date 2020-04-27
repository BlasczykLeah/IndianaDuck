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
    bool hasChanges = false;

    [Header("Toggles")]
    public float volume;    //AudioListener.volume = [0, 1]
    public Slider slider;
    public Toggle muteSound;
    public Toggle invertCameraAxis;
    public Toggle invertX;
    public Toggle invertY;

    [Header("Connections")]
    public CameraMove cameraMove;
    public DuckMove duckMove;
    public AudioListener cameraAudio;

    // Start is called before the first frame update
    void Start()
    {
        volume = slider.value;

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

        if (optionsOpen)
        {
            if (muteSound.isOn) AudioListener.volume = 0;
            else AudioListener.volume = volume;

            if (slider.value != volume)
            {
                volume = slider.value;
                AudioListener.volume = volume;
                if (muteSound.isOn) muteSound.isOn = false;
            }
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
            if (hasChanges)
            {
                UpdateChanges();
                hasChanges = false;
            }

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
        if (!hasChanges) hasChanges = true;
        optionsOpen = !optionsOpen;

        if (optionsOpen) optionsMenu.SetActive(true);
        else optionsMenu.SetActive(false);
    }

    public void ToTitle()
    {
        SceneManager.LoadScene(0);
    }

    void UpdateChanges()
    {
        if (invertCameraAxis.isOn) cameraMove.inverter = -1;
        else cameraMove.inverter = 1;

        if (invertX.isOn) duckMove.invertX = -1;
        else duckMove.invertX = 1;

        if (invertY.isOn) duckMove.invertY = -1;
        else duckMove.invertY = 1;
    }
}
