using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetLatestScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        // TODO get this out of here?
        int score = GameObject.Find("ScoreManager").GetComponent<ScoreCounter>().GetCurrentScore();
        GameEvents.current.FinalGameScore(score);
        gameObject.GetComponent<TMP_Text>().text = "Score: " + score;
    }
}
