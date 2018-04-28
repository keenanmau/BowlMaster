using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour {

    [Tooltip("Cm/s forward")] public float launchVelocity;
    private Rigidbody rigidBody;
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        Launch();
    }

    public  void Launch() {
        rigidBody.velocity = new Vector3(0, 0, launchVelocity);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
	}


}
