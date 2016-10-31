using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class forcedMovieSceneScript : MonoBehaviour {

	public Text stateText;
	private string AdForcedMovieUnitId = "";

	// Use this for initialization
	void Start () {

		#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IPHONE)
			AdForcedMovieUnitId = "";
		//// iOS
		#elif UNITY_IPHONE && !UNITY_EDITOR
			AdForcedMovieUnitId = "ef62fad1bc625754";
		//// Android
		#elif UNITY_ANDROID && !UNITY_EDITOR
			AdForcedMovieUnitId = "5417960a57a28fc19f0e802776c66967";
		#endif

		FSAdNetwork.OnFinishInitAdForcedMovie += OnFinishInitAdForcedMovie;
		FSAdNetwork.OnFailedInitAdForcedMovie += OnFailedInitAdForcedMovie;
		FSAdNetwork.OnFailedSendAdRequestAdForcedMovie += OnFailedSendAdRequestAdForcedMovie;
		FSAdNetwork.OnFinishedResponseAdRequestAdForcedMovie += OnFinishedResponseAdRequestAdForcedMovie;
		FSAdNetwork.OnFailedResponseAdRequestAdForcedMovie += OnFailedResponseAdRequestAdForcedMovie;
		FSAdNetwork.OnEmptyResponseAdRequestAdForcedMovie += OnEmptyResponseAdRequestAdForcedMovie;
		FSAdNetwork.OnFinishedReadyMovieAdForcedMovie += OnFinishedReadyMovieAdForcedMovie;
		FSAdNetwork.OnFailedReadyMovieAdForcedMovie += OnFailedReadyMovieAdForcedMovie;
		FSAdNetwork.OnFinishedCreateAdForcedMovie += OnFinishedCreateAdForcedMovie;
		FSAdNetwork.OnFailedCreateAdForcedMovie += OnFailedCreateAdForcedMovie;
		FSAdNetwork.OnCompletedMovieAdForcedMovie += OnCompletedMovieAdForcedMovie;
		FSAdNetwork.OnFinishedAdClickAdForcedMovie += OnFinishedAdClickAdForcedMovie;
		FSAdNetwork.OnFailedAdClickAdForcedMovie += OnFailedAdClickAdForcedMovie;
		FSAdNetwork.OnHideAdViewAdForcedMovie += OnHideAdViewAdForcedMovie;

		stateText.text = "none";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDisable() {
		Debug.Log ("forcedMovieScene - OnDisable");
	}

	void OnDestroy() {
		Debug.Log ("forcedMovieScene - OnDestroy");

		FSAdNetwork.OnFinishInitAdForcedMovie -= OnFinishInitAdForcedMovie;
		FSAdNetwork.OnFailedInitAdForcedMovie -= OnFailedInitAdForcedMovie;
		FSAdNetwork.OnFailedSendAdRequestAdForcedMovie -= OnFailedSendAdRequestAdForcedMovie;
		FSAdNetwork.OnFinishedResponseAdRequestAdForcedMovie -= OnFinishedResponseAdRequestAdForcedMovie;
		FSAdNetwork.OnFailedResponseAdRequestAdForcedMovie -= OnFailedResponseAdRequestAdForcedMovie;
		FSAdNetwork.OnEmptyResponseAdRequestAdForcedMovie -= OnEmptyResponseAdRequestAdForcedMovie;
		FSAdNetwork.OnFinishedReadyMovieAdForcedMovie -= OnFinishedReadyMovieAdForcedMovie;
		FSAdNetwork.OnFailedReadyMovieAdForcedMovie -= OnFailedReadyMovieAdForcedMovie;
		FSAdNetwork.OnFinishedCreateAdForcedMovie -= OnFinishedCreateAdForcedMovie;
		FSAdNetwork.OnFailedCreateAdForcedMovie -= OnFailedCreateAdForcedMovie;
		FSAdNetwork.OnCompletedMovieAdForcedMovie -= OnCompletedMovieAdForcedMovie;
		FSAdNetwork.OnFinishedAdClickAdForcedMovie -= OnFinishedAdClickAdForcedMovie;
		FSAdNetwork.OnFailedAdClickAdForcedMovie -= OnFailedAdClickAdForcedMovie;
		FSAdNetwork.OnHideAdViewAdForcedMovie -= OnHideAdViewAdForcedMovie;

	}


	public void buttonBack () {
//		SceneManager.LoadScene ("sampleApp");
		Application.LoadLevel ("sampleApp");
	}

	public void buttonShow () {

		//
		stateText.text = "ad init...";
		FSAdNetwork.initAdForcedMovie(AdForcedMovieUnitId);
	}


	// Delegate
	private void OnFinishInitAdForcedMovie() {
		Debug.Log ("forcedMovieScene - OnFinishInitAdForcedMovie");

		stateText.text = "ad load...";
		FSAdNetwork.loadAdForcedMovie (AdForcedMovieUnitId);
	}
	private void OnFailedInitAdForcedMovie(string error) {
		Debug.Log ("forcedMovieScene - OnFailedInitAdForcedMovie" + "  error : " + error);

		stateText.text = "failed init";
	}
	private void OnFailedSendAdRequestAdForcedMovie(string error) {
		Debug.Log ("forcedMovieScene - OnFailedSendAdRequestAdForcedMovie" + "  error : " + error);

		stateText.text = "failed send ad";
	}
	private void OnFinishedResponseAdRequestAdForcedMovie() {
		Debug.Log ("forcedMovieScene - OnFinishedResponseAdRequestAdForcedMovie");

		stateText.text = "ad create...";
		FSAdNetwork.createAdForcedMovie (AdForcedMovieUnitId);
	}
	private void OnFailedResponseAdRequestAdForcedMovie(string error) {
		Debug.Log ("forcedMovieScene - OnFailedResponseAdRequestAdForcedMovie" + "  error : " + error);

		stateText.text = "failed load";
	}
	private void OnEmptyResponseAdRequestAdForcedMovie() {
		Debug.Log ("forcedMovieScene - OnEmptyResponseAdRequestAdForcedMovie");

		stateText.text = "empty response";
	}
	private void OnFinishedReadyMovieAdForcedMovie() {
		Debug.Log ("forcedMovieScene - OnFinishedReadyMovieAdForcedMovie");

		stateText.text = "ad ready...";
		FSAdNetwork.showAdForcedMovie (AdForcedMovieUnitId);
	}
	private void OnFailedReadyMovieAdForcedMovie(string error) {
		Debug.Log ("forcedMovieScene - OnFailedReadyMovieAdForcedMovie" + "  error : " + error);

		stateText.text = "failed ready";
	}
	private void OnFinishedCreateAdForcedMovie() {
		Debug.Log ("forcedMovieScene - OnFinishedCreateAdForcedMovie");

		stateText.text = "finish create";
	}
	private void OnFailedCreateAdForcedMovie(string error) {
		Debug.Log ("forcedMovieScene - OnFailedCreateAdForcedMovie" + "  error : " + error);

		stateText.text = "failed create";
	}
	private void OnCompletedMovieAdForcedMovie() {
		Debug.Log ("forcedMovieScene - OnCompletedMovieAdForcedMovie");

		stateText.text = "complete movie";
	}
	private void OnFinishedAdClickAdForcedMovie() {
		Debug.Log ("forcedMovieScene - OnFinishedAdClickAdForcedMovie");

		stateText.text = "finish click ad";
	}
	private void OnFailedAdClickAdForcedMovie(string error) {
		Debug.Log ("forcedMovieScene - OnFailedAdClickAdForcedMovie" + "  error : " + error);

		stateText.text = "failed click ad";
	}
	private void OnHideAdViewAdForcedMovie() {
		Debug.Log ("forcedMovieScene - OnHideAdViewAdForcedMovie");

		stateText.text = "hide ad";
	}
}
