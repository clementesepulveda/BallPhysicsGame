using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private GameObject scoreObject;

    private TMP_Text scoreText;
    private int counter;

    // Start is called before the first frame update
    void Start() {
        GameEvents.current.onPaddleHit += AddToCounter;
        GameEvents.current.onBallDeath += SaveHighScore;
        GameEvents.current.onSceneLoad += LoadScene;

        scoreText = scoreObject.GetComponent<TMP_Text>();
        LoadScene();
    }

    private void LoadScene() {
        counter = 0;
    }


    public int GetCurrentScore() {
        return counter;
    }

    private void AddToCounter() {
        counter += 1;

        scoreText.text = "Score: "+ counter.ToString();
    }

    private void SaveHighScore() {
        if (!PlayerPrefs.HasKey("HighScore")) {
            PlayerPrefs.SetString("HighScore", "0");
        }
        
        int currentHighScore = int.Parse(PlayerPrefs.GetString("HighScore"));
        if ( counter > currentHighScore) {
            PlayerPrefs.SetString("HighScore", counter.ToString());
        }
    }
}
