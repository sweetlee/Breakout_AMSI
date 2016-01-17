using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Database.Models;
using Assets.Scripts.Database.Controllers;

public class HighScoreListController : MonoBehaviour
{
    public Text HighScoreList;

	// Use this for initialization
	void Start () {

        //TestHighScore();

        //Highscore test = HighscoreFacade.FindAll()[0];
        //Debug.Log(test.ToString());
        HighScoreList.text = HighscoreFacade.ToStringAll();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void TestHighScore()
    {
        Highscore score = new Highscore() { Name = "Test", Score = (int)(Random.value * 1000) };
        HighscoreFacade.Insert(score);
    }
}
