using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBallInstantiate : MonoBehaviour
{
    public GameObject arrowObject;
    public GameObject playerObject;

    public Sprite[] headSprites;
    public Sprite[] neckSprites;
    

    public GameObject[] ballPrefabs;

    void Start() {
        if (!PlayerPrefs.HasKey("headSprite")) { SaveSpriteIndex("headSprite", 0); }
        if (!PlayerPrefs.HasKey("neckSprite")) { SaveSpriteIndex("neckSprite", 0); }
        if (!PlayerPrefs.HasKey("ballSprite")) { SaveSpriteIndex("ballSprite", 0); }

        LoadSprites();
    }

    private void SaveSpriteIndex(string spriteName, int index) {
        PlayerPrefs.SetString(spriteName, index.ToString());
    }

    private void LoadSprites() {
        
        // FINISH
        int ballIndex = GetSpriteIndex("ballSprite");
        GameObject ballObject = InstantiateBallPrefab(ballPrefabs[ballIndex]);
        arrowObject.GetComponent<ArrowBallFollow>().ball = ballObject;

        int headIndex = GetSpriteIndex("headSprite");
        InstantiateHeadPrefab(headSprites[headIndex]);
    }

    private int GetSpriteIndex(string spriteName) {
        return int.Parse(PlayerPrefs.GetString(spriteName));
    }

    private GameObject InstantiateBallPrefab(GameObject prefab) {
        GameObject newObject = Instantiate(prefab, new Vector3(0, 2, 0), Quaternion.identity) as GameObject;
        GameObject canvas = GameObject.FindGameObjectWithTag("Ball");
        newObject.transform.SetParent(canvas.transform, false);
        return newObject;
    }

    private GameObject InstantiatePrefab(GameObject prefab) {
        GameObject newObject = Instantiate(prefab, new Vector3(0, 2, 0), Quaternion.identity) as GameObject;
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        newObject.transform.SetParent(canvas.transform, false);
        return newObject;
    }

    private void InstantiateHeadPrefab(Sprite sprite) {
        playerObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

}
