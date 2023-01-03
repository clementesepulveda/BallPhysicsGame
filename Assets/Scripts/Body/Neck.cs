using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neck : MonoBehaviour
{
    private GameObject head;
    public GameObject pointTo;
    public float headToPointDistance;
    public float smoothTime = 0.25f;
    
    private Vector3 velocity = Vector3.zero;

    private Vector3 targetPosition;
    void Start() {
        pointTo = GameObject.FindGameObjectWithTag("Point To");
        head = GameObject.FindGameObjectWithTag("Player");
        targetPosition = new Vector3(head.transform.position.x,pointTo.transform.position.y,0);
    }

    void Update() {

        // not smooth y ball movement
        Vector3 pointToPos = pointTo.transform.position;
        pointToPos.y = head.transform.position.y - headToPointDistance;
        pointTo.transform.position = pointToPos;

        // smooth x ball movement
        targetPosition = pointToPos;
        targetPosition.x = head.transform.position.x;
        pointTo.transform.position = Vector3.SmoothDamp(
            pointTo.transform.position,
            targetPosition,
            ref velocity,
            smoothTime
        );

        // point at ball
        Vector3 ballDirection = -(transform.position - pointTo.transform.position);
        ballDirection.x = -ballDirection.x;

        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, -ballDirection);
        toRotation = Quaternion.Euler(-toRotation.eulerAngles);
        transform.rotation = toRotation;
    }
}
