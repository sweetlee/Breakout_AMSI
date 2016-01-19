using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public BallController ballController;
	public PaddleController paddleController;
	public GameObject menuPanel;
	public GameObject dimmer;

	public bool gamePaused = false;
	public bool menuShown = false;


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

	public void tooglePauseGame(){
		this.gamePaused = !this.gamePaused;
		this.ballController.rb.isKinematic = this.gamePaused;
		if(!this.ballController.rb.isKinematic){
			this.ballController.launchBall();
		}
	}

	public void settingsTapped(){
		this.menuShown = !this.menuShown;
		this.dimmer.SetActive(this.menuShown);
		this.tooglePauseGame();
		if(this.menuShown){
			iTween.MoveTo(menuPanel, new Vector3(0, 2,-10), 0.5f);
		} else {
			iTween.MoveTo(menuPanel, new Vector3(0, 17.54f,-10), 0.5f);
		}
	}

	public void addScore(){
		score ++;
		scoreText.text = score.ToString ();
	}

	public void restartGame(){
		Application.LoadLevel (Application.loadedLevel);
	}

}
