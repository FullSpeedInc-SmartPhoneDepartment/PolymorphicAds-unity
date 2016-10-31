using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class rectangleBannerSceneScript : MonoBehaviour {

	public Text stateText;
	private string AdBannerAdUnitId = "";

	// Use this for initialization
	void Start () {

		#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IPHONE)
			AdBannerAdUnitId = "";
		//// iOS
		#elif UNITY_IPHONE && !UNITY_EDITOR
			AdBannerAdUnitId = "4173d2df883041d0";
		//// Android
		#elif UNITY_ANDROID && !UNITY_EDITOR
			AdBannerAdUnitId = "d53b605de1198219f09f3a23b3272e0e";
		#endif

		FSAdNetwork.OnFinishInitAdRectangleBannerView += OnFinishInitAdRectangleBannerView;
		FSAdNetwork.OnFailedInitAdRectangleBannerView += OnFailedInitAdRectangleBannerView;
		FSAdNetwork.OnFailedSendAdRequestAdRectangleBannerView += OnFailedSendAdRequestAdRectangleBannerView;
		FSAdNetwork.OnFinishedResponseAdRequestAdRectangleBannerView += OnFinishedResponseAdRequestAdRectangleBannerView;
		FSAdNetwork.OnFailedResponseAdRequestAdRectangleBannerView += OnFailedResponseAdRequestAdRectangleBannerView;
		FSAdNetwork.OnEmptyResponseAdRequestAdRectangleBannerView += OnEmptyResponseAdRequestAdRectangleBannerView;
		FSAdNetwork.OnFinishedCreateAdRectangleBannerView += OnFinishedCreateAdRectangleBannerView;
		FSAdNetwork.OnFailedCreateAdRectangleBannerView += OnFailedCreateAdRectangleBannerView;
		FSAdNetwork.OnFinishedAdClickAdRectangleBannerView += OnFinishedAdClickAdRectangleBannerView;
		FSAdNetwork.OnFailedAdClickAdRectangleBannerView += OnFailedAdClickAdRectangleBannerView;

		stateText.text = "wait";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDisable() {
		Debug.Log ("rectangleBannerScene - OnDisable");

		FSAdNetwork.hideAdRectangleBannerView ();
	}

	void OnDestroy() {
		Debug.Log ("rectangleBannerScene - OnDestroy");

		FSAdNetwork.OnFinishInitAdRectangleBannerView -= OnFinishInitAdRectangleBannerView;
		FSAdNetwork.OnFailedInitAdRectangleBannerView -= OnFailedInitAdRectangleBannerView;
		FSAdNetwork.OnFailedSendAdRequestAdRectangleBannerView -= OnFailedSendAdRequestAdRectangleBannerView;
		FSAdNetwork.OnFinishedResponseAdRequestAdRectangleBannerView -= OnFinishedResponseAdRequestAdRectangleBannerView;
		FSAdNetwork.OnFailedResponseAdRequestAdRectangleBannerView -= OnFailedResponseAdRequestAdRectangleBannerView;
		FSAdNetwork.OnEmptyResponseAdRequestAdRectangleBannerView -= OnEmptyResponseAdRequestAdRectangleBannerView;
		FSAdNetwork.OnFinishedCreateAdRectangleBannerView -= OnFinishedCreateAdRectangleBannerView;
		FSAdNetwork.OnFailedCreateAdRectangleBannerView -= OnFailedCreateAdRectangleBannerView;
		FSAdNetwork.OnFinishedAdClickAdRectangleBannerView -= OnFinishedAdClickAdRectangleBannerView;
		FSAdNetwork.OnFailedAdClickAdRectangleBannerView -= OnFailedAdClickAdRectangleBannerView;
	}

	public void buttonBack () {
//		SceneManager.LoadScene ("sampleApp");
		Application.LoadLevel ("sampleApp");
	}

	public void buttonShow () {
		stateText.text = "init";
		// banner
		FSAdNetwork.initAdRectangleBannerView(AdBannerAdUnitId, 0, 320, 300, 250);
	}

	// Delegate
	private void OnFinishInitAdRectangleBannerView() {
		Debug.Log ("rectangleBannerScene - OnFinishInitAdRectangleBannerView");

		stateText.text = "load";

		FSAdNetwork.loadAndShowAdRectangleBannerView ();
	}
	private void OnFailedInitAdRectangleBannerView(string error) {
		Debug.Log ("rectangleBannerScene - OnFailedInitAdRectangleBannerView" + "  error : " + error);

		stateText.text = "failed init";
	}
	private void OnFailedSendAdRequestAdRectangleBannerView(string error) {
		Debug.Log ("rectangleBannerScene - OnFailedSendAdRequestAdRectangleBannerView" + "  error : " + error);

		stateText.text = "failed send ad";
	}
	private void OnFinishedResponseAdRequestAdRectangleBannerView() {
		Debug.Log ("rectangleBannerScene - OnFinishedResponseAdRequestAdRectangleBannerView");

		stateText.text = "show";
	}
	private void OnFailedResponseAdRequestAdRectangleBannerView(string error) {
		Debug.Log ("rectangleBannerScene - OnFailedResponseAdRequestAdRectangleBannerView" + "  error : " + error);

		stateText.text = "failed load";
	}
	private void OnEmptyResponseAdRequestAdRectangleBannerView() {
		Debug.Log ("rectangleBannerScene - OnEmptyResponseAdRequestAdRectangleBannerView");

		stateText.text = "empty response";
	}
	private void OnFinishedCreateAdRectangleBannerView() {
		Debug.Log ("rectangleBannerScene - OnFinishedCreateAdRectangleBannerView");

		stateText.text = "finish create ad";
	}
	private void OnFailedCreateAdRectangleBannerView(string error) {
		Debug.Log ("rectangleBannerScene - OnFailedCreateAdRectangleBannerView" + "  error : " + error);

		stateText.text = "failed create ad";
	}
	private void OnFinishedAdClickAdRectangleBannerView() {
		Debug.Log ("rectangleBannerScene - OnFinishedAdClickAdRectangleBannerView");

		stateText.text = "finish click ad";
	}
	private void OnFailedAdClickAdRectangleBannerView(string error) {
		Debug.Log ("rectangleBannerScene - OnFailedAdClickAdRectangleBannerView" + "  error : " + error);

		stateText.text = "failed click ad";
	}
}
