using UnityEngine;
using System.Collections;

public class GoToScripts : MonoBehaviour {

	// Use this for initialization
	public void goToOutrunCamera () 
	{
		Load.show();
		Application.LoadLevel (2);
	}
	public void goToCharacterSelect()
	{
		Load.show();
		Application.LoadLevel (4);
	}
	public void goToMainMenu()
	{
		Load.show();
		Application.LoadLevel (1);
	}
	public void goToGameWithNoPowerUps()
	{
		Load.show();
		Application.LoadLevel (5);
	}

	public void goToStore()
	{
		Load.show();
		Application.LoadLevel (3);
	}
}
