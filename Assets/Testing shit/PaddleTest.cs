using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleTest : MonoBehaviour
{
    public float m_Speed = 5f;

    public Vector3 Velocity { get; private set; }
    private Vector3 mOffset;
    private float mZCoord;
    private Vector3 oldPosition;

    void Start() {
        oldPosition = transform.position;
    }

    void Update() {
        Velocity = (transform.position - oldPosition) / Time.deltaTime;
        oldPosition = transform.position;

        // if left-mouse-button is being held OR there is at least one touch
        if (Input.GetMouseButton(0) || Input.touchCount > 0) {
            MousePress();
        }
    }

    void MousePress() {
        // get mouse position in screen space
        // (if touch, gets average of all touches)
        Vector3 screenPos = Input.mousePosition;
        // set a distance from the camera
        screenPos.z = 10.0f;
        // convert mouse position to world space
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        // get current position of this GameObject
        Vector3 newPos = transform.position;
        // set x position to mouse world-space x position
        newPos.x = worldPos.x;
        newPos.y = worldPos.y;

        // apply new position
        Vector3 direction = (newPos) - transform.position;
        transform.Translate(direction * Time.deltaTime * m_Speed, Space.World);
    }
}
