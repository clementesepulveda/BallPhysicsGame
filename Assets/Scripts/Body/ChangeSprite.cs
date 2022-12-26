using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public int spriteId;

    public void OnMouseDown() {
        Debug.Log($"SAVING SPRITE NUMBER {spriteId}");
        PlayerPrefs.SetString("ballSprite", spriteId.ToString());
    }
}
