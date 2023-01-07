using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockColorButton : MonoBehaviour
{
    public int highScoreToUnlock;
    public Button button;
    public Image color1,color2,color3,color4, background;
    public Image padLock;
    public TMP_Text showHowMuchIsNeeded;

    // Start is called before the first frame update
    void Start() {
        if (PlayerPrefs.HasKey("HighScore")) {
            if ( PlayerPrefs.GetInt("HighScore") < highScoreToUnlock ) {
                LockItem();
            } else {
                UnlockItem();
            }
        } else if ( highScoreToUnlock == 0 ) {
            UnlockItem();
        } else {
            LockItem();
        }
    }

    private void LockItem() {
        color1.enabled = false;
        color2.enabled = false;
        color3.enabled = false;
        color4.enabled = false;
        background.enabled = false;
        button.interactable = false;

        padLock.enabled = true;
        showHowMuchIsNeeded.enabled = true;
        showHowMuchIsNeeded.text = $"Get a highscore of {highScoreToUnlock} to unlock";
    }

    private void UnlockItem() {
        color1.enabled = true;
        color2.enabled = true;
        color3.enabled = true;
        color4.enabled = true;
        background.enabled = true;
        button.interactable = true;

        padLock.enabled = false;
        showHowMuchIsNeeded.enabled = false;
    }
}
