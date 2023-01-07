using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.

public class ButtonOnMouseDown : MonoBehaviour, IPointerDownHandler 
{
    public GameObject pauseMenu;

    public void ActivatePauseMenu() {
        GameObject.Find("Paddle").GetComponent<MovePaddle>().canMove = false;
        GameEvents.current.ButtonPress();
        pauseMenu.SetActive(true);
        GameObject.Find("Paddle").GetComponent<MovePaddle>().canMove = false;
    }

    public void OnPointerDown(PointerEventData eventData) {
        ActivatePauseMenu();
    }

    
}
