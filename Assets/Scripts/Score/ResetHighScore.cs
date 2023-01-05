using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighScore : MonoBehaviour
{
    public void ResetScore() {
        GameEvents.current.ButtonPress();
        PlayerPrefs.SetInt("HighScore", 0);
    }
}
