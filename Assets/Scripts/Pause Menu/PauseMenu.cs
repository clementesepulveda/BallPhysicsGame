using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    void OnDisable()
    {
        Time.timeScale = 1;

    }

    void OnEnable()
    {
        // TODO feels half assed
        GameObject.FindGameObjectWithTag($"Color Manager").GetComponent<ColorManager>().LoadColors();
        Time.timeScale = 0;
    }

    public void DeactivatePauseMenu() {
        GameEvents.current.ButtonPress();
        pauseMenu.SetActive(false);
        Debug.Log("DEACTivating");

        GameObject.Find("Paddle").GetComponent<MovePaddle>().isPaused = false;
    }
}
