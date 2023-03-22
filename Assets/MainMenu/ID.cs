using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject identificationUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        identificationUI.SetActive(false);
        GameIsPaused = false;
    }

    void Pause()
    {
        identificationUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
