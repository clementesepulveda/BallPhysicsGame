using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    void OnDisable()
    {
        Time.timeScale = 1;
        GameObject.Find("Paddle").GetComponent<MovePaddle>().canMove = false;

    }

    void OnEnable()
    {
        // TODO feels half assed
        GameObject.FindGameObjectWithTag($"Color Manager").GetComponent<ColorManager>().LoadColors();
        Time.timeScale = 0;
    }

    public void DeactivatePauseMenu() {
        GameObject.Find("Paddle").GetComponent<MovePaddle>().canMove = false;
        GameEvents.current.ButtonPress();
        pauseMenu.SetActive(false);
        GameObject.Find("Paddle").GetComponent<MovePaddle>().canMove = false;
    }
}
