using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bannerSceneScript : MonoBehaviour {

	public Text stateText;
	private string AdBannerAdUnitId = "";

	// Use this for initialization
	void Start () {

		#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IPHONE)
			AdBannerAdUnitId = "";
		//// iOS
		#elif UNITY_IPHONE && !UNITY_EDITOR
			AdBannerAdUnitId = "3f48888f7b64ce90";
		//// Android
		#elif UNITY_ANDROID && !UNITY_EDITOR
			AdBannerAdUnitId = "5417960a57a28fc1dfb675ce57ffbaa2";
		#endif

		FSAdNetwork.OnFinishInitAdBannerView += OnFinishInitAdBannerView;
		FSAdNetwork.OnFailedInitAdBannerView += OnFailedInitAdBannerView;
		FSAdNetwork.OnFailedSendAdRequestAdBannerView += OnFailedSendAdRequestAdBannerView;
		FSAdNetwork.OnFinishedResponseAdRequestAdBannerView += OnFinishedResponseAdRequestAdBannerView;
		FSAdNetwork.OnFailedResponseAdRequestAdBannerView += OnFailedResponseAdRequestAdBannerView;
		FSAdNetwork.OnEmptyResponseAdRequestAdBannerView += OnEmptyResponseAdRequestAdBannerView;
		FSAdNetwork.OnFinishedCreateAdBannerView += OnFinishedCreateAdBannerView;
		FSAdNetwork.OnFailedCreateAdBannerView += OnFailedCreateAdBannerView;
		FSAdNetwork.OnFinishedAdClickAdBannerView += OnFinishedAdClickAdBannerView;
		FSAdNetwork.OnFailedAdClickAdBannerView += OnFailedAdClickAdBannerView;

		stateText.text = "wait";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDisable() {
		Debug.Log ("bannerScene - OnDisable");

		FSAdNetwork.hideAdBannerView ();
	}

	void OnDestroy() {
		Debug.Log ("bannerScene - OnDestroy");

		FSAdNetwork.OnFinishInitAdBannerView -= OnFinishInitAdBannerView;
		FSAdNetwork.OnFailedInitAdBannerView -= OnFailedInitAdBannerView;
		FSAdNetwork.OnFailedSendAdRequestAdBannerView -= OnFailedSendAdRequestAdBannerView;
		FSAdNetwork.OnFinishedResponseAdRequestAdBannerView -= OnFinishedResponseAdRequestAdBannerView;
		FSAdNetwork.OnFailedResponseAdRequestAdBannerView -= OnFailedResponseAdRequestAdBannerView;
		FSAdNetwork.OnEmptyResponseAdRequestAdBannerView -= OnEmptyResponseAdRequestAdBannerView;
		FSAdNetwork.OnFinishedCreateAdBannerView -= OnFinishedCreateAdBannerView;
		FSAdNetwork.OnFailedCreateAdBannerView -= OnFailedCreateAdBannerView;
		FSAdNetwork.OnFinishedAdClickAdBannerView -= OnFinishedAdClickAdBannerView;
		FSAdNetwork.OnFailedAdClickAdBannerView -= OnFailedAdClickAdBannerView;
	}

	public void buttonBack () {
		Application.LoadLevel ("sampleApp");
//		SceneManager.LoadScene ("sampleApp");
	}

	public void buttonShow () {
		stateText.text = "init";
		// banner
		FSAdNetwork.initAdBannerView(AdBannerAdUnitId, 0, 320, 320, 50);
	}

	// Delegate
	private void OnFinishInitAdBannerView() {
		Debug.Log ("bannserScene - OnFinishInitAdBannerView");

		stateText.text = "load";

		FSAdNetwork.loadAndShowAdBannerView ();
	}
	private void OnFailedInitAdBannerView(string error) {
		Debug.Log ("bannserScene - OnFailedInitAdBannerView" + "  error : " + error);

		stateText.text = "failed init";
	}
	private void OnFailedSendAdRequestAdBannerView(string error) {
		Debug.Log ("bannserScene - OnFailedSendAdRequestAdBannerView" + "  error : " + error);

		stateText.text = "failed send ad";
	}
	private void OnFinishedResponseAdRequestAdBannerView() {
		Debug.Log ("bannserScene - OnFinishedResponseAdRequestAdBannerView");

		stateText.text = "show";
	}
	private void OnFailedResponseAdRequestAdBannerView(string error) {
		Debug.Log ("bannserScene - OnFailedResponseAdRequestAdBannerView" + "  error : " + error);

		stateText.text = "failed load";
	}
	private void OnEmptyResponseAdRequestAdBannerView() {
		Debug.Log ("bannserScene - OnEmptyResponseAdRequestAdBannerView");

		stateText.text = "empty response";
	}
	private void OnFinishedCreateAdBannerView() {
		Debug.Log ("bannserScene - OnFinishedCreateAdBannerView");

		stateText.text = "finish create ad";
	}
	private void OnFailedCreateAdBannerView(string error) {
		Debug.Log ("bannserScene - OnFailedCreateAdBannerView" + "  error : " + error);

		stateText.text = "failed create ad";
	}
	private void OnFinishedAdClickAdBannerView() {
		Debug.Log ("bannserScene - OnFinishedAdClickAdBannerView");

		stateText.text = "finish click ad";
	}
	private void OnFailedAdClickAdBannerView(string error) {
		Debug.Log ("bannserScene - OnFailedAdClickAdBannerView" + "  error : " + error);

		stateText.text = "failed click ad";
	}

}
