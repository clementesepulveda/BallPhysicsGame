using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    // Player Preference
    public bool musicOn;
    public bool sfxOn;
    // public float musicVolume;

    // Music
    public AudioSource backgroundMusic;

    // Ball Paddle Hit
    public AudioSource BallPaddleHitSfx;
    private float minBallPaddlePitch = 0.9f;
    private float maxBallPaddlePitch = 1.9f;

    // Death Sound
    public AudioSource FinishRoundSfx;

    // Button Sound
    public AudioSource buttonSfx;

    public static SfxManager Instance { get; private set; }

    private void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) { 
            Destroy(this.gameObject); 
        } else { 
            Instance = this; 
            DontDestroyOnLoad(this.gameObject);
        }

        CheckPlayerPrefs();
    }

    void Start() {
        GameEvents.current.onPaddleHit += PlayBallPaddleHit;
        GameEvents.current.onBallDeath += PlayFinishRoundSound;
        GameEvents.current.onButtonPress += PlayButtonSfx;

        Load(); 
    }

    private void CheckPlayerPrefs() {
        if (!PlayerPrefs.HasKey("play_bg_music")) {
            PlayerPrefs.SetInt("play_bg_music", 1);
        } 
        if (!PlayerPrefs.HasKey("sfx_on")) {
            PlayerPrefs.SetInt("sfx_on", 1);
        } 
    }

    private void Load() {
        if (PlayerPrefs.GetInt("play_bg_music") == 0){
            TurnOffMusic();
        } else {
            TurnOnMusic();
        }

        if (PlayerPrefs.GetInt("sfx_on") == 1){
            sfxOn = true;
        } else {
            sfxOn = false;
        }
    }

    public void TurnOnSfx() {
        PlayerPrefs.SetInt("sfx_on", 1);
        sfxOn = true;
    }

    public void TurnOffSfx() {
        PlayerPrefs.SetInt("sfx_on", 0);
        sfxOn = false;
    }

    public void TurnOnMusic() {
        PlayerPrefs.SetInt("play_bg_music", 1);
        backgroundMusic.Play();
    }

    public void TurnOffMusic() {
        PlayerPrefs.SetInt("play_bg_music", 0);
        backgroundMusic.Pause();
    }

    private void PlayBallPaddleHit() {
        if (!sfxOn){return;}

        BallPaddleHitSfx.pitch = UnityEngine.Random.Range(minBallPaddlePitch, maxBallPaddlePitch);
        BallPaddleHitSfx.Play();
    }

    private void PlayFinishRoundSound() {
        if (!sfxOn){return;}

        FinishRoundSfx.Play();
    }
    
    private void PlayButtonSfx() {
        if (!sfxOn){return;}

        buttonSfx.Play();
    }
}
