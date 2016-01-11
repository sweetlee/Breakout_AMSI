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
		Vector3 playerPos = new Vector3 (Mathf.Clamp (xPos, -13.0f, 13.0f), transform.position.y, 0f);
		transform.position = playerPos;
	}
}
