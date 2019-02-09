using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {
    public Text standingDisplay;


    private bool ballOutOfPlay = false;

    private GameManager gameManager;

    private int lastStandingCount = -1;
    private float settlingTime = 4.0f;
    private int lastSettledCount = 10;
    private float lastChangeTime;

    private BowlingBall ball;
    

    // Use this for initialization
    void Start () {
        ball = GameObject.FindObjectOfType<BowlingBall>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();
        if (ballOutOfPlay) {
            standingDisplay.color = Color.red;
            CheckStanding();
        }
    }

    void CheckStanding() {
        int countStanding = CountStanding();
        if (lastStandingCount != countStanding) {
            lastStandingCount = countStanding;
            lastChangeTime = Time.time;
        } else if ((Time.time - lastChangeTime) > settlingTime) {
            PinsHaveSettled();
        }
    }

    public void Reset() {
        lastSettledCount = 10;
        //lastStandingCount = -1; //why the fuck does moving this line to pinshavesettled fix the bug???
    }

    void PinsHaveSettled() {
        int countStanding = CountStanding();
        int pinfall = lastSettledCount - countStanding;
        lastSettledCount = countStanding;
        //Debug.Log("Settling Time:" + settlingTime.ToString());
        gameManager.Bowl(pinfall);
        standingDisplay.color = Color.green;
        ballOutOfPlay = false;
        lastStandingCount = -1;
    }

    int CountStanding() {
        int standing = 0;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            if (pin.IsStanding()) {
                standing++;
            }
        }
        return standing;
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Ball") {
            ballOutOfPlay = true;
        }

    }
}
