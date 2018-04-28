﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour {

    [Tooltip("Cm/s forward")] public Vector3 launchVelocity;
    private Rigidbody rigidBody;
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        Launch();
    }

    public void Launch() {
        rigidBody.velocity = launchVelocity;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
	}


}