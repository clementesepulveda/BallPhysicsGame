using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class ShowLeaderboard : MonoBehaviour
{
    public int MaxScores;
    public int ID;
    public GameObject userTextPrefab;
    public GameObject leaderboardLayout;


    void Start() {
        LootLockerSDKManager.StartGuestSession((response) => {
            if ( response.success ) {
                ShowScores();
            } else {
                GameEvents.current.LeaderboardFail();
            }
        });
    }

    public void ShowScores() {
        LootLockerSDKManager.GetScoreList(ID.ToString(), MaxScores, (response) => {
            if ( response.success ) {
                LootLockerLeaderboardMember[] scores = response.items;
                foreach (var item in scores) {
                    GameObject newUserScore = Instantiate(userTextPrefab) as GameObject;
                    newUserScore.transform.SetParent(leaderboardLayout.transform, false);
                    newUserScore.GetComponent<UserText>().setTexts(item.rank, item.member_id, item.score);
                }
                
                // scroll to the top
                Vector3 initialPos = leaderboardLayout.GetComponent<RectTransform>().localPosition;
                initialPos.y = 23 - 100*scores.Length;
                leaderboardLayout.GetComponent<RectTransform>().localPosition = initialPos;

                
                GameEvents.current.LeaderboardLoad();
                // TODO feels half assed
                GameObject.FindGameObjectWithTag($"Color Manager").GetComponent<ColorManager>().LoadColors();

            } else {
                // Debug.Log("Its debugging time my dudes for submition");
            }    
        });

    }
}
