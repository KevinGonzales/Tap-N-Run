using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class watchAVideoForCoins : MonoBehaviour 
{

	void Awake()
	{
		if (Advertisement.isSupported) 
		{
			Advertisement.allowPrecache = true;
			Advertisement.Initialize("73973",false);
		}
	}

	public void  WatchAVideoFroCoins()
	{
		Advertisement.Show ("rewardedVideoZone", new ShowOptions {
			pause = true,
			resultCallback = result => {
				int oldCurrency = PlayerPrefs.GetInt("Currency",0);    
				PlayerPrefs.SetInt ("Currency", oldCurrency += Random.Range(1,4));
				PlayerPrefs.Save (); 
			}
		});
	}
}