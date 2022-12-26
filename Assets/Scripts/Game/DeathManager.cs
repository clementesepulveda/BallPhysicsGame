using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    
    [SerializeField]
    private GameObject deathScreen;

    [SerializeField]
    private float camLowerBoundary;

    private bool hasDied;


    // Start is called before the first frame update
    void Start() {
        hasDied = false;
        camLowerBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).y -  transform.localScale.y/2;// TODO
    }

    // Update is called once per frame
    void Update() {
        if (camLowerBoundary > transform.position.y && !hasDied) {
            GameEvents.current.BallDeath();
            hasDied = true;
            Instantiate(deathScreen, new Vector3(2.0F, 0, 0), Quaternion.identity);
            Time.timeScale = 0; // TODO, maybe dont use this ?
        }
    }
}
