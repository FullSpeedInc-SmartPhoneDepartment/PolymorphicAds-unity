using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class doubleBannerSceneScript : MonoBehaviour {

	public Text stateText;
	private string AdDoubleBannerAdUnitId = "";

	// Use this for initialization
	void Start () {
		Debug.Log ("doubleBannerScene - Start");

		#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IPHONE)
			AdDoubleBannerAdUnitId = "";
		//// iOS
		#elif UNITY_IPHONE && !UNITY_EDITOR
			AdDoubleBannerAdUnitId = "eba6b7a036fdf970";
		//// Android
		#elif UNITY_ANDROID && !UNITY_EDITOR
			AdDoubleBannerAdUnitId = "5417960a57a28fc1e4aa42375c5e2661";
		#endif

		FSAdNetwork.OnFinishInitAdDoubleBannerView += OnFinishInitAdDoubleBannerView;
		FSAdNetwork.OnFailedInitAdDoubleBannerView += OnFailedInitAdDoubleBannerView;
		FSAdNetwork.OnFailedSendAdRequestAdDoubleBannerView += OnFailedSendAdRequestAdDoubleBannerView;
		FSAdNetwork.OnFinishedResponseAdRequestAdDoubleBannerView += OnFinishedResponseAdRequestAdDoubleBannerView;
		FSAdNetwork.OnFailedResponseAdRequestAdDoubleBannerView += OnFailedResponseAdRequestAdDoubleBannerView;
		FSAdNetwork.OnEmptyResponseAdRequestAdDoubleBannerView += OnEmptyResponseAdRequestAdDoubleBannerView;
		FSAdNetwork.OnFinishedCreateAdDoubleBannerView += OnFinishedCreateAdDoubleBannerView;
		FSAdNetwork.OnFailedCreateAdDoubleBannerView += OnFailedCreateAdDoubleBannerView;
		FSAdNetwork.OnFinishedAdClickAdDoubleBannerView += OnFinishedAdClickAdDoubleBannerView;
		FSAdNetwork.OnFailedAdClickAdDoubleBannerView += OnFailedAdClickAdDoubleBannerView;

		stateText.text = "wait";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDisable() {
		Debug.Log ("doubleBannerScene - OnDisable");

		FSAdNetwork.hideAdDoubleBannerView ();
	}

	void OnDestroy() {
		Debug.Log ("doubleBannerScene - OnDestroy");

		FSAdNetwork.OnFinishInitAdDoubleBannerView -= OnFinishInitAdDoubleBannerView;
		FSAdNetwork.OnFailedInitAdDoubleBannerView -= OnFailedInitAdDoubleBannerView;
		FSAdNetwork.OnFailedSendAdRequestAdDoubleBannerView -= OnFailedSendAdRequestAdDoubleBannerView;
		FSAdNetwork.OnFinishedResponseAdRequestAdDoubleBannerView -= OnFinishedResponseAdRequestAdDoubleBannerView;
		FSAdNetwork.OnFailedResponseAdRequestAdDoubleBannerView -= OnFailedResponseAdRequestAdDoubleBannerView;
		FSAdNetwork.OnEmptyResponseAdRequestAdDoubleBannerView -= OnEmptyResponseAdRequestAdDoubleBannerView;
		FSAdNetwork.OnFinishedCreateAdDoubleBannerView -= OnFinishedCreateAdDoubleBannerView;
		FSAdNetwork.OnFailedCreateAdDoubleBannerView -= OnFailedCreateAdDoubleBannerView;
		FSAdNetwork.OnFinishedAdClickAdDoubleBannerView -= OnFinishedAdClickAdDoubleBannerView;
		FSAdNetwork.OnFailedAdClickAdDoubleBannerView -= OnFailedAdClickAdDoubleBannerView;
	}

	public void buttonBack () {
//		SceneManager.LoadScene ("sampleApp");
		Application.LoadLevel ("sampleApp");
	}

	public void buttonShow () {
		Debug.Log ("doubleBannerScene - buttonShow");

		// banner
		FSAdNetwork.initAdDoubleBannerView(AdDoubleBannerAdUnitId, 0, 320, 320, 100);
		stateText.text = "init";
	}


	// Delegate
	private void OnFinishInitAdDoubleBannerView() {
		Debug.Log ("doubleBannerScene - OnFinishInitAdDoubleBannerView");

		stateText.text = "init";
		FSAdNetwork.loadAndShowAdDoubleBannerView ();
	}
	private void OnFailedInitAdDoubleBannerView(string error) {
		Debug.Log ("doubleBannerScene - OnFailedInitAdDoubleBannerView" + "  error : " + error);

		stateText.text = "failed init";
	}
	private void OnFailedSendAdRequestAdDoubleBannerView(string error) {
		Debug.Log ("doubleBannerScene - OnFailedSendAdRequestAdDoubleBannerView" + "  error : " + error);

		stateText.text = "failed send ad";
	}
	private void OnFinishedResponseAdRequestAdDoubleBannerView() {
		Debug.Log ("doubleBannerScene - OnFinishedResponseAdRequestAdDoubleBannerView");

		stateText.text = "show";
	}
	private void OnFailedResponseAdRequestAdDoubleBannerView(string error) {
		Debug.Log ("doubleBannerScene - OnFailedResponseAdRequestAdDoubleBannerView" + "  error : " + error);

		stateText.text = "failed load";
	}
	private void OnEmptyResponseAdRequestAdDoubleBannerView() {
		Debug.Log ("doubleBannerScene - OnEmptyResponseAdRequestAdDoubleBannerView");

		stateText.text = "empty response";
	}
	private void OnFinishedCreateAdDoubleBannerView() {
		Debug.Log ("doubleBannerScene - OnFinishedCreateAdDoubleBannerView");

		stateText.text = "finish create ad";
	}
	private void OnFailedCreateAdDoubleBannerView(string error) {
		Debug.Log ("doubleBannerScene - OnFailedCreateAdDoubleBannerView" + "  error : " + error);

		stateText.text = "failed create ad";
	}
	private void OnFinishedAdClickAdDoubleBannerView() {
		Debug.Log ("doubleBannerScene - OnFinishedAdClickAdDoubleBannerView");

		stateText.text = "finish click ad";
	}
	private void OnFailedAdClickAdDoubleBannerView(string error) {
		Debug.Log ("doubleBannerScene - OnFailedAdClickAdDoubleBannerView" + "  error : " + error);

		stateText.text = "failed click ad";
	}
}
