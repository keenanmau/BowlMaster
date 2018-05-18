using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 3f;




	// Use this for initialization
	void Start () {
       
		
	}
	
	// Update is called once per frame
	void Update () {
        print(name + IsStanding());
    }

    public bool IsStanding() {
        
        Vector3 pinRotation = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(pinRotation.x);
        float tiltInZ = Mathf.Abs(pinRotation.z);
        if (tiltInX > standingThreshold || tiltInZ > standingThreshold) {
            return false;
        } else return true;
    }
}
