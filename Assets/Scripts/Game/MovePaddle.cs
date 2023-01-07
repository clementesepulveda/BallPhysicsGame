using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class MovePaddle : MonoBehaviour {

    public Rigidbody2D paddleRb;
    public float m_Speed = 5f;

    public Vector3 Velocity { get; private set; }
    private Vector3 mOffset;
    private float mZCoord;
    private Vector3 oldPosition;

    public bool canMove;
    public bool isPaused;

    void Start() {
        oldPosition = transform.position;

        canMove = false;
        isPaused = false;
    }

    void Update() {
        if ( (Input.GetMouseButton(0) || Input.touchCount > 0 ) && !isPaused) {
            if ( !EventSystem.current.IsPointerOverGameObject() ) {
                canMove = true;
            } else if (EventSystem.current.currentSelectedGameObject == null) {
                canMove = true;
            }
            // else if ( EventSystem.current.currentSelectedGameObject.tag == "Color 3 Text" ){
            //     canMove = true;
            // }
            // Debug.Log(EventSystem.current.currentSelectedGameObject);
        } else {
            canMove = false;
        }
    }

    void FixedUpdate() {
        Velocity = (transform.position - oldPosition) / Time.deltaTime;
        oldPosition = transform.position;

        if ( canMove )  {
            MousePress();
        }
    }

    void MousePress() {
        // get mouse position in screen space
        // (if touch, gets average of all touches)
        Vector3 screenPos = Input.mousePosition;
        
        // convert mouse position to world space
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        // get direction
        Vector3 direction = (worldPos) - transform.position;

        // apply new rb position
        paddleRb.MovePosition(transform.position + direction * Time.deltaTime * m_Speed);
    }
}