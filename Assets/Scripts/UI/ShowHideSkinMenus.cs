using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideSkinMenus : MonoBehaviour
{
    public int buttonId;
    public GameObject[] menus;

    public void SetThisMenu() {
        foreach (var menu in menus) {
            menu.SetActive(false);
        }

        menus[buttonId].SetActive(true);
    }
}
