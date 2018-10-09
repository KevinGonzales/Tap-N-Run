using UnityEngine;
using System.Collections;

public class SocialMedia : MonoBehaviour {

	public void OnRateButtonClick(){
		#if UNITY_ANDROID
		Application.OpenURL("market://details?id=YOUR_APP_ID");
		#elif UNITY_IPHONE
		Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_APP_ID");
		#endif
	}

}
