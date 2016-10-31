using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class slideinSceneScript : MonoBehaviour {

	public Text stateText;
	private string AdSlideinUnitId = "";
	private bool isAdShow = false;

	// Use this for initialization
	void Start () {

		#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IPHONE)
			AdSlideinUnitId = "";
		//// iOS
		#elif UNITY_IPHONE && !UNITY_EDITOR
			AdSlideinUnitId = "196569da8af682e0";
		//// Android
		#elif UNITY_ANDROID && !UNITY_EDITOR
			AdSlideinUnitId = "5417960a57a28fc10a452d3a9e92b44a";
		#endif

		FSAdNetwork.OnFinishInitAdSlidein += OnFinishInitAdSlidein;
		FSAdNetwork.OnFailedInitAdSlidein += OnFailedInitAdSlidein;
		FSAdNetwork.OnFailedSendAdRequestAdSlidein += OnFailedSendAdRequestAdSlidein;
		FSAdNetwork.OnFinishedResponseAdRequestAdSlidein += OnFinishedResponseAdRequestAdSlidein;
		FSAdNetwork.OnFailedResponseAdRequestAdSlidein += OnFailedResponseAdRequestAdSlidein;
		FSAdNetwork.OnEmptyResponseAdRequestAdSlidein += OnEmptyResponseAdRequestAdSlidein;
		FSAdNetwork.OnFinishedAdCreateAdSlidein += OnFinishedAdCreateAdSlidein;
		FSAdNetwork.OnFailedAdCreateAdSlidein += OnFailedAdCreateAdSlidein;
		FSAdNetwork.OnFinishedAdClickAdSlidein += OnFinishedAdClickAdSlidein;
		FSAdNetwork.OnFailedAdClickAdSlidein += OnFailedAdClickAdSlidein;
		FSAdNetwork.OnSkipAdCreateAdSlidein += OnSkipAdCreateAdSlidein;
		FSAdNetwork.OnHideAdViewAdSlidein += OnHideAdViewAdSlidein;

		//
		FSAdNetwork.initAdSlidein(AdSlideinUnitId);
		stateText.text = "init";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDisable() {
		Debug.Log ("slideinScene - OnDisable");
	}

	void OnDestroy() {
		Debug.Log ("slideinScene - OnDestroy");

		FSAdNetwork.OnFinishInitAdSlidein -= OnFinishInitAdSlidein;
		FSAdNetwork.OnFailedInitAdSlidein -= OnFailedInitAdSlidein;
		FSAdNetwork.OnFailedSendAdRequestAdSlidein -= OnFailedSendAdRequestAdSlidein;
		FSAdNetwork.OnFinishedResponseAdRequestAdSlidein -= OnFinishedResponseAdRequestAdSlidein;
		FSAdNetwork.OnFailedResponseAdRequestAdSlidein -= OnFailedResponseAdRequestAdSlidein;
		FSAdNetwork.OnEmptyResponseAdRequestAdSlidein -= OnEmptyResponseAdRequestAdSlidein;
		FSAdNetwork.OnFinishedAdCreateAdSlidein -= OnFinishedAdCreateAdSlidein;
		FSAdNetwork.OnFailedAdCreateAdSlidein -= OnFailedAdCreateAdSlidein;
		FSAdNetwork.OnFinishedAdClickAdSlidein -= OnFinishedAdClickAdSlidein;
		FSAdNetwork.OnFailedAdClickAdSlidein -= OnFailedAdClickAdSlidein;
		FSAdNetwork.OnSkipAdCreateAdSlidein -= OnSkipAdCreateAdSlidein;
		FSAdNetwork.OnHideAdViewAdSlidein -= OnHideAdViewAdSlidein;
	}


	public void buttonBack () {
//		SceneManager.LoadScene ("sampleApp");
		Application.LoadLevel ("sampleApp");
	}

	public void buttonShow () {
		if (isAdShow) {
			stateText.text = "show";
			FSAdNetwork.showAdSlidein (AdSlideinUnitId);
		}
	}


	// Delegate
	private void OnFinishInitAdSlidein() {
		Debug.Log ("slideinScene - OnFinishInitAdSlidein");

		stateText.text = "load";
		FSAdNetwork.loadAdSlidein (AdSlideinUnitId);
	}
	private void OnFailedInitAdSlidein(string error) {
		Debug.Log ("slideinScene - OnFailedInitAdSlidein" + "  error : " + error);

		stateText.text = "failed init";
	}
	private void OnFailedSendAdRequestAdSlidein(string error) {
		Debug.Log ("slideinScene - OnFailedSendAdRequestAdSlidein" + "  error : " + error);

		stateText.text = "failed send ad";
	}
	private void OnFinishedResponseAdRequestAdSlidein() {
		Debug.Log ("slideinScene - OnFinishedResponseAdRequestAdSlidein");

		stateText.text = "ready show";
		isAdShow = true;
	}
	private void OnFailedResponseAdRequestAdSlidein(string error) {
		Debug.Log ("slideinScene - OnFailedResponseAdRequestAdSlidein" + "  error : " + error);

		stateText.text = "failed load";
	}
	private void OnEmptyResponseAdRequestAdSlidein() {
		Debug.Log ("slideinScene - OnEmptyResponseAdRequestAdSlidein");

		stateText.text = "empty response";
	}
	private void OnFinishedAdCreateAdSlidein() {
		Debug.Log ("slideinScene - OnFinishedAdCreateAdSlidein");

		stateText.text = "finish create";
	}
	private void OnFailedAdCreateAdSlidein(string error) {
		Debug.Log ("slideinScene - OnFailedAdCreateAdSlidein" + "  error : " + error);

		stateText.text = "failed create";
	}
	private void OnFinishedAdClickAdSlidein() {
		Debug.Log ("slideinScene - OnFinishedAdClickAdSlidein");

		stateText.text = "finish click ad";
	}
	private void OnFailedAdClickAdSlidein(string error) {
		Debug.Log ("slideinScene - OnFailedAdClickAdSlidein" + "  error : " + error);

		stateText.text = "failed click ad";
	}
	private void OnSkipAdCreateAdSlidein() {
		Debug.Log ("slideinScene - OnSkipAdCreateAdSlidein");

		stateText.text = "skip create ad";
	}
	private void OnHideAdViewAdSlidein() {
		Debug.Log ("slideinScene - OnHideAdViewAdSlidein");

		stateText.text = "hide ad";
	}

}
