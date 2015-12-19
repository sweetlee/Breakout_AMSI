﻿using UnityEngine;
using System.Collections;

public class BallController: MonoBehaviour {

	public float ballInitialVelocity = 600f;
	public GameObject bottomWall;

	private Rigidbody rb;
	private bool ballInPlay = false;

	void Awake () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () 
	{
		if (Input.GetButtonDown("Fire1") && ballInPlay == false)
		{
			transform.parent = null;
			ballInPlay = true;
			rb.isKinematic = false;
			rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
		}
	}

	void OnCollisionEnter(Collision collider){
		if (collider.gameObject.GetComponent<BrickModel>()) {
			Destroy (collider.gameObject);
			GameController.instance.addScore();
		}
		if(collider.gameObject.Equals(bottomWall)){
			GameController.instance.restartGame();
		}

	}
}