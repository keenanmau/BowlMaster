using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour {

    [Tooltip("Cm/s forward")] public Vector3 testVelocity;

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    public bool inPlay;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        audioSource = GetComponent<AudioSource>();
        //Launch(testVelocity);
    }

    public void Launch(Vector3 launchVelocity) {
        rigidBody.useGravity = true;
        rigidBody.velocity = launchVelocity;
        audioSource.Play();
        inPlay = true;
    }

    // Update is called once per frame
    void Update () {
	}

    

}
