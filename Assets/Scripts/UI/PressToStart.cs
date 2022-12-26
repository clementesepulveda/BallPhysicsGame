using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update() {
        // if left-mouse-button is being held OR there is at least one touch
        if (Input.anyKey) {
            Destroy(gameObject);
        }
    }
}
