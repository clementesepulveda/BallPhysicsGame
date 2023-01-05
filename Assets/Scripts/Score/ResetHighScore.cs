using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighScore : MonoBehaviour
{
    public void ResetScore() {
        GameEvents.current.ButtonPress();
        PlayerPrefs.DeleteAll();
        // PlayerPrefs.SetInt("HighScore", 0);

        // TODO feels half assed
        GameObject.FindGameObjectWithTag($"Color Manager").GetComponent<ColorManager>().LoadColors();
    }
}
