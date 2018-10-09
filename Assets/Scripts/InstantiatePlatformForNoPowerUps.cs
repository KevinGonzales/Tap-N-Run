using UnityEngine;
using System.Collections;

public class InstantiatePlatformForNoPowerUps :MonoBehaviour {
	
	Camera cam;

	public GameObject[] Background;

	public Transform[] myTransform;
	Transform Platform ;

	Vector3 platformPosition;
	
	GameObject CatchNRunPlatformClone;
	
	static float whatTheCameraHasToBeGreaterThan = 5 ; // 5f
	static float moveUpBy = 2 ;
	
	void Awake()
	{
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if ((cam.transform.position.y + 7) > whatTheCameraHasToBeGreaterThan) 
		{

			whatTheCameraHasToBeGreaterThan += 2f;
			InstantiateAPlatform ();

			moveUpBy += 2;
			CatchNRunPlatformClone = GameObject.FindWithTag("Platform");
		} 
		
		if (CatchNRunPlatformClone != null)
		{
			if (CatchNRunPlatformClone.transform.position.y < (cam.transform.position.y - 6))
			{
				Destroy(CatchNRunPlatformClone);
			}
		}
	}
	
	void InstantiateAPlatform()
	{
		int whatPlatformToInstantiate = 0;
		if (cam.transform.position.y + 5 > 3) 								//grasss					min is inclusive max is exclusive
		{
			whatPlatformToInstantiate = Random.Range (0, 5);

			if(cam.transform.position.y + 5 > 15)							//Ice
			{
				whatPlatformToInstantiate = Random.Range (5, 10);

				if(cam.transform.position.y + 5 > 30)						//Water
				{
					whatPlatformToInstantiate = Random.Range (27,31);

					if(cam.transform.position.y + 5 > 60)					//mars
					{
						whatPlatformToInstantiate = Random.Range (10, 15);

						if(cam.transform.position.y + 5 > 75)				//clouds
						{
							whatPlatformToInstantiate = Random.Range (15, 27);

							if(cam.transform.position.y + 5 > 100){			//random
								whatPlatformToInstantiate = Random.Range (0,31);
							}
						}
					}
				}
			}
		}

		platformPosition = myTransform[whatPlatformToInstantiate].position;
		platformPosition.y += moveUpBy;
		Platform = (Transform)Instantiate (myTransform[whatPlatformToInstantiate], platformPosition,myTransform[whatPlatformToInstantiate].rotation);
		Platform.transform.SetParent (GameObject.Find("PlatformContainer").transform,false);
	}

	public void RestartVariables()
	{
		whatTheCameraHasToBeGreaterThan = 5;
		moveUpBy = 0;
		platformPosition.y = 5; 
	}
}
