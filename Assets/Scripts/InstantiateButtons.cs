using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class InstantiateButtons : MonoBehaviour {

    Image trapButton;

	public Image[] prefab;

	Vector3 buttonPosition;
	Vector3[] positionArray;

	int randomNumberForButtonPosition;
	int randomNumberForPrefab;
	int lastPrefab;

	bool spawning = false;
	float timer = 0; 


	// Use this for initialization
	void Awake()
	{
		positionArray = new [] { new Vector3(0f,0f,1f), new Vector3(0f,285f,1f),new Vector3(0f,-285f,1f),new Vector3(285,0f,1f)
								,new Vector3(285f,285f,1f),new Vector3(285f,-285f,1f)};

		randomNumberForButtonPosition = positionArray.Length;
		buttonPosition = positionArray[Random.Range(0,randomNumberForButtonPosition)];

		randomNumberForPrefab = prefab.Length - 1;											//subtracting one because the last prefab is only being used to show the warning
		lastPrefab = prefab.Length -1;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		if(!spawning)
		{
			timer += Time.deltaTime;
		}

		if (timer >= .5) // was 1
		{
			warning();
			if (timer >= 1)
			{
			RandomTrapButtons ();
			buttonPosition = positionArray [Random.Range (0, randomNumberForButtonPosition)];
			}
		}
	}

	void RandomTrapButtons()
	{
		spawning = true;
		timer = 0;

		trapButton = (Image)Instantiate(prefab[Random.Range(0,randomNumberForPrefab)], buttonPosition, Quaternion.identity);

		if (GameObject.Find ("Canvas(instantiatesButtons)") != null) 
		{
			trapButton.transform.SetParent (GameObject.Find("Canvas(instantiatesButtons)").transform,false);
		}
		if (GameObject.Find ("CanvasGoodPowerUpsOnly(Clone)") != null) 
		{
			trapButton.transform.SetParent (GameObject.Find("CanvasGoodPowerUpsOnly(Clone)").transform,false);
		}

		Destroy (trapButton.gameObject, .5f);

		spawning = false;
	}

	void warning()
	{
		Image WarningButton = (Image)Instantiate(prefab[lastPrefab], buttonPosition, Quaternion.identity);
		if (GameObject.Find ("Canvas(instantiatesButtons)") != null) 
		{
			WarningButton.transform.SetParent (GameObject.Find("Canvas(instantiatesButtons)").transform,false);
		}
		if (GameObject.Find ("CanvasGoodPowerUpsOnly(Clone)") != null) 
		{
			WarningButton.transform.SetParent (GameObject.Find("CanvasGoodPowerUpsOnly(Clone)").transform,false);
		}

		Destroy (WarningButton.gameObject, .01f);
	}
}
 