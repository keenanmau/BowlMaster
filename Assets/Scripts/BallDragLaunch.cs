using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BowlingBall))]
public class BallDragLaunch : MonoBehaviour {

    private BowlingBall ball;
    private Vector3 mouseStartPosition;
    private Vector3 direction;
    private float startTime, endTime;
    private bool star;
    // Use this for initialization
    void Start () {
        ball = GetComponent<BowlingBall>();

	}
	
    public void DragStart() {
        //capture time and position of drag starts

        mouseStartPosition = Input.mousePosition;
        startTime = Time.time;

    }

    public void DragEnd() {
        //launch the ball 
        
        direction = Input.mousePosition - mouseStartPosition;
        float dragDuration = Time.time - startTime;
        float launchSpeedX = (direction.x) / dragDuration;
        float launchSpeedY = (direction.y) / dragDuration;

        Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedY);
        ball.Launch(launchVelocity);
    }

    public void MoveStart(float xNudge) {
        if (!ball.inPlay) {
            Debug.Log("move" + xNudge);
            ball.transform.Translate(new Vector3(xNudge, 0, 0));
        }
    }
}
