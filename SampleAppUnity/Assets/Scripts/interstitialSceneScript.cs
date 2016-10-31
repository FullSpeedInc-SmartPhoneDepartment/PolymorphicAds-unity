using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class interstitialSceneScript : MonoBehaviour {

	public Text stateText;
	private string AdInterstitialUnitId = "";
	private bool isAdShow = false;

	// Use this for initialization
	void Start () {
		Debug.Log ("interstitialScene - Start");

		#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IPHONE)
			AdInterstitialUnitId = "";
		//// iOS
		#elif UNITY_IPHONE && !UNITY_EDITOR
			AdInterstitialUnitId = "79af9ceba9873a48";
		//// Android
		#elif UNITY_ANDROID && !UNITY_EDITOR
			AdInterstitialUnitId = "5417960a57a28fc14c4b32f15e33c18b";
		#endif

		FSAdNetwork.OnFinishInitAdInterstitial += OnFinishInitAdInterstitial;
		FSAdNetwork.OnFailedInitAdInterstitial += OnFailedInitAdInterstitial;
		FSAdNetwork.OnFailedSendAdRequestAdInterstitial += OnFailedSendAdRequestAdInterstitial;
		FSAdNetwork.OnFinishedResponseAdRequestAdInterstitial += OnFinishedResponseAdRequestAdInterstitial;
		FSAdNetwork.OnFailedResponseAdRequestAdInterstitial += OnFailedResponseAdRequestAdInterstitial;
		FSAdNetwork.OnEmptyResponseAdRequestAdInterstitial += OnEmptyResponseAdRequestAdInterstitial;
		FSAdNetwork.OnFinishedAdCreateAdInterstitial += OnFinishedAdCreateAdInterstitial;
		FSAdNetwork.OnFailedAdCreateAdInterstitial += OnFailedAdCreateAdInterstitial;
		FSAdNetwork.OnFinishedAdClickAdInterstitial += OnFinishedAdClickAdInterstitial;
		FSAdNetwork.OnFailedAdClickAdInterstitial += OnFailedAdClickAdInterstitial;
		FSAdNetwork.OnSkipAdCreateAdInterstitial += OnSkipAdCreateAdInterstitial;
		FSAdNetwork.OnHideAdViewAdInterstitial += OnHideAdViewAdInterstitial;

		// interstitial
		isAdShow = false;
		FSAdNetwork.initAdInterstitial (AdInterstitialUnitId);

		stateText.text = "init";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDisable() {
		Debug.Log ("interstitialScene - OnDisable");
	}

	void OnDestroy() {
		Debug.Log ("interstitialScene - OnDestroy");

		FSAdNetwork.OnFinishInitAdInterstitial -= OnFinishInitAdInterstitial;
		FSAdNetwork.OnFailedInitAdInterstitial -= OnFailedInitAdInterstitial;
		FSAdNetwork.OnFailedSendAdRequestAdInterstitial -= OnFailedSendAdRequestAdInterstitial;
		FSAdNetwork.OnFinishedResponseAdRequestAdInterstitial -= OnFinishedResponseAdRequestAdInterstitial;
		FSAdNetwork.OnFailedResponseAdRequestAdInterstitial -= OnFailedResponseAdRequestAdInterstitial;
		FSAdNetwork.OnEmptyResponseAdRequestAdInterstitial -= OnEmptyResponseAdRequestAdInterstitial;
		FSAdNetwork.OnFinishedAdCreateAdInterstitial -= OnFinishedAdCreateAdInterstitial;
		FSAdNetwork.OnFailedAdCreateAdInterstitial -= OnFailedAdCreateAdInterstitial;
		FSAdNetwork.OnFinishedAdClickAdInterstitial -= OnFinishedAdClickAdInterstitial;
		FSAdNetwork.OnFailedAdClickAdInterstitial -= OnFailedAdClickAdInterstitial;
		FSAdNetwork.OnSkipAdCreateAdInterstitial -= OnSkipAdCreateAdInterstitial;
		FSAdNetwork.OnHideAdViewAdInterstitial -= OnHideAdViewAdInterstitial;
	}



	public void buttonBack () {
//		SceneManager.LoadScene ("sampleApp");
		Application.LoadLevel ("sampleApp");
	}

	public void buttonShow () {
		Debug.Log ("show interstitial");

		if (isAdShow) {
			stateText.text = "show";
			FSAdNetwork.showAdInterstitial (AdInterstitialUnitId);
		}
	}


	// Delegate
	private void OnFinishInitAdInterstitial() {
		Debug.Log ("interstitialScene - OnFinishInitAdInterstitial");

		stateText.text = "load";
		FSAdNetwork.loadAdInterstitial (AdInterstitialUnitId);
	}
	private void OnFailedInitAdInterstitial(string error) {
		Debug.Log ("interstitialScene - OnFailedInitAdInterstitial" + "  error : " + error);

		stateText.text = "failed init";
	}
	private void OnFailedSendAdRequestAdInterstitial(string error) {
		Debug.Log ("interstitialScene - OnFailedSendAdRequestAdInterstitial" + "  error : " + error);

		stateText.text = "failed send Ad";
	}
	private void OnFinishedResponseAdRequestAdInterstitial() {
		Debug.Log ("interstitialScene - OnFinishedResponseAdRequestAdInterstitial");

		stateText.text = "ready show";
		isAdShow = true;
	}
	private void OnFailedResponseAdRequestAdInterstitial(string error) {
		Debug.Log ("interstitialScene - OnFailedResponseAdRequestAdInterstitial" + "  error : " + error);

		stateText.text = "failed load";
	}
	private void OnEmptyResponseAdRequestAdInterstitial() {
		Debug.Log ("interstitialScene - OnEmptyResponseAdRequestAdInterstitial");

		stateText.text = "empty response";
	}
	private void OnFinishedAdCreateAdInterstitial() {
		Debug.Log ("interstitialScene - OnFinishedAdCreateAdInterstitial");

		stateText.text = "finish create";
	}
	private void OnFailedAdCreateAdInterstitial(string error) {
		Debug.Log ("interstitialScene - OnFailedAdCreateAdInterstitial" + "  error : " + error);

		stateText.text = "failed create";
	}
	private void OnFinishedAdClickAdInterstitial() {
		Debug.Log ("interstitialScene - OnFinishedAdClickAdInterstitial");

		stateText.text = "finish click ad";
	}
	private void OnFailedAdClickAdInterstitial(string error) {
		Debug.Log ("interstitialScene - OnFailedAdClickAdInterstitial" + "  error : " + error);

		stateText.text = "failed click ad";
	}
	private void OnSkipAdCreateAdInterstitial() {
		Debug.Log ("interstitialScene - OnSkipAdCreateAdInterstitial");

		stateText.text = "skip ad create";
	}
	private void OnHideAdViewAdInterstitial() {
		Debug.Log ("interstitialScene - OnHideAdViewAdInterstitial");

		stateText.text = "hide ad";
	}
}
