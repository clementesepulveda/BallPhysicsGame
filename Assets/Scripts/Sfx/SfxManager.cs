using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{

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
    }

    void Start() {
        GameEvents.current.onPaddleHit += PlayBallPaddleHit;
        GameEvents.current.onBallDeath += PlayFinishRoundSound;
        GameEvents.current.onButtonPress += PlayButtonSfx;
    }

    private void PlayBallPaddleHit() {
        BallPaddleHitSfx.pitch = UnityEngine.Random.Range(minBallPaddlePitch, maxBallPaddlePitch);
        BallPaddleHitSfx.Play();
    }

    private void PlayFinishRoundSound() {
        FinishRoundSfx.Play();
    }
    
    private void PlayButtonSfx() {
        buttonSfx.Play();
    }
}
