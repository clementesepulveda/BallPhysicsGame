using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.

public class ButtonOnMouseDown : MonoBehaviour, IPointerDownHandler 
{
    public GameObject pauseMenu;

    public void ActivatePauseMenu() {
        GameObject.Find("Paddle").GetComponent<MovePaddle>().isPaused = true;
        GameEvents.current.ButtonPress();
        pauseMenu.SetActive(true);
    }

    public void OnPointerDown(PointerEventData eventData) {
        ActivatePauseMenu();
    }

    
}
