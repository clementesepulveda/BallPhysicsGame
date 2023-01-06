using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallPhysics : MonoBehaviour
{

    [SerializeField]
    private float gravityScale = 1;

    [SerializeField]
    private float paddleSpeedTransfer = 1;

    [SerializeField]
    private float minBounceSpeed = 5;

    [SerializeField]
    private float maxBounceSpeed = 25;

    [SerializeField]
    private float initialSpeed = 3;

    [SerializeField]
    private float minInitAngle = -30;

    [SerializeField]
    private float maxInitAngle = 30;


    private Rigidbody2D rb;
    private Vector3 velocityBeforeCollision;

    private bool gameHasStarted;

    // Start is called before the first frame update
    void Start(){
        gameHasStarted = false;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0,0,0);
        rb.gravityScale = 0;

    }

    void Update() {
        if (Input.anyKey && !gameHasStarted) {
            gameHasStarted = true;
            
            // Quaternion randomAngle = Random.rotation;
            // TODO
            float angleDegrees = Random.Range(minInitAngle, maxInitAngle) + 90;
            float angleRads = angleDegrees * Mathf.Deg2Rad;
            rb.velocity = new Vector3(Mathf.Cos(angleRads)*initialSpeed, Mathf.Sin(angleRads)*initialSpeed, 0);
            
            rb.gravityScale = gravityScale;
        }
    }

    void LateUpdate() {
        velocityBeforeCollision = rb.velocity;
    }
    
    void OnCollisionEnter2D(Collision2D col) {
        if ( ReadyForPaddleHit() && col.gameObject.tag == "Player" ) {
            GameEvents.current.PaddleHit();
            AddYVelocity(col);
        }
    }

    private bool ReadyForPaddleHit() {
        // TODO Fix physics my guy
        return true;
        // return rb.velocity.y <= 0.0;
    }

    private void AddYVelocity(Collision2D col) {
        Vector3 vel = velocityBeforeCollision;

        vel = Vector3.Reflect(vel, col.contacts[0].normal);
        vel += paddleSpeedTransfer*col.gameObject.GetComponent<MovePaddle>().Velocity;
        vel.y = Mathf.Clamp(vel.y, minBounceSpeed, maxBounceSpeed);

        // just a little randomness in the x value why not
        vel.x += Random.Range(-0.5f, 0.5f);

        rb.velocity = vel;
    }
}
