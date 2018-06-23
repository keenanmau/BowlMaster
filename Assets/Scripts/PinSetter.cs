using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;
    public Text standingDisplay;
    public float settlingTime = 3.0f;
    public int lastSettledCount = 10;

    private float lastChangeTime;
    private bool ballEnteredBox = false;
    private BowlingBall ball;

    public GameObject pinSet;
    private ActionMaster actionMaster;
    Animator animator;


	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<BowlingBall>();
        actionMaster = new ActionMaster();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();
        if (ballEnteredBox) {
            CheckStanding();
        }


	}
    void CheckStanding() {
        int countStanding = CountStanding();
        if(lastStandingCount != countStanding) {
            lastStandingCount = countStanding;
            lastChangeTime = Time.time;
        } else if((Time.time - lastChangeTime) > settlingTime){
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled() {
        int pinfall = lastSettledCount - CountStanding();
        lastSettledCount = CountStanding();
        ActionMaster.Action result = actionMaster.Bowl(pinfall);
        Debug.Log("Pinfall: " + pinfall + " //  Result: " + result);
        lastStandingCount = -1;
        standingDisplay.color = Color.green;
        ballEnteredBox = false;
        ball.Reset();

        if(result == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        }else if(result == ActionMaster.Action.Reset) {
            lastSettledCount = 10;
            animator.SetTrigger("resetTrigger");
        } else if (result == ActionMaster.Action.EndTurn) {
            lastSettledCount = 10;
            animator.SetTrigger("resetTrigger");
        } else if (result == ActionMaster.Action.EndGame) {
            throw new UnityException("Don't know how to handle end game");

        }
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

    void RaisePins() {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.Raise();
        }
    }

    void LowerPins() {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.Lower();
            Rigidbody rigidbody = pin.gameObject.GetComponent<Rigidbody>();
            rigidbody.velocity = Vector3.zero;
        }
    }

    void RenewPins() {
        GameObject newPins = Instantiate(pinSet, new Vector3(0, 45, 1896), Quaternion.identity);
        foreach(Transform child in newPins.transform) {
        }
    }

    

    private void OnTriggerEnter(Collider other) {
        BowlingBall bBall = other.gameObject.GetComponent<BowlingBall>();
        if (bBall) {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }
    }


}
