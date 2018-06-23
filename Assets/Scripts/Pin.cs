using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 3f;
    public float distanceToRaise = 4f;

    private Rigidbody rigidbody;
    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    public bool IsStanding() {
        
        Vector3 pinRotation = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(270 - pinRotation.x);
        float tiltInZ = Mathf.Abs(pinRotation.z);
        if (tiltInX > standingThreshold || tiltInZ > standingThreshold) {
            return false;
        } else return true;
    }

    public void Raise() {
        rigidbody.angularVelocity = Vector3.zero;
        if (IsStanding()) {
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
        }
        rigidbody.useGravity = false;
    }

    public void Lower() {
        rigidbody.angularVelocity = Vector3.zero;
        if (IsStanding()) {
            transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
        }
        rigidbody.useGravity = true;
        
    }
}
