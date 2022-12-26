using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetLatestScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        int score = GameObject.Find("ScoreManager").GetComponent<ScoreCounter>().GetCurrentScore();
        gameObject.GetComponent<TMP_Text>().text = "Score: " + score;
    }
}
