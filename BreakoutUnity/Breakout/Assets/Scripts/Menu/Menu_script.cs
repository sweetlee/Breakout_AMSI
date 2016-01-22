using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using Assets.Scripts.Database.Models;
using Assets.Scripts.Database.Controllers;

public class Menu_script : MonoBehaviour {

	public Canvas Exit_screen;
	public Canvas Credits_screen;
	public Canvas Options_screen;
	public Canvas Highscores_screen;
	public Canvas Level_selection_screen;

	public Button startText;
	public Button optionsText;
	public Button highscoresText;
	public Button creditsText;
	public Button exitText;

	public AudioSource audio;
	public AudioClip Button_ok;
	public AudioClip Button_no;

	public int level_number;

	//public GameObject audioSource;
	bool soundToggle = true;
    private int controlId = 0;

	void Start()
	{
		Exit_screen.enabled = false;
		Options_screen.enabled = false;
		Credits_screen.enabled = false;
		Highscores_screen.enabled = false;
		Level_selection_screen.enabled = false;

        LoadOptions();
	}

    private void LoadOptions()
    {
        Option sound = OptionFacade.Find(OptionName.Sound);
        bool soundOn = (OnOffOption)sound.Value == OnOffOption.On ? true : false;

        Option control = OptionFacade.Find(OptionName.Controls);
        ControlOption controlId = (ControlOption)control.Value;

        audio.enabled = soundOn;

        Toggle[] optionToggles = Options_screen.GetComponentsInChildren<Toggle>();
        foreach(Toggle t in optionToggles)
        {
            switch(t.name)
            {
                case OptionToggle.Sound:
                    t.isOn = soundOn;
                    break;
                case OptionToggle.Arrow:
                    t.isOn = controlId == ControlOption.Arrows;
                    break;
                case OptionToggle.Paddle:
                    t.isOn = controlId == ControlOption.Paddle;
                    break;
                case OptionToggle.Gyroscope:
                    t.isOn = controlId == ControlOption.Gyroscope;
                    break;
                default:
                    Debug.Log(String.Format("Not set: {0}", t.name));
                    break;
            }
        }
    }

    public void Sound_volume_Control()
	{
		soundToggle = !soundToggle;
		if(soundToggle)
		{
			audio.enabled = true;
		}
		else
		{
			audio.enabled = false;
		}
	}

    public void ControlsToggleControl(int _controlId)
    {
        controlId = _controlId;
    }

    public void ExitPress()
	{

		audio.PlayOneShot(Button_ok);

		Exit_screen.enabled = true;
		startText.enabled = false;
		optionsText.enabled = false;
		creditsText.enabled = false;
		exitText.enabled = false;
		highscoresText.enabled = false;
	}

	public void NoPress()
	{
		audio.PlayOneShot(Button_no);

		Exit_screen.enabled = false;
		startText.enabled = true;
		optionsText.enabled = true;
		creditsText.enabled = true;
		exitText.enabled = true;
		highscoresText.enabled = true;
	}

	public void OptionsPress()
	{
		audio.PlayOneShot(Button_ok);

		Options_screen.enabled = true;
		startText.enabled = false;
		optionsText.enabled = false;
		creditsText.enabled = false;
		exitText.enabled = false;
		highscoresText.enabled = false;
	}

	public void Ok_options_press()
	{
		audio.PlayOneShot(Button_no);

		Options_screen.enabled = false;
		startText.enabled = true;
		optionsText.enabled = true;
		creditsText.enabled = true;
		exitText.enabled = true;
		highscoresText.enabled=  true;

        SaveOptions();
	}

    private void SaveOptions()
    {
        Option sound = OptionFacade.Find(OptionName.Sound);
        sound.Value = audio.enabled ? OnOffOption.On : OnOffOption.Off;

        Option control = OptionFacade.Find(OptionName.Controls);
        control.Value = (ControlOption)controlId;

        OptionFacade.Save(sound);
        OptionFacade.Save(control);
    }

    public void HighscoresPress()
	{
		audio.PlayOneShot(Button_ok);

		Highscores_screen.enabled = true;

		startText.enabled = false;
		optionsText.enabled = false;
		creditsText.enabled = false;
		exitText.enabled = false;
		highscoresText.enabled = false;
	}

	public void HighscoresPress_OK()
	{
		audio.PlayOneShot (Button_no);

		Highscores_screen.enabled = false;

		startText.enabled = true;
		optionsText.enabled = true;
		creditsText.enabled = true;
		exitText.enabled = true;
		highscoresText.enabled = true;
	}

	public void CreditsPress()
	{
		audio.PlayOneShot(Button_ok);

		Credits_screen.enabled = true;
		startText.enabled = false;
		optionsText.enabled = false;
		creditsText.enabled = false;
		exitText.enabled = false;
		highscoresText.enabled = false;
	}

	public void Ok_credits_press()
	{
		audio.PlayOneShot(Button_no);

		Credits_screen.enabled = false;
		startText.enabled = true;
		optionsText.enabled = true;
		creditsText.enabled = true;
		exitText.enabled = true;
		highscoresText.enabled = true;
	}

	public void New_game_press()
	{
		audio.PlayOneShot(Button_ok);

		Level_selection_screen.enabled = true;
		startText.enabled = false;
		optionsText.enabled = false;
		creditsText.enabled = false;
		exitText.enabled = false;
		highscoresText.enabled = false;
	}

	public void New_game_back_press()
	{
		audio.PlayOneShot(Button_no);

		Level_selection_screen.enabled = false;
		startText.enabled = true;
		optionsText.enabled = true;
		creditsText.enabled = true;
		exitText.enabled = true;
		highscoresText.enabled = true;
	}
		
	public void Load_level(int level_number)
	{
		audio.PlayOneShot(Button_ok);

		Application.LoadLevel(level_number);
	}
		
	public void ExitGame()
	{
		audio.PlayOneShot(Button_no);

		Application.Quit();
	}
}
