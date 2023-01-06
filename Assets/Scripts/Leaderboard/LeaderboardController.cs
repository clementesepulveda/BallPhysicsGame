using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    public string memberId;
    public int playerScore;
    public int ID;

    public static LeaderboardController leaderBoardInstance { get; private set; }
    private void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (leaderBoardInstance != null && leaderBoardInstance != this) { 
            Destroy(this.gameObject); 
        } else { 
            leaderBoardInstance = this; 
            DontDestroyOnLoad(this.gameObject);
        } 
    }

    void Start() {
        GameEvents.current.onFinalGameScore += SubmitScore;

        LootLockerSDKManager.StartGuestSession((response) => {
            Debug.Log(response);
            if ( response.success ) {
                // Debug.Log("YAY IT WORKS");
            } else {
                // Debug.Log("Its debugging time my dudes");
            }
        });

        GetMemberId();
        GetPlayerScore();
    }

    void GetMemberId() {
        if (!PlayerPrefs.HasKey("memberId")) {
            PlayerPrefs.SetString("memberId", ""); 
        }
        memberId = PlayerPrefs.GetString("memberId");

    }

    void GetPlayerScore(){
        playerScore = 0;
    }

    public void SubmitScore(int score) {
        GetMemberId();

        LootLockerSDKManager.SubmitScore(memberId, score, ID.ToString(), (response) => {
            if ( response.success ) {
                Debug.Log("YAY IT SUBMITED");
            } else {
                Debug.Log("Its debugging time my dudes for submition");
            }
        });
    }
}
