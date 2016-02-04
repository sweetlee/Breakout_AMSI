using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using Assets.Scripts.Database.Controllers;
using Assets.Scripts.Database.Models;
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
	public GameObject gameOverDialog;
	public GameObject levelCompletedDialog;
	public GameObject dimmer;

	public GameObject musicCheckBox;

	public bool gamePaused = false;
	public bool musicPlaying = true;
	public bool menuShown = false;

	public int hitPoints;

	public int score;

	public Text scoreText;
	public Text userName;

	public List<Option> playerOption;


	// Use this for initialization
	void Start () {
		instance = this;
		this.playerOption = new List<Option> ();
		playerOption = OptionFacade.FindAll ();

		scoreText.text = score.ToString ();
		this.setupBricks();
		this.setupHitPoints();
		this.setupOptions();

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
			Debug.Log(EditorSceneManager.loadedSceneCount);
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
		this.hitpointsLeft = new List<GameObject> ();
		for(int i = 0; i < this.hitpointsParent.transform.childCount; i++){
			GameObject hitPoint = this.hitpointsParent.transform.GetChild(i).gameObject;
			if(hitPoint.activeInHierarchy){
				this.hitpointsLeft.Add (hitPoint);
			}
		}
		this.hitPoints = this.hitpointsLeft.Count;
	}

	void setupOptions(){
		for (int i = 0; i < this.playerOption.Count; i++) {
			Option option = this.playerOption[i];
			if(option.Name == OptionName.Sound){
				Debug.Log("Sound: " + option.Value);
				if((OnOffOption)option.Value == OnOffOption.Off){
					this.toogleMusic();
				}
			}
		}
	}

	void takePlayerHitpoint(){
		for(int i = 0; i < this.hitpointsLeft.Count; i++){
			GameObject hitpoint = this.hitpointsParent.transform.GetChild(i).gameObject;
			if(hitpoint.activeInHierarchy){
				hitpoint.SetActive(false);
				return;
			}
		}
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
	public void showGameOverDialog(){
		this.dimmer.SetActive (true);
		iTween.MoveTo(this.gameOverDialog, new Vector3(0, 2,-10), 0.5f);
	}
	public void showLevelCompletedDialog(){
		this.dimmer.SetActive (true);
		iTween.MoveTo(this.levelCompletedDialog, new Vector3(0, 2,-10), 0.5f);
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
				this.showLevelCompletedDialog();
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
		this.hitPoints--;
		this.takePlayerHitpoint ();
		if (this.hitPoints == 0) {
			this.tooglePauseGame();
			this.showGameOverDialog();
		} else {
			this.paddleController.ResetToInitialPosition ();
			this.ballController.ballInPlay = false;
			this.ballController.rb.isKinematic = true;
		}
	}


	public void goToNextLevel(){
		int sceneToLoad = EditorSceneManager.loadedSceneCount + 1;
		EditorSceneManager.LoadScene(sceneToLoad);
	}
	public void restartGame(){
		Application.LoadLevel (Application.loadedLevel);
	}
	public void backToMenu(){
		Application.LoadLevel ("menu");
	}
	public void saveUserAndBackToMenu(){
		HighscoreFacade.Save (this.userName.text, this.score);
		this.backToMenu ();
	}

}
