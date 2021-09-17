using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenuBehaviour : MonoBehaviour
{
    public GameObject menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        menu.SetActive(true);
        Time.timeScale = 0.000001f;

    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        menu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
