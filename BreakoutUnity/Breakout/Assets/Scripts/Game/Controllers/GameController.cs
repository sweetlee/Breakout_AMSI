using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public List<GameObject> bricksLeft;
	public List<GameObject> hitpointsLeft;

	public BallController ballController;
	public PaddleController paddleController;
	public AudioSource audioSource;

	public GameObject hitpointsParent;
	public GameObject brickParent;
	public GameObject menuPanel;
	public GameObject dimmer;

	public GameObject musicCheckBox;

	public bool gamePaused = false;
	public bool musicPlaying = true;
	public bool menuShown = false;

	public int hitPoints;

	public int score;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		instance = this;
		scoreText.text = score.ToString ();
		this.setupBricks();
		this.setupHitPoints();

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

	void setupBricks(){
		this.bricksLeft = new List<GameObject>();
		for(int i = 0; i<brickParent.transform.childCount; i++){
			GameObject brick = brickParent.transform.GetChild(i).gameObject;
			if(brick.GetComponent<BrickModel>() && brick.activeInHierarchy){
				this.bricksLeft.Add(brick);
			}
		}
	}

	void setupHitPoints(){
		
	}

	public void tooglePauseGame(){
		this.gamePaused = !this.gamePaused;
		this.ballController.rb.isKinematic = this.gamePaused;
		if(!this.ballController.rb.isKinematic && this.ballController.ballInPlay){
			this.ballController.launchBall();
		}
	}
	public void toogleMusic(){
		this.musicPlaying = !this.musicPlaying;
		if(this.musicPlaying){
			this.audioSource.Play();
		}else{
			this.audioSource.Pause();
		}
		this.musicCheckBox.SetActive(this.musicPlaying);
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

	public void brickHit(GameObject brick){
		BrickModel brickModel = brick.GetComponent<BrickModel>();
		brickModel.brickHitPoints--;
		if(brickModel.brickHitPoints == 0){
			this.bricksLeft.Remove(brick);
			Destroy(brick);
			this.addScore();

			if(this.playerWon()){
				this.tooglePauseGame();
				this.dimmer.SetActive(true);
			}
		} else {
			brickModel.updateColor();
		}
	}

	public void addScore(){
		score ++;
		scoreText.text = score.ToString ();
	}

	public bool playerWon(){
		return (this.bricksLeft.Count == 0);
	}

	public void playerShouldLoseHitPoint(){
		
	}

	public void restartGame(){
		Application.LoadLevel (Application.loadedLevel);
	}
	public void backToMenu(){
		SceneManager.LoadScene("menu");
	}

}
