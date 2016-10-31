using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pipSceneScript : MonoBehaviour {

	public Text stateText;
	private string AdPiPUnitId = "";

	// Use this for initialization
	void Start () {

		#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IPHONE)
			AdPiPUnitId = "";
		//// iOS
		#elif UNITY_IPHONE && !UNITY_EDITOR
			AdPiPUnitId = "b607a33beb0208e0";
		//// Android
		#elif UNITY_ANDROID && !UNITY_EDITOR
			AdPiPUnitId = "5417960a57a28fc1f13d0e28cce289ff";
		#endif

		FSAdNetwork.OnFinishInitAdPiP += OnFinishInitAdPiP;
		FSAdNetwork.OnFailedInitAdPiP += OnFailedInitAdPiP;
		FSAdNetwork.OnFailedSendAdRequestAdPiP += OnFailedSendAdRequestAdPiP;
		FSAdNetwork.OnFinishedResponseAdRequestAdPiP += OnFinishedResponseAdRequestAdPiP;
		FSAdNetwork.OnFailedResponseAdRequestAdPiP += OnFailedResponseAdRequestAdPiP;
		FSAdNetwork.OnEmptyResponseAdRequestAdPiP += OnEmptyResponseAdRequestAdPiP;
		FSAdNetwork.OnFinishedCreateAdPiP += OnFinishedCreateAdPiP;
		FSAdNetwork.OnFailedCreateAdPiP += OnFailedCreateAdPiP;
		FSAdNetwork.OnFinishedReadyMovieAdPiP += OnFinishedReadyMovieAdPiP;
		FSAdNetwork.OnFailedReadyMovieAdPiP += OnFailedReadyMovieAdPiP;
		FSAdNetwork.OnCompletedMovieAdPiP += OnCompletedMovieAdPiP;
		FSAdNetwork.OnFinishedAdClickAdPiP += OnFinishedAdClickAdPiP;
		FSAdNetwork.OnFailedAdClickAdPiP += OnFailedAdClickAdPiP;
		FSAdNetwork.OnHideAdViewAdPiP += OnHideAdViewAdPiP;
		FSAdNetwork.OnExpandedAdViewAdPiP += OnExpandedAdViewAdPiP;

		//
		FSAdNetwork.initAdPiP(AdPiPUnitId);
		stateText.text = "init";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDisable() {
		Debug.Log ("pipScene - OnDisable");
	}

	void OnDestroy() {
		Debug.Log ("pipScene - OnDestroy");

		FSAdNetwork.OnFinishInitAdPiP -= OnFinishInitAdPiP;
		FSAdNetwork.OnFailedInitAdPiP -= OnFailedInitAdPiP;
		FSAdNetwork.OnFailedSendAdRequestAdPiP -= OnFailedSendAdRequestAdPiP;
		FSAdNetwork.OnFinishedResponseAdRequestAdPiP -= OnFinishedResponseAdRequestAdPiP;
		FSAdNetwork.OnFailedResponseAdRequestAdPiP -= OnFailedResponseAdRequestAdPiP;
		FSAdNetwork.OnEmptyResponseAdRequestAdPiP -= OnEmptyResponseAdRequestAdPiP;
		FSAdNetwork.OnFinishedCreateAdPiP -= OnFinishedCreateAdPiP;
		FSAdNetwork.OnFailedCreateAdPiP -= OnFailedCreateAdPiP;
		FSAdNetwork.OnFinishedReadyMovieAdPiP -= OnFinishedReadyMovieAdPiP;
		FSAdNetwork.OnFailedReadyMovieAdPiP -= OnFailedReadyMovieAdPiP;
		FSAdNetwork.OnCompletedMovieAdPiP -= OnCompletedMovieAdPiP;
		FSAdNetwork.OnFinishedAdClickAdPiP -= OnFinishedAdClickAdPiP;
		FSAdNetwork.OnFailedAdClickAdPiP -= OnFailedAdClickAdPiP;
		FSAdNetwork.OnHideAdViewAdPiP -= OnHideAdViewAdPiP;
		FSAdNetwork.OnExpandedAdViewAdPiP -= OnExpandedAdViewAdPiP;
	}


	public void buttonBack () {
//		SceneManager.LoadScene ("sampleApp");
		Application.LoadLevel ("sampleApp");
	}

	public void buttonLoad () {
		Debug.Log ("++ Ad PiP Load");

		stateText.text = "load";
		FSAdNetwork.loadAdPiP (AdPiPUnitId);
	}

	public void buttonCreate () {
		Debug.Log ("++ Ad PiP Create");

		stateText.text = "create";
		FSAdNetwork.createAdPiP (AdPiPUnitId);
	}

	public void buttonLoadAndCreate () {
		Debug.Log ("++ Ad PiP Load & Create");

		stateText.text = "load & create";
		FSAdNetwork.loadAndCreateAdPiP (AdPiPUnitId);
	}

	public void buttonShow () {
		Debug.Log ("++ Ad PiP Show");

		stateText.text = "show";
		FSAdNetwork.showPosAdPiP (AdPiPUnitId, (int)FSAdNetwork.FSAdNetworkAdPositionType.RIGHT_BOTTOM);
	}


	// Delegate
	private void OnFinishInitAdPiP() {
		Debug.Log ("pipScene - OnFinishInitAdPiP");

		stateText.text = "finish init";
	}
	private void OnFailedInitAdPiP(string error) {
		Debug.Log ("pipScene - OnFailedInitAdPiP" + "  error : " + error);

		stateText.text = "failed init";
	}
	private void OnFailedSendAdRequestAdPiP(string error) {
		Debug.Log ("pipScene - OnFailedSendAdRequestAdPiP" + "  error : " + error);

		stateText.text = "failed send ad";
	}
	private void OnFinishedResponseAdRequestAdPiP() {
		Debug.Log ("pipScene - OnFinishedResponseAdRequestAdPiP");

		stateText.text = "loaded";
	}
	private void OnFailedResponseAdRequestAdPiP(string error) {
		Debug.Log ("pipScene - OnFailedResponseAdRequestAdPiP" + "  error : " + error);

		stateText.text = "failed load";
	}
	private void OnEmptyResponseAdRequestAdPiP() {
		Debug.Log ("pipScene - OnEmptyResponseAdRequestAdPiP");

		stateText.text = "empty response";
	}
	private void OnFinishedCreateAdPiP() {
		Debug.Log ("pipScene - OnFinishedCreateAdPiP");

		stateText.text = "created";
	}
	private void OnFailedCreateAdPiP(string error) {
		Debug.Log ("pipScene - OnFailedCreateAdPiP" + "  error : " + error);

		stateText.text = "failed create";
	}
	private void OnFinishedReadyMovieAdPiP() {
		Debug.Log ("pipScene - OnFinishedReadyMovieAdPiP");

		stateText.text = "ready show";
	}
	private void OnFailedReadyMovieAdPiP(string error) {
		Debug.Log ("pipScene - OnFailedReadyMovieAdPiP" + "  error : " + error);

		stateText.text = "failed ready";
	}
	private void OnCompletedMovieAdPiP() {
		Debug.Log ("pipScene - OnCompletedMovieAdPiP");

		stateText.text = "complete movie";
	}
	private void OnFinishedAdClickAdPiP() {
		Debug.Log ("pipScene - OnFinishedAdClickAdPiP");

		stateText.text = "finish click ad";
	}
	private void OnFailedAdClickAdPiP(string error) {
		Debug.Log ("pipScene - OnFailedAdClickAdPiP" + "  error : " + error);

		stateText.text = "failed click ad";
	}
	private void OnHideAdViewAdPiP() {
		Debug.Log ("pipScene - OnHideAdViewAdPiP");

		stateText.text = "hide ad";
	}
	private void OnExpandedAdViewAdPiP() {
		Debug.Log ("pipScene - OnExpandedAdViewAdPiP");

		stateText.text = "expanded ad";
	}
}
