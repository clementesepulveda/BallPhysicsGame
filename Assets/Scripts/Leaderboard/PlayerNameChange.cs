using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameChange : MonoBehaviour
{
    public TMP_InputField playerInput;
    public TMP_Text inputFieldText;
    
    void Start() {
        playerInput.onValueChanged.AddListener(TextMeshUpdated);

        if (!PlayerPrefs.HasKey("memberId")) {
            // TODO
            PlayerPrefs.SetString("memberId", ""); 
        }

        playerInput.text = PlayerPrefs.GetString("memberId");
    }

    public void TextMeshUpdated(string text) {
        PlayerPrefs.SetString("memberId", text); 
    }
}
