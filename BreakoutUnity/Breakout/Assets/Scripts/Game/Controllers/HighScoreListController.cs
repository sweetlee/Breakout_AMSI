using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Database.Models;
using Assets.Scripts.Database.Controllers;
using System.Collections.Generic;

public class HighScoreListController : MonoBehaviour
{
    public VerticalLayoutGroup Names;
    public VerticalLayoutGroup Scores;

	// Use this for initialization
	void Start () {

        //HighscoreFacade.InsertTestHighScore();

        FillHigscore();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void FillHigscore()
    {
        List<Highscore> highscores = HighscoreFacade.FindBest10();

        //Debug.Log(HighscoreFacade.ToStringAll());

        int count = highscores.Count <= 10 ? highscores.Count : 10;

        for (int i = 0; i < count ; i++)
        {
            //Debug.Log("i=" + i);
            Names.GetComponentsInChildren<Text>()[i].text = highscores[i].Name;
            Scores.GetComponentsInChildren<Text>()[i].text = highscores[i].Score.ToString();
        }
    }
}
