using UnityEngine;
using System.Collections;

public class BallController: MonoBehaviour {
	
	public GameObject bottomWall;
	public Rigidbody rb;

	public bool ballInPlay = false;
	public float ballInitialVelocity = 600f;

	void Awake () {
		rb = GetComponent<Rigidbody>();
	}

	public void launchBall() {
		transform.parent = null;
		this.ballInPlay = true;
		this.rb.isKinematic = false;
		this.rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
	}

	void OnCollisionEnter(Collision collider){
		if (collider.gameObject.GetComponent<BrickModel>()) {
			Destroy (collider.gameObject);
			GameController.instance.addScore();
		}
		else if(collider.gameObject.Equals(bottomWall)){
			GameController.instance.restartGame();
		}

	}
}