using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class sampleAppScript : MonoBehaviour {

	private string AdAnalyticsConvertionId = "";

	private bool isInitialize = false;

	// Use this for initialization
	void Start () {

		if (!isInitialize) {
			isInitialize = true;

			#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IPHONE)
				AdAnalyticsConvertionId = "";
			//// iOS
			#elif UNITY_IPHONE && !UNITY_EDITOR
				AdAnalyticsConvertionId = "a1349fe6da5c145d748a72ff4b07d10b";
			//// Android
			#elif UNITY_ANDROID && !UNITY_EDITOR
				AdAnalyticsConvertionId = "a1349fe6da5c145d748a72ff4b07d10b";
			#endif
				
			// FSAdNetwork Analytics & Option
			FSAdNetwork.analyticsDebugLogEnable(true);
			FSAdNetwork.analyticsConversion(AdAnalyticsConvertionId);

			FSAdNetwork.OnFinishedConversionFSAdAnalytics += OnFinishedConversionFSAdAnalytics;
			FSAdNetwork.OnFailedConversionFSAdAnalytics += OnFailedConversionFSAdAnalytics;


			FSAdNetwork.debugLogEnable(true);
			FSAdNetwork.testModeEnable (false);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnDestroy() {
		Debug.Log ("sampleAppScript - OnDestroy");

		FSAdNetwork.OnFinishedConversionFSAdAnalytics -= OnFinishedConversionFSAdAnalytics;
		FSAdNetwork.OnFailedConversionFSAdAnalytics -= OnFailedConversionFSAdAnalytics;
	}


	// Delegate
	private void OnFinishedConversionFSAdAnalytics() {
		Debug.Log ("sampleAppScript - OnFinishedConversionFSAdAnalytics");

	}
	private void OnFailedConversionFSAdAnalytics() {
		Debug.Log ("sampleAppScript - OnFailedConversionFSAdAnalytics");

	}


	public void button_banner () {
		Debug.Log ("button banner");
//			SceneManager.LoadScene ("bannerScene");
			Application.LoadLevel ("bannerScene");
	}

	public void button_doubleBanner () {
		Debug.Log ("button Double Banner");
//			SceneManager.LoadScene ("doubleBannerScene");
			Application.LoadLevel ("doubleBannerScene");
	}

	public void button_twinPanel () {
		Debug.Log ("button Twin Panel");
//			SceneManager.LoadScene ("twinPanelScene");
			Application.LoadLevel ("twinPanelScene");
	}

	public void button_rectangleBanner () {
		Debug.Log ("button Rectangle Banner");
//			SceneManager.LoadScene ("rectangleBannerScene");
			Application.LoadLevel ("rectangleBannerScene");
	}

	public void button_interstitial () {
		Debug.Log ("button interstitial");
//			SceneManager.LoadScene ("interstitialScene");
			Application.LoadLevel ("interstitialScene");
	}

	public void button_popup () {
		Debug.Log ("button popup");
//			SceneManager.LoadScene ("popupScene");
			Application.LoadLevel ("popupScene");
	}

	public void button_slidein () {
		Debug.Log ("button SlideIn");
//			SceneManager.LoadScene ("slideinScene");
			Application.LoadLevel ("slideinScene");
	}

	public void button_pip () {
		Debug.Log ("button PiP");
//			SceneManager.LoadScene ("pipScene");
			Application.LoadLevel ("pipScene");
	}

	public void button_forcedmovie () {
		Debug.Log ("button ForcedMovie");
//			SceneManager.LoadScene ("forcedMovieScene");
			Application.LoadLevel ("forcedMovieScene");
	}

}
