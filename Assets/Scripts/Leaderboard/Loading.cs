using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    // public rectTransform ;
    public float tCycle;
    public GameObject failScreen;

    void Start() {
        GameEvents.current.onLeaderboardLoad += DeleteObject;
        GameEvents.current.onLeaderboardFail += DeleteObject;
    }

    void OnDestroy() {
        GameEvents.current.onLeaderboardLoad -= DeleteObject;
        GameEvents.current.onLeaderboardFail -= DeleteObject;
    }

    void Update() {
        transform.Rotate(0,0,-180*Time.deltaTime);
    }

    private void ShowFailAndDeleteObject() {
        Debug.Log("why?");
        Instantiate(failScreen);

        // TODO feels half assed
        GameObject.FindGameObjectWithTag($"Color Manager").GetComponent<ColorManager>().LoadColors();

        Destroy(gameObject);
    }
    private void DeleteObject() {
        Destroy(gameObject);
    }
}
