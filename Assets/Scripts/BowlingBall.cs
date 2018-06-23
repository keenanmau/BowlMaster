using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour {

    //[Tooltip("Cm/s forward")] //public Vector3 testVelocity;

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    public bool inPlay;
    private Vector3 initialPosition;
    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        audioSource = GetComponent<AudioSource>();
        //Launch(testVelocity);
        initialPosition = transform.position;
    }

    public void Launch(Vector3 launchVelocity) {
        if (!inPlay) {
            rigidBody.useGravity = true;
            rigidBody.velocity = launchVelocity;
            audioSource.Play();
            inPlay = true;
        }
    }

    // Update is called once per frame
    void Update () {
	}
    public void Reset() {
        inPlay = false;
        transform.position = initialPosition;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.useGravity = false;
        


    }



}
