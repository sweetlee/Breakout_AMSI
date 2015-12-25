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

	public void addScore(){
		score ++;
		scoreText.text = score.ToString ();
	}

	public void restartGame(){
		Application.LoadLevel (Application.loadedLevel);
	}

}
