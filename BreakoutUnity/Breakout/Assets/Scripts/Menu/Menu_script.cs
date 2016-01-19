using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts.Database.Controllers;
using Assets.Scripts.Database.Models;

public class Menu_script : MonoBehaviour {

	public Canvas Exit_screen;
	public Canvas Credits_screen;
	public Canvas Options_screen;

	public Button startText;
	public Button optionsText;
	public Button creditsText;
	public Button exitText;

	public AudioSource audio;
	public AudioClip Button_ok;
	public AudioClip Button_no;

	public GameObject audioSource;
	bool soundToggle = true;

	void Start()
	{
		Exit_screen.enabled = false;
		Options_screen.enabled = false;
		Credits_screen.enabled = false;

		startText = startText.GetComponent<Button>();
		optionsText = optionsText.GetComponent<Button>();
		creditsText = creditsText.GetComponent<Button>();
		exitText = exitText.GetComponent<Button>();

        LoadOptions();
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

	public void ExitPress()
	{

		audio.PlayOneShot(Button_ok);

		Exit_screen.enabled = true;
		startText.enabled = false;
		optionsText.enabled = false;
		creditsText.enabled = false;
		exitText.enabled = false;
	}

	public void NoPress()
	{
		audio.PlayOneShot(Button_no);

		Exit_screen.enabled = false;
		startText.enabled = true;
		optionsText.enabled = true;
		creditsText.enabled = true;
		exitText.enabled = true;
	}

	public void OptionsPress()
	{
		audio.PlayOneShot(Button_ok);

		Options_screen.enabled = true;
		startText.enabled = false;
		optionsText.enabled = false;
		creditsText.enabled = false;
		exitText.enabled = false;
	}

	public void Ok_options_press()
	{
		audio.PlayOneShot(Button_no);

		Options_screen.enabled = false;
		startText.enabled = true;
		optionsText.enabled = true;
		creditsText.enabled = true;
		exitText.enabled = true;

        Option sound = OptionFacade.Find(OptionName.Sound);
        sound.Value = audio.enabled ? OnOffOption.On : OnOffOption.Off;
        OptionFacade.Save(sound);
    }

	public void CreditsPress()
	{
		audio.PlayOneShot(Button_ok);

		Credits_screen.enabled = true;
		startText.enabled = false;
		optionsText.enabled = false;
		creditsText.enabled = false;
		exitText.enabled = false;
	}

	public void Ok_credits_press()
	{
		audio.PlayOneShot(Button_no);

		Credits_screen.enabled = false;
		startText.enabled = true;
		optionsText.enabled = true;
		creditsText.enabled = true;
		exitText.enabled = true;
	}
		
	public void LoadScene()
	{
		audio.PlayOneShot(Button_ok);

		Application.LoadLevel(0);
	}

	public void ExitGame()
	{
		audio.PlayOneShot(Button_no);

		Application.Quit();
	}

    private void LoadOptions()
    {
        Facade<Option>.ToStringAll();
        Option sound = OptionFacade.Find(OptionName.Sound);
        Debug.Log(sound.ToString());

        audio.enabled =
            (OnOffOption)sound.Value == OnOffOption.On ? true : false;
    }
}
