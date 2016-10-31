using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class popupScene : MonoBehaviour {

	public Text stateText;
	private string AdPopupUnitId = "";
	private bool isAdShow = false;

	// Use this for initialization
	void Start () {

		#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IPHONE)
			AdPopupUnitId = "";
		//// iOS
		#elif UNITY_IPHONE && !UNITY_EDITOR
			AdPopupUnitId = "253699cab2e982d1";
		//// Android
		#elif UNITY_ANDROID && !UNITY_EDITOR
			AdPopupUnitId = "5417960a57a28fc103b266d9bcf185a7";
		#endif

		FSAdNetwork.OnFinishInitAdPopup += OnFinishInitAdPopup;
		FSAdNetwork.OnFailedInitAdPopup += OnFailedInitAdPopup;
		FSAdNetwork.OnFailedSendAdRequestAdPopup += OnFailedSendAdRequestAdPopup;
		FSAdNetwork.OnFinishedResponseAdRequestAdPopup += OnFinishedResponseAdRequestAdPopup;
		FSAdNetwork.OnFailedResponseAdRequestAdPopup += OnFailedResponseAdRequestAdPopup;
		FSAdNetwork.OnEmptyResponseAdRequestAdPopup += OnEmptyResponseAdRequestAdPopup;
		FSAdNetwork.OnFinishedAdCreateAdPopup += OnFinishedAdCreateAdPopup;
		FSAdNetwork.OnFailedAdCreateAdPopup += OnFailedAdCreateAdPopup;
		FSAdNetwork.OnFinishedAdClickAdPopup += OnFinishedAdClickAdPopup;
		FSAdNetwork.OnFailedAdClickAdPopup += OnFailedAdClickAdPopup;
		FSAdNetwork.OnSkipAdCreateAdPopup += OnSkipAdCreateAdPopup;
		FSAdNetwork.OnHideAdViewAdPopup += OnHideAdViewAdPopup;

		//
		isAdShow = false;
		FSAdNetwork.initAdPopup(AdPopupUnitId);
		stateText.text = "init";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDisable() {
		Debug.Log ("popupScene - OnDisable");
	}

	void OnDestroy() {
		Debug.Log ("popupScene - OnDestroy");

		FSAdNetwork.OnFinishInitAdPopup -= OnFinishInitAdPopup;
		FSAdNetwork.OnFailedInitAdPopup -= OnFailedInitAdPopup;
		FSAdNetwork.OnFailedSendAdRequestAdPopup -= OnFailedSendAdRequestAdPopup;
		FSAdNetwork.OnFinishedResponseAdRequestAdPopup -= OnFinishedResponseAdRequestAdPopup;
		FSAdNetwork.OnFailedResponseAdRequestAdPopup -= OnFailedResponseAdRequestAdPopup;
		FSAdNetwork.OnEmptyResponseAdRequestAdPopup -= OnEmptyResponseAdRequestAdPopup;
		FSAdNetwork.OnFinishedAdCreateAdPopup -= OnFinishedAdCreateAdPopup;
		FSAdNetwork.OnFailedAdCreateAdPopup -= OnFailedAdCreateAdPopup;
		FSAdNetwork.OnFinishedAdClickAdPopup -= OnFinishedAdClickAdPopup;
		FSAdNetwork.OnFailedAdClickAdPopup -= OnFailedAdClickAdPopup;
		FSAdNetwork.OnSkipAdCreateAdPopup -= OnSkipAdCreateAdPopup;
		FSAdNetwork.OnHideAdViewAdPopup -= OnHideAdViewAdPopup;
	}


	public void buttonBack () {
//		SceneManager.LoadScene ("sampleApp");
		Application.LoadLevel ("sampleApp");
	}

	public void buttonShow () {
		if (isAdShow) {
			stateText.text = "show";
			FSAdNetwork.showAdPopup (AdPopupUnitId);
		}
	}


	// Delegate
	private void OnFinishInitAdPopup() {
		Debug.Log ("popupScene - OnFinishInitAdPopup");

		stateText.text = "load";
		FSAdNetwork.loadAdPopup (AdPopupUnitId);
	}
	private void OnFailedInitAdPopup(string error) {
		Debug.Log ("popupScene - OnFailedInitAdPopup" + "  error : " + error);

		stateText.text = "failed init";
	}
	private void OnFailedSendAdRequestAdPopup(string error) {
		Debug.Log ("popupScene - OnFailedSendAdRequestAdPopup" + "  error : " + error);

		stateText.text = "failed send ad";
	}
	private void OnFinishedResponseAdRequestAdPopup() {
		Debug.Log ("popupScene - OnFinishedResponseAdRequestAdPopup");

		stateText.text = "ready show";
		isAdShow = true;
	}
	private void OnFailedResponseAdRequestAdPopup(string error) {
		Debug.Log ("popupScene - OnFailedResponseAdRequestAdPopup" + "  error : " + error);

		stateText.text = "failed load";
	}
	private void OnEmptyResponseAdRequestAdPopup() {
		Debug.Log ("popupScene - OnEmptyResponseAdRequestAdPopup");

		stateText.text = "empty response";
	}
	private void OnFinishedAdCreateAdPopup() {
		Debug.Log ("popupScene - OnFinishedAdCreateAdPopup");

		stateText.text = "finish create";
	}
	private void OnFailedAdCreateAdPopup(string error) {
		Debug.Log ("popupScene - OnFailedAdCreateAdPopup" + "  error : " + error);

		stateText.text = "failed create";
	}
	private void OnFinishedAdClickAdPopup() {
		Debug.Log ("popupScene - OnFinishedAdClickAdPopup");

		stateText.text = "finish click ad";
	}
	private void OnFailedAdClickAdPopup(string error) {
		Debug.Log ("popupScene - OnFailedAdClickAdPopup" + "  error : " + error);

		stateText.text = "failed click ad";
	}
	private void OnSkipAdCreateAdPopup() {
		Debug.Log ("popupScene - OnSkipAdCreateAdPopup");

		stateText.text = "skip create ad";
	}
	private void OnHideAdViewAdPopup() {
		Debug.Log ("popupScene - OnHideAdViewAdPopup");

		stateText.text = "hide ad";
	}
}
