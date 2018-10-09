using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Movement : MonoBehaviour 
{
	
	public bool canIMove = false;

	static bool dontFrezePlayer = true;
	static bool moveTwiceAsFast = false;
	static bool slowDown = false;

	public GameObject player; 
	public static Vector2 playerPosition;
	public static float playerXPosition ;
	public static float playerYPosition ;

	static float startTime1;
	static float curTime1;

	static float startTime2;
	static float curTime2;

	static float startTime3;
	static float curTime3;
	

	void FixedUpdate() 
	{
		curTime1 = Time.time - startTime1;
		curTime2 = Time.time - startTime2;
		curTime3 = Time.time - startTime3;

		if (curTime1 > 2) 
		{
			dontFrezePlayer = true;
		}

		if (curTime2 > 2)
		{
			moveTwiceAsFast = false;
		}

		if (curTime3 > 2)
		{
			slowDown = false;
		}

		if(dontFrezePlayer)
		{
			int fingerCount = 0;
			foreach (Touch touch in Input.touches)
			{
				if (touch.phase != TouchPhase.Canceled && touch.phase == TouchPhase.Began)
					fingerCount++;
			
			}
			if (fingerCount > 0) 
			{
				canIMove = true;
			}

			if (canIMove)
			{
				if(!moveTwiceAsFast && !slowDown)
				{
					Move (.5f);
					canIMove = false;
				}

				if(moveTwiceAsFast)
				{
					Move (1f);
					canIMove = false;
				}
				if(slowDown)
				{
					Move (.25f);
					canIMove = false;
				}
			}
		}
		
	}

	void Awake()
	{
		
		player = GameObject.FindGameObjectWithTag("Player");
		playerPosition = player.transform.position;
		playerXPosition = playerPosition.x;
		playerYPosition = playerPosition.y;
	}
	
	public void Move(float moveBy)
	{
			playerXPosition += moveBy;
			transform.position = new Vector2 (playerXPosition, playerYPosition);
			if (playerXPosition > 3.7) 
			{
				MoveToNextPlatform ();
			}
	}


	public void MoveToNextPlatform()
	{
		playerYPosition += 2f;
		playerXPosition = -3.3f;
		transform.position = new Vector2 (playerXPosition,playerYPosition);
	}

	//links up to powerup functions

	public static void PlayerFrozen ()
	{
		startTime1 = Time.time;
		
		dontFrezePlayer = false;
	}

	public static void PlayerDoubleSpeed ()
	{
		startTime2 = Time.time;
		
		moveTwiceAsFast = true;
	}

	public static void PlayerSlowsDown ()
	{
		startTime3 = Time.time;
		
		slowDown = true;
	}
}
