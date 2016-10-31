using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class twinPanelSceneScript : MonoBehaviour {

	public Text stateText;
	private string AdTwinPanelAdUnitId = "";

	// Use this for initialization
	void Start () {

		#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IPHONE)
			AdTwinPanelAdUnitId = "";
		//// iOS
		#elif UNITY_IPHONE && !UNITY_EDITOR
			AdTwinPanelAdUnitId = "d8fd04e45351b930";
		//// Android
		#elif UNITY_ANDROID && !UNITY_EDITOR
			AdTwinPanelAdUnitId = "5417960a57a28fc1f956e089ce30a971";
		#endif

		FSAdNetwork.OnFinishInitAdTwinPanelView += OnFinishInitAdTwinPanelView;
		FSAdNetwork.OnFailedInitAdTwinPanelView += OnFailedInitAdTwinPanelView;
		FSAdNetwork.OnFailedSendAdRequestAdTwinPanelView += OnFailedSendAdRequestAdTwinPanelView;
		FSAdNetwork.OnFinishedResponseAdRequestAdTwinPanelView += OnFinishedResponseAdRequestAdTwinPanelView;
		FSAdNetwork.OnFailedResponseAdRequestAdTwinPanelView += OnFailedResponseAdRequestAdTwinPanelView;
		FSAdNetwork.OnEmptyResponseAdRequestAdTwinPanelView += OnEmptyResponseAdRequestAdTwinPanelView;
		FSAdNetwork.OnFinishedCreateAdTwinPanelView += OnFinishedCreateAdTwinPanelView;
		FSAdNetwork.OnFailedCreateAdTwinPanelView += OnFailedCreateAdTwinPanelView;
		FSAdNetwork.OnFinishedAdClickAdTwinPanelView += OnFinishedAdClickAdTwinPanelView;
		FSAdNetwork.OnFailedAdClickAdTwinPanelView += OnFailedAdClickAdTwinPanelView;

		stateText.text = "wait";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDisable() {
		Debug.Log ("twinPanelScene - OnDisable");

		FSAdNetwork.hideAdTwinPanelView ();
	}

	void OnDestroy() {
		Debug.Log ("twinPanelScene - OnDestroy");

		FSAdNetwork.OnFinishInitAdTwinPanelView -= OnFinishInitAdTwinPanelView;
		FSAdNetwork.OnFailedInitAdTwinPanelView -= OnFailedInitAdTwinPanelView;
		FSAdNetwork.OnFailedSendAdRequestAdTwinPanelView -= OnFailedSendAdRequestAdTwinPanelView;
		FSAdNetwork.OnFinishedResponseAdRequestAdTwinPanelView -= OnFinishedResponseAdRequestAdTwinPanelView;
		FSAdNetwork.OnFailedResponseAdRequestAdTwinPanelView -= OnFailedResponseAdRequestAdTwinPanelView;
		FSAdNetwork.OnEmptyResponseAdRequestAdTwinPanelView += OnEmptyResponseAdRequestAdTwinPanelView;
		FSAdNetwork.OnFinishedCreateAdTwinPanelView -= OnFinishedCreateAdTwinPanelView;
		FSAdNetwork.OnFailedCreateAdTwinPanelView -= OnFailedCreateAdTwinPanelView;
		FSAdNetwork.OnFinishedAdClickAdTwinPanelView -= OnFinishedAdClickAdTwinPanelView;
		FSAdNetwork.OnFailedAdClickAdTwinPanelView -= OnFailedAdClickAdTwinPanelView;

	}

	public void buttonBack () {
//		SceneManager.LoadScene ("sampleApp");
		Application.LoadLevel ("sampleApp");
	}

	public void buttonShow () {
		// banner
		FSAdNetwork.initAdTwinPanelView(AdTwinPanelAdUnitId, 0, 320, 320, 50);
		stateText.text = "init";
	}


	// Delegate
	private void OnFinishInitAdTwinPanelView() {
		Debug.Log ("twinPanelScene - OnFinishInitAdTwinPanelView");

		FSAdNetwork.loadAndShowAdTwinPanelView ();
		stateText.text = "load";
	}
	private void OnFailedInitAdTwinPanelView(string error) {
		Debug.Log ("twinPanelScene - OnFailedInitAdTwinPanelView" + "  error : " + error);

		stateText.text = "failed init";
	}
	private void OnFailedSendAdRequestAdTwinPanelView(string error) {
		Debug.Log ("twinPanelScene - OnFailedSendAdRequestAdTwinPanelView" + "  error : " + error);

		stateText.text = "failed send ad";
	}
	private void OnFinishedResponseAdRequestAdTwinPanelView() {
		Debug.Log ("twinPanelScene - OnFinishedResponseAdRequestAdTwinPanelView");

		stateText.text = "show";
	}
	private void OnFailedResponseAdRequestAdTwinPanelView(string error) {
		Debug.Log ("twinPanelScene - OnFailedResponseAdRequestAdTwinPanelView" + "  error : " + error);

		stateText.text = "failed load";
	}
	private void OnEmptyResponseAdRequestAdTwinPanelView() {
		Debug.Log ("twinPanelScene - OnEmptyResponseAdRequestAdTwinPanelView");

		stateText.text = "empty response";
	}
	private void OnFinishedCreateAdTwinPanelView() {
		Debug.Log ("twinPanelScene - OnFinishedCreateAdTwinPanelView");

		stateText.text = "finish create ad";
	}
	private void OnFailedCreateAdTwinPanelView(string error) {
		Debug.Log ("twinPanelScene - OnFailedCreateAdTwinPanelView" + "  error : " + error);

		stateText.text = "failed create ad";
	}
	private void OnFinishedAdClickAdTwinPanelView() {
		Debug.Log ("twinPanelScene - OnFinishedAdClickAdTwinPanelView");

		stateText.text = "finish click ad";
	}
	private void OnFailedAdClickAdTwinPanelView(string error) {
		Debug.Log ("twinPanelScene - OnFailedAdClickAdTwinPanelView" + "  error : " + error);

		stateText.text = "failed click ad";
	}
}
