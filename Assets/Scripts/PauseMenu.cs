using UnityEngine;
using System.Collections;

public class PauseMenu : GoogleMobileAdsDemoScript {


	public GameObject PauseMenuPannel;
	public GameObject ResumeButton;
	public GameObject ResumeButtonForOldSchool;
	public GameObject RestartButton;
	public GameObject RestartButtonForOldSchool;
	public GameObject MainMenuButton;
	
	GameObject PauseMenuPannelInstantance;
	GameObject ResumeButtonInstance;
	GameObject resumeButtonForOldSchool;
	GameObject RestartButtonInstance;
	GameObject restartButtonForOldSchool;
	GameObject MainMenuInstannce;


	public void Pauses()
	{
		Time.timeScale = 0;
		PauseMenuPannelInstantance = (GameObject)Instantiate(PauseMenuPannel, PauseMenuPannel.transform.position, Quaternion.identity);	
		PauseMenuPannelInstantance.transform.SetParent (GameObject.Find("Canvas(instantiatesButtons)").transform,false);

		ResumeButtonInstance = (GameObject)Instantiate(ResumeButton, ResumeButton.transform.position, Quaternion.identity);	
		ResumeButtonInstance.transform.SetParent (GameObject.Find("Canvas(instantiatesButtons)").transform,false);

		RestartButtonInstance = (GameObject)Instantiate(RestartButton, RestartButton.transform.position, Quaternion.identity);	
		RestartButtonInstance.transform.SetParent (GameObject.Find("Canvas(instantiatesButtons)").transform,false);

		MainMenuInstannce = (GameObject)Instantiate(MainMenuButton, MainMenuButton.transform.position, Quaternion.identity);	
		MainMenuInstannce.transform.SetParent (GameObject.Find("Canvas(instantiatesButtons)").transform,false);

		GameObject.Find ("Music").GetComponent<AudioSource>().Pause ();
	}

	public void PausesForOldSchool()
	{
		Time.timeScale = 0;
		PauseMenuPannelInstantance = (GameObject)Instantiate(PauseMenuPannel, PauseMenuPannel.transform.position, Quaternion.identity);	
		PauseMenuPannelInstantance.transform.SetParent (GameObject.Find("Canvas(instantiatesButtons)").transform,false);
		
		resumeButtonForOldSchool = (GameObject)Instantiate(ResumeButtonForOldSchool, ResumeButtonForOldSchool.transform.position, Quaternion.identity);	
		resumeButtonForOldSchool.transform.SetParent (GameObject.Find("Canvas(instantiatesButtons)").transform,false);
		
		restartButtonForOldSchool = (GameObject)Instantiate(RestartButtonForOldSchool, RestartButtonForOldSchool.transform.position, Quaternion.identity);	
		restartButtonForOldSchool.transform.SetParent (GameObject.Find("Canvas(instantiatesButtons)").transform,false);
		
		MainMenuInstannce = (GameObject)Instantiate(MainMenuButton, MainMenuButton.transform.position, Quaternion.identity);	
		MainMenuInstannce.transform.SetParent (GameObject.Find("Canvas(instantiatesButtons)").transform,false);
		
	}

	public void Resume()
	{
		if (GameObject.FindGameObjectWithTag ("Player") != null) 
		{
			Time.timeScale = 1;
			Destroy (PauseMenuPannelInstantance, 0);
			Destroy (ResumeButtonInstance, 0);
			Destroy (RestartButtonInstance, 0);
			Destroy (MainMenuInstannce, 0);
			GameObject.Find ("Music").GetComponent<AudioSource>().Play ();
		}
		if (GameObject.FindGameObjectWithTag ("Player") == null) 
		{
			Time.timeScale = 0;
			Destroy (PauseMenuPannelInstantance, 0);
			Destroy (ResumeButtonInstance, 0);
			Destroy (RestartButtonInstance, 0);
			Destroy (MainMenuInstannce, 0);
			GameObject.Find ("Music").GetComponent<AudioSource>().Pause ();
		}
	}

	public void ResumeForOldSchool()
	{
		Time.timeScale = 1;
		Destroy (PauseMenuPannelInstantance,0);
		Destroy (resumeButtonForOldSchool,0);
		Destroy (restartButtonForOldSchool,0);
		Destroy (MainMenuInstannce,0);
	}

	public void Restart()
	{
		Time.timeScale = 1;
		Application.LoadLevel (2);

																				//add to show adds
		if (PlayerPrefs.GetInt ("HasNoAdsBeenBought") <= 0)
		{
			addToTimesPlayed (1);
			if (PlayerPrefs.GetInt ("timesPlayed") >= 5) {
			
				RequestInterstitial ();
				ShowInterstitial ();
				PlayerPrefs.SetInt ("timesPlayed", 0);
			}
		}
	}

	public void RestartForOldSchool()
	{
		Time.timeScale = 1;
		Application.LoadLevel (4);
	}

	public void goToMainMenu()
	{
		Time.timeScale = 1;
		Application.LoadLevel (1);

																				//add to show adds
		addToTimesPlayed (1);
	}

	void addToTimesPlayed(int ThisShouldBeone)
	{
		int timesPlayed = PlayerPrefs.GetInt("timesPlayed",0);    
		PlayerPrefs.SetInt ("timesPlayed", timesPlayed += ThisShouldBeone);
		PlayerPrefs.Save (); 
		print (PlayerPrefs.GetInt("timesPlayed"));
	}
}
