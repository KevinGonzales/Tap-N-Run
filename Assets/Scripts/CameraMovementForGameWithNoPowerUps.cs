using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraMovementForGameWithNoPowerUps : MonoBehaviour {

	static int scoreNumber;

	public GameObject HighScoreImage;
	public GameObject NewScoreStarsImage;
	public Text BestScore;
	public Text RecentScore;

	public float speed;
	static Vector3 movement; 
	GameObject player; 

	public float TopcameraYPosition;
	public float BottomCameraYPosition;
	static Vector3 cameraPosition ;

	public Text Score;
	public Text Money;


	static bool dontFreezecamera = true;
	static float startTime;
	static float curTime;

	void Awake () 
	{
		cameraPosition = gameObject.transform.position;
		movement = Vector3.zero; 
		player = GameObject.FindGameObjectWithTag ("Player");
		TopcameraYPosition = cameraPosition.y + 5;
		BottomCameraYPosition = cameraPosition.y - 5;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float curTime = Time.time - startTime;

		if (curTime > 2) 
		{
			dontFreezecamera = true;
		}

		if(dontFreezecamera)
		{
			MoveCamera();
		}
		
		if (player != null) 
		{

			Vector3 startOfLineTop = new Vector3(-2, TopcameraYPosition ,gameObject.transform.position.z);
			Vector3 endOfLineTop = new Vector3 (2,TopcameraYPosition,gameObject.transform.position.z);

			Vector3 startOfLineBotom = new Vector3(-2, BottomCameraYPosition ,gameObject.transform.position.z);
			Vector3 endOfLineBotom = new Vector3 (2,BottomCameraYPosition,gameObject.transform.position.z);

			Debug.DrawLine (startOfLineTop,endOfLineTop,Color.red);
			Debug.DrawLine (startOfLineBotom,endOfLineBotom,Color.red);

			if (BottomCameraYPosition > player.transform.position.y) 
			{
				LostGame ();
			}

			if (TopcameraYPosition < player.transform.position.y) 
			{
				MoveCameraWhenPlayerIsABoveIt();
			}
			if(TopcameraYPosition > player.transform.position.y)
			{
				if(dontFreezecamera)
				{
					MoveCamera();
				}
			}

			scoreNumber = (int)(player.transform.position.y + 2.41) / 2;
			if (scoreNumber >= 0)
			{
				Score.text = scoreNumber.ToString ();
			}
			if(scoreNumber < 0 )
			{
				Score.text = "0";
			}
		}
	}

	void LostGame()
	{
		GameObject highscoreImage = (GameObject)Instantiate (HighScoreImage,HighScoreImage.transform.position,Quaternion.identity);
		highscoreImage.transform.SetParent (GameObject.Find("Canvas(instantiatesButtons)").transform,false); 

		Text recentScore = (Text)Instantiate (RecentScore,RecentScore.transform.position,Quaternion.identity);
		recentScore.transform.SetParent (GameObject.Find("highScoreList(Clone)").transform,false); 

		Text bestScore = (Text)Instantiate (BestScore,BestScore.transform.position,Quaternion.identity);
		bestScore.transform.SetParent (GameObject.Find("highScoreList(Clone)").transform,false); 

		recentScore.text = scoreNumber.ToString ();
		StoreHighscore (scoreNumber);
		bestScore.text = PlayerPrefs.GetInt("highscoreForNoPowerUps").ToString(); 


		Destroy (player);

		//curency for when the player loses 

		int moneyGained = 0;
		if (scoreNumber >0) 
		{
			moneyGained = 1;

			if (scoreNumber > 15) 
			{
				moneyGained = 2;

				if (scoreNumber > 30) 
				{
					moneyGained = 3;

					if (scoreNumber > 45) 
					{
						moneyGained = 4;

						if (scoreNumber > 60) 
						{
							moneyGained = 5;
							if (scoreNumber > 75) 
							{
								moneyGained = 6;

								if (scoreNumber > 90) 
								{
									moneyGained = 7;

									if (scoreNumber > 100) 
									{
										moneyGained = 8;
									}
								}
							}
						}
					}
				}
			}
		}

		//StoreCurrency (moneyGained);
	}

	void MoveCamera()
	{
		movement.y += speed *.00001f;
		transform.Translate (movement);
		TopcameraYPosition += movement.y;
		BottomCameraYPosition += movement.y;
	}


	void MoveCameraWhenPlayerIsABoveIt()
	{
		Vector3 cameraPositiontogoto = new Vector3(cameraPosition.x, cameraPosition.y += 3 , cameraPosition.z); 
		cameraPosition = Vector3.Lerp(transform.position, cameraPositiontogoto, .1f);

		gameObject.transform.position = cameraPosition ;
		TopcameraYPosition = cameraPosition.y + 5;
		BottomCameraYPosition = cameraPosition.y - 5;
	}

	public void CameraStill ()
	{
		startTime = Time.time;

		dontFreezecamera = false;
	}
	void StoreHighscore(int newHighscore)
	{
		int oldHighscore = PlayerPrefs.GetInt("highscoreForNoPowerUps",0);    
		if (newHighscore > oldHighscore) 
		{
			PlayerPrefs.SetInt ("highscoreForNoPowerUps", newHighscore);
			PlayerPrefs.Save ();
			GameObject newScore = (GameObject)Instantiate (NewScoreStarsImage,NewScoreStarsImage.transform.position,NewScoreStarsImage.transform.rotation);
			newScore.transform.SetParent (GameObject.Find("highScoreList(Clone)").transform,false); 
		}
	}

	void StoreCurrency(int Currency)
	{
		int oldCurrency = PlayerPrefs.GetInt("Currency",0);    
		PlayerPrefs.SetInt ("Currency", oldCurrency += Currency);
		PlayerPrefs.Save (); 
	}
	
}
