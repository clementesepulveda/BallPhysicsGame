using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SfxPlayerPrefs : MonoBehaviour
{
    public Toggle toggle;
    public string togglePlayerPrefs;
    private SfxManager musicManager;
    
    void Start() {
        musicManager = GameObject.FindGameObjectWithTag("Music Manager").GetComponent<SfxManager>();
        LoadToggle();
    }

    void LoadToggle() {
        if (PlayerPrefs.GetInt(togglePlayerPrefs) == 0) {
            toggle.isOn = false;
        } 
    }
    
    public void ChangeSfx(bool turnOn) {
        if (turnOn) {
            musicManager.TurnOnSfx();
            GameEvents.current.ButtonPress();
        } else {
            musicManager.TurnOffSfx();
        }
    }
    
    public void ChangeBackgroundMusic(bool turnOn) {
        if (turnOn) {
            musicManager.TurnOnMusic();
        } else {
            musicManager.TurnOffMusic();
        }

        GameEvents.current.ButtonPress();
    }
}
