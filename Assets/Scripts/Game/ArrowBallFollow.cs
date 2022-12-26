using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBallFollow : MonoBehaviour
{

    public GameObject ball;

    [SerializeField]
    private float scaleMultiplier;

    [SerializeField]
    private float minScaleDistance;
    

    [SerializeField]
    private float minScale;

    private Vector3 ballPosition;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    private float leftOffset;
    private float topOffset;


    void Start() {
        Vector3 camBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        maxX = camBoundary.x;
        minY = camBoundary.y;
        camBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        minX = camBoundary.x+transform.localScale.x/2;
        maxY = camBoundary.y-transform.localScale.y/2;
        
        leftOffset = transform.localScale.x/2;
        topOffset = transform.localScale.y/2;
    }

    void Update(){
        ballPosition = ball.transform.position;

        RotateObject();
        ScaleObject();
        MoveObject();
        ChangeOpacity();
    }

    void RotateObject() {
        Vector3 target = ballPosition;
        target.z = 0f;

        Vector3 objectPos = transform.position;
        target.x = target.x - objectPos.x;
        target.y = target.y - objectPos.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void ScaleObject() {
        float distance = Vector3.Distance(transform.position, ballPosition);
        if ( distance <= minScaleDistance ) {
            transform.localScale = new Vector3(1,1,1);
        } else {
            float newScale = Mathf.Max( 1 / distance, minScale);
            transform.localScale = new Vector3(newScale, newScale, newScale);
        }
    }

    void MoveObject() {
        Vector3 target = new Vector3(0,0,0);
        // right
        target.x = Mathf.Min(maxX, ballPosition.x);
        // bot
        target.y = Mathf.Max(minY, ballPosition.y);
        // left
        target.x = Mathf.Max(minX-leftOffset, target.x);
        //top
        target.y = Mathf.Min(maxY+topOffset, target.y);

        Vector3 direction =  (target) - transform.position;
        transform.position = target;
    }

    void ChangeOpacity() {
        // TODO
        float newOpacity = Mathf.Clamp(
            Vector3.Distance(transform.position, ballPosition)/transform.localScale.x,
            0,
            1
        );
        Vector4 newColor = gameObject.GetComponent<SpriteRenderer>().color;
        newColor.w = newOpacity;
        gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }
}
