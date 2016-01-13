using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

	public float paddleSpeed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
		Vector3 touchWorld = new Vector3 (0,0,0);
		if(Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);
			touchWorld = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 37.3f));
			Debug.Log("Touch x: " + touchWorld.x);
		}
		Vector3 playerPos = new Vector3 (Mathf.Clamp (touchWorld.x, -13.0f, 13.0f), transform.position.y, 0f);
		Debug.Log("Paddle x: " +playerPos);
		transform.position = playerPos;
	}


}
