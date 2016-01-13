using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public BallController ballController;
	public PaddleController paddleController;

	public int score;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		instance = this;
		scoreText.text = score.ToString ();
	}

	public void Update () {
		if (Input.GetButtonDown("Fire1") && ballController.ballInPlay == false){
			Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayHit;
			if(Physics.Raycast(mouseRay, out rayHit)){
				if(rayHit.collider.gameObject.layer == 5){
					return;
				}
			}
			ballController.launchBall();
		}
	}

	public void settingsTapped(){
		Debug.Log("SettingsTapped!!");
	}

	public void addScore(){
		score ++;
		scoreText.text = score.ToString ();
	}

	public void restartGame(){
		Application.LoadLevel (Application.loadedLevel);
	}

}
