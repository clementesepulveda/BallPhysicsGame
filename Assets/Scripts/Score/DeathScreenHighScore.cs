using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathScreenHighScore : MonoBehaviour
{

    void Start() {
        if (!PlayerPrefs.HasKey("HighScore")) {
            InstantiateDefaultHighScore();
        }
        LoadHighScore();

        // TODO feels half assed
        GameObject.FindGameObjectWithTag($"Color Manager").GetComponent<ColorManager>().LoadColors();
    }

    void InstantiateDefaultHighScore() {
        PlayerPrefs.SetInt("HighScore", 0);
    }

    void LoadHighScore() {
        string highScore = PlayerPrefs.GetInt("HighScore").ToString();
        gameObject.GetComponent<TMP_Text>().text = "High Score: " + highScore;
    }
}
