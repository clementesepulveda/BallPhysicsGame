using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockButton : MonoBehaviour
{
    public int highScoreToUnlock;
    public Button button;
    public Image unlockableItem;
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
        unlockableItem.enabled = false;
        button.interactable = false;

        padLock.enabled = true;
        showHowMuchIsNeeded.enabled = true;
        showHowMuchIsNeeded.text = $"Get a highscore of {highScoreToUnlock} to unlock";
    }

    private void UnlockItem() {
        unlockableItem.enabled = true;
        button.interactable = true;

        padLock.enabled = false;
        showHowMuchIsNeeded.enabled = false;
    }
}
