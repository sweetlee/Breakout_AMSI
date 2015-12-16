using UnityEngine;
using System.Collections;

public class PaddleModel : MonoBehaviour {

	public bool canMove = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter(){
		Debug.Log("HUJ");
		canMove = false;
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("Cipa");
		canMove = false;
	}

	void OnTriggerExit(Collider other) {
		Debug.Log (other);
		canMove = true;
	}
}
