using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current { get; private set; }
    private void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (current != null && current != this) { 
            Destroy(this.gameObject); 
        } else { 
            current = this; 
            DontDestroyOnLoad(this.gameObject);
        } 
    }
    
    public event Action onPaddleHit;
    public void PaddleHit() {
        if (onPaddleHit != null) {
            onPaddleHit();
        }
    }

    public event Action onBallDeath;
    public void BallDeath() {
        if (onBallDeath != null) {
            onBallDeath();
        }
    }

    public event Action onButtonPress;
    public void ButtonPress() {
        if (onButtonPress != null) {
            onButtonPress();
        }
    }

    public event Action onCoinCollect;
    public void CoinCollect() {
        if (onCoinCollect != null) {
            onCoinCollect();
        }
    }

    public event Action onSceneLoad;
    public void SceneLoad() {
        if (onSceneLoad != null) {
            onSceneLoad();
        }
    }

    public event Action onLeaderboardLoad;
    public void LeaderboardLoad() {
        if (onLeaderboardLoad != null) {
            onLeaderboardLoad();
        }
    }

    public event Action onLeaderboardFail;
    public void LeaderboardFail() {
        if (onLeaderboardFail != null) {
            onLeaderboardFail();
        }
    }

    public event Action<int> onFinalGameScore;
    public void FinalGameScore(int score) {
        if (onFinalGameScore != null) {
            onFinalGameScore(score);
        }
    }

}
