using UnityEngine;
using System.Collections;

public class InstantiaiteStore : MonoBehaviour
{
	public GameObject StoreBackground;

	GameObject storeBackground;

		
		
	public void LaunchStore()
	{
		storeBackground = (GameObject)Instantiate (StoreBackground, StoreBackground.transform.position, StoreBackground.transform.rotation);
		storeBackground.transform.SetParent (GameObject.Find("Canvas").transform,false);
	}

	public void CloseStore()
	{
		Destroy (storeBackground.gameObject);
	}

}
