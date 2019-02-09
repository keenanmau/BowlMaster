using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    public GameObject pinSet;
    private Animator animator;
    private PinCounter pinCounter;

    // Use this for initialization
    void Start () {
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        
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
        pinCounter.Reset();
    }

    public void PerformAction(ActionMaster.Action action) {
        if (action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        } else if (action == ActionMaster.Action.Reset) {
            pinCounter.Reset();
            animator.SetTrigger("resetTrigger");
        } else if (action == ActionMaster.Action.EndTurn) {
            animator.SetTrigger("resetTrigger");
        } else if (action == ActionMaster.Action.EndGame) {
            throw new UnityException("Don't know how to handle end game");

        }
    }
    
}
