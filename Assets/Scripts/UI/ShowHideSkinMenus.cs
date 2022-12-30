using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ShowHideSkinMenus : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int buttonId;
    public Image buttonImage;
    public GameObject[] menus;

    public float onHoverDownTranslate = -10;
    private Vector3 originalPosition;

    void Start() {
        originalPosition = transform.position;
    }

    public void SetThisMenu() {
        foreach (var menu in menus) {
            menu.SetActive(false);
        }

        menus[buttonId].SetActive(true);
    }
     
    public void OnPointerEnter(PointerEventData eventData) {
        transform.position += new Vector3(0, onHoverDownTranslate, 0);
        Debug.Log("Enter");
    }

    public void OnPointerExit(PointerEventData eventData) {
        transform.position -= new Vector3(0, onHoverDownTranslate, 0);
        Debug.Log("Exit");
    }
}
