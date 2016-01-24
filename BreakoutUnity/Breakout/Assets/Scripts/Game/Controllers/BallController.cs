using UnityEngine;
using System.Collections.Generic;

public class BallController: MonoBehaviour {
	
	public GameObject bottomWall;
	public Rigidbody rb;


	public bool ballInPlay = false;
	public float ballInitialVelocity = 600f;

	public void launchBall() {
		transform.parent = null;
		this.ballInPlay = true;
		this.rb.isKinematic = false;
		this.rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
	}

	void OnCollisionEnter(Collision collider){
		if (collider.gameObject.GetComponent<BrickModel>()) {
			GameController.instance.brickHit(collider.gameObject);
		}
		else if(collider.gameObject.Equals(bottomWall)){
			GameController.instance.playerShouldLoseHitPoint();
		}

	}
}