﻿using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

	public float paddleSpeed = 1.0f;
	public GameObject ball;

	Vector3 paddleInitialPosition;
	Vector3 ballInitialPossition; 

	// Use this for initialization
	void Start(){
		this.ballInitialPossition = this.ball.gameObject.transform.position;
		this.paddleInitialPosition = this.gameObject.transform.position;
	}
	// Update is called once per frame
	void Update () {
		if (GameController.instance.gamePaused) {
			return;
		}
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
		Vector3 touchWorld = this.gameObject.transform.position;
		if(Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);
			touchWorld = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 37.3f));
			Debug.Log("Touch x: " + touchWorld.x);
		}

		xPos = ((int)touchWorld.x == (int)this.gameObject.transform.position.x)? xPos : touchWorld.x;
		Vector3 playerPos = new Vector3 (Mathf.Clamp (xPos, -14.5f, 14.5f), transform.position.y, 0f);
		Debug.Log("Paddle x: " +playerPos);
		transform.position = playerPos;
	}

	public void ResetToInitialPosition(){
		this.gameObject.transform.position = this.paddleInitialPosition;
		this.ball.gameObject.transform.position = this.ballInitialPossition;
		this.ball.gameObject.transform.parent = this.gameObject.transform;
	}
}
