using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class PowerUps : Movement
{
	public GameObject MoreCoins;
	GameObject moreCoins;

	public GameObject iceWhenPlayerIsFrozen; 
	GameObject freeze;

	public GameObject iceWhenCameraIsFrozen;
	GameObject iceAroundTheCamera;

	public GameObject thingThatSlowsPersonDown;
	GameObject giantballthing;

	public GameObject Teleporter;
	GameObject teleporterThatWillBeDestroyed;

	public GameObject TeleporterForFalling;
	GameObject teleporterThatWillBeDestroyedforFalling;

	public GameObject Dashes;
	GameObject coloredDashes;

	static bool doublespeed; 
	static bool jump;
	static bool freezeCamera;
	static bool goDown;
	static bool freezePlayer;
	static bool slowDown;
	static bool superJumpThing;
	static bool playerGetsMoreCoins;


	CameraMovement cameraMovement = new CameraMovement ();

	void FixedUpdate()
	{	
		if (doublespeed) 
		{
			PlayerDoubleSpeed();
			coloredDashes = (GameObject)Instantiate(Dashes,Dashes.transform.position,Quaternion.identity);
			coloredDashes.transform.SetParent (GameObject.FindGameObjectWithTag("Player").transform,false);
			GetComponent<AudioSource>().Play();
			Destroy(coloredDashes,2f);

			doublespeed= false;
		}
		if(jump)
		{
			JumpNextPlatform();
			teleporterThatWillBeDestroyed = (GameObject)Instantiate(Teleporter,Teleporter.transform.position,Quaternion.identity);
			teleporterThatWillBeDestroyed.transform.SetParent (GameObject.FindGameObjectWithTag("Player").transform,false);
			Destroy(teleporterThatWillBeDestroyed,.5f);
			GetComponent<AudioSource>().Play();
			
			jump = false;
		}
		if (freezeCamera)
		{
			iceAroundTheCamera = (GameObject) Instantiate(iceWhenCameraIsFrozen,iceWhenCameraIsFrozen.transform.position,Quaternion.identity);
			iceAroundTheCamera.transform.SetParent (GameObject.FindGameObjectWithTag("MainCamera").transform,false); 
			cameraMovement.CameraStill();
			Destroy(iceAroundTheCamera,2);

			GetComponent<AudioSource>().Play();

			freezeCamera = false; 
		}
		if (goDown)
		{
			MoveToBotomPlatform();
			teleporterThatWillBeDestroyedforFalling = (GameObject)Instantiate(TeleporterForFalling,TeleporterForFalling.transform.position,Quaternion.identity);
			teleporterThatWillBeDestroyedforFalling.transform.SetParent (GameObject.FindGameObjectWithTag("Player").transform,false);
			GetComponent<AudioSource>().Play();
			Destroy(teleporterThatWillBeDestroyedforFalling,.5f);

			goDown = false;
		}
		if(freezePlayer)
		{
			PlayerFrozen();
			freeze = (GameObject)Instantiate(iceWhenPlayerIsFrozen,iceWhenPlayerIsFrozen.transform.position,Quaternion.identity);
			freeze.transform.SetParent (GameObject.FindGameObjectWithTag("Player").transform,false);
			GetComponent<AudioSource>().Play();
			Destroy(freeze,2f);

			freezePlayer = false;
		}
		if (slowDown)
		{
			PlayerSlowsDown();
			giantballthing = (GameObject)Instantiate(thingThatSlowsPersonDown,thingThatSlowsPersonDown.transform.position,Quaternion.identity);
			giantballthing.transform.SetParent (GameObject.FindGameObjectWithTag("Player").transform,false);
			GetComponent<AudioSource>().Play();
			Destroy(giantballthing,2f);

			slowDown = false;
		}
		if (superJumpThing) 
		{
			SecretSupperJump();
			teleporterThatWillBeDestroyed = (GameObject)Instantiate(Teleporter,Teleporter.transform.position,Quaternion.identity);
			teleporterThatWillBeDestroyed.transform.SetParent (GameObject.FindGameObjectWithTag("Player").transform,false);
			Destroy(teleporterThatWillBeDestroyed,1f);
			GetComponent<AudioSource>().Play();
			
			superJumpThing = false;
		}
		if (playerGetsMoreCoins)
		{
			GivingPlayerMoreCOins();

			moreCoins = (GameObject) Instantiate(MoreCoins,MoreCoins.transform.position,Quaternion.identity);
			moreCoins.transform.SetParent (GameObject.FindGameObjectWithTag("Player").transform,false); 
			GetComponent<AudioSource>().Play();
			Destroy(moreCoins,1);

			playerGetsMoreCoins = false;
		}
	}





	public void DoubleSpeed()
	{
		doublespeed = true;
	}

	public void JumpToNextPlatform()
	{
		jump = true; 
	}

	public void FreezeCamera()
	{
		freezeCamera = true;
	}
	public void GoDown()
	{
		goDown = true;
	}
	public void FreezePlayer()
	{
		freezePlayer = true;
	}
	public void SlowDown()
	{
		slowDown = true;
	}
	public void SuperSecretJump()
	{
		superJumpThing = true;
	}
	public void GivePlayerMoreCoins()
	{
		playerGetsMoreCoins = true;
	}


	void JumpNextPlatform()
	{
		playerYPosition += 2f;
		playerXPosition =  playerPosition.x;
		transform.position = new Vector2 (playerXPosition,playerYPosition);
	}

	void SecretSupperJump()
	{
		playerYPosition += 20f;
		playerXPosition =  playerPosition.x;
		transform.position = new Vector2 (playerXPosition,playerYPosition); 
	}

	void MoveToBotomPlatform()
	{
		playerYPosition -= 2f;
		playerXPosition = playerPosition.x;
		transform.position = new Vector2 (playerXPosition,playerYPosition);
	}

	void GivingPlayerMoreCOins()
	{   
		int amountTOIncreaseBy = Random.Range(1,3);
		int Currency = PlayerPrefs.GetInt ("Currency");
		PlayerPrefs.SetInt ("Currency", Currency += amountTOIncreaseBy);
		PlayerPrefs.Save (); 
	}
}
