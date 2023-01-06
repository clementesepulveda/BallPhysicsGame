using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserText : MonoBehaviour
{
    public TMP_Text rankText, userText, scoreText;
    
    public void setTexts(int rank, string user, int score) {
        rankText.text = rank.ToString()+".";
        userText.text = user;
        scoreText.text = score.ToString();
    }
}
