//  ---------------------------------------------------------------------------
//  FSAdNetwork.cs
//
//  Polymorphic Plugin for Unity.
//
//  Copyright © 2016 Polymorphic, Inc.  All rights reserved.
//
//  ---------------------------------------------------------------------------
using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;


public class FSAdNetwork : MonoBehaviour 
{
	// The single instance of the AdColony component
	private static FSAdNetwork instance;
	public static string version = "1.0.0";

	//We need this so that native code has an object to send messages to
	private static void ensureInstance()
	{
		if(instance == null) {
			instance = FindObjectOfType( typeof(FSAdNetwork) ) as FSAdNetwork;
			if(instance == null) {
				instance = new GameObject("FSAdNetwork").AddComponent<FSAdNetwork>();
			}
		}
	}

	void Awake() {
		Debug.Log ("FSAdNetwork - Awake");

		// Set the name to allow UnitySendMessage to find this object.
		name = "FSAdNetwork";
		// Make sure this GameObject persists across scenes
		DontDestroyOnLoad(transform.gameObject);

		FSAdNetwork.Configure ();
	}

	public enum FSAdNetworkAdPositionType {
		LEFT_TOP,
		RIGHT_TOP,
		LEFT_BOTTOM,
		RIGHT_BOTTOM,
	};



	//// FSAdNetwork Delegate
	// FSAdBannerViewDelegate
	public delegate void AdBannerViewFinishInitDelegate();
	public delegate void AdBannerViewFailedInitDelegate(string error);
	public delegate void AdBannerViewFailedSendAdRequestDelegate (string error);
	public delegate void AdBannerViewFinishedResponseAdRequestDelegate ();
	public delegate void AdBannerViewFailedResponseAdRequestDelegate (string error);
	public delegate void AdBannerViewEmptyResponseAdRequestDelegate ();
	public delegate void AdBannerViewFinishedCreateDelegate();
	public delegate void AdBannerViewFailedCreateDelegate(string error);
	public delegate void AdBannerViewFinishedAdClickDelegate();
	public delegate void AdBannerViewFailedAdClickDelegate(string error);

	public static AdBannerViewFinishInitDelegate 					OnFinishInitAdBannerView;
	public static AdBannerViewFailedInitDelegate 					OnFailedInitAdBannerView;
	public static AdBannerViewFailedSendAdRequestDelegate 			OnFailedSendAdRequestAdBannerView;
	public static AdBannerViewFinishedResponseAdRequestDelegate		OnFinishedResponseAdRequestAdBannerView;
	public static AdBannerViewFailedResponseAdRequestDelegate 		OnFailedResponseAdRequestAdBannerView;
	public static AdBannerViewEmptyResponseAdRequestDelegate 		OnEmptyResponseAdRequestAdBannerView;
	public static AdBannerViewFinishedCreateDelegate 				OnFinishedCreateAdBannerView;
	public static AdBannerViewFailedCreateDelegate 					OnFailedCreateAdBannerView;
	public static AdBannerViewFinishedAdClickDelegate 				OnFinishedAdClickAdBannerView;
	public static AdBannerViewFailedAdClickDelegate 				OnFailedAdClickAdBannerView;

	public void finishInitAdFSAdBannerView(string args) {
		if (OnFinishInitAdBannerView != null) {
			OnFinishInitAdBannerView ();
		}
	}
	public void failedInitAdFSAdBannerView(string args) {
		if (OnFailedInitAdBannerView != null) {
			OnFailedInitAdBannerView (args);
		}
	}
	public void failedSendAdRequestFSAdBannerView(string args) {
		if (OnFailedSendAdRequestAdBannerView != null) {
			OnFailedSendAdRequestAdBannerView (args);
		}
	}
	public void finishedResponseAdRequestFSAdBannerView(string args) {
		if (OnFinishedResponseAdRequestAdBannerView != null) {
			OnFinishedResponseAdRequestAdBannerView ();
		}
	}
	public void failedResponseAdRequestFSAdBannerView(string args) {
		if (OnFailedResponseAdRequestAdBannerView != null) {
			OnFailedResponseAdRequestAdBannerView (args);
		}
	}
	public void emptyAdResponseAdRequestFSAdBannerView(string args) {
		if (OnEmptyResponseAdRequestAdBannerView != null) {
			OnEmptyResponseAdRequestAdBannerView ();
		}
	}
	public void finishedCreateFSAdBannerView(string args) {
		if (OnFinishedCreateAdBannerView != null) {
			OnFinishedCreateAdBannerView ();
		}
	}
	public void failedCreateFSAdBannerView(string args) {
		if (OnFailedCreateAdBannerView != null) {
			OnFailedCreateAdBannerView (args);
		}
	}
	public void finishedAdClickFSAdBannerView(string args) {
		if (OnFinishedAdClickAdBannerView != null) {
			OnFinishedAdClickAdBannerView ();
		}
	}
	public void failedAdClickFSAdBannerView(string args) {
		if (OnFailedAdClickAdBannerView != null) {
			OnFailedAdClickAdBannerView (args);
		}
	}

	// FSAdDoubleBannerView Delegate
	public delegate void AdDoubleBannerViewFinishInitDelegate();
	public delegate void AdDoubleBannerViewFailedInitDelegate(string error);
	public delegate void AdDoubleBannerViewFailedSendAdRequestDelegate (string error);
	public delegate void AdDoubleBannerViewFinishedResponseAdRequestDelegate ();
	public delegate void AdDoubleBannerViewFailedResponseAdRequestDelegate (string error);
	public delegate void AdDoubleBannerViewEmptyResponseAdRequestDelegate ();
	public delegate void AdDoubleBannerViewFinishedCreateDelegate();
	public delegate void AdDoubleBannerViewFailedCreateDelegate(string error);
	public delegate void AdDoubleBannerViewFinishedAdClickDelegate();
	public delegate void AdDoubleBannerViewFailedAdClickDelegate(string error);

	public static AdDoubleBannerViewFinishInitDelegate 					OnFinishInitAdDoubleBannerView;
	public static AdDoubleBannerViewFailedInitDelegate 					OnFailedInitAdDoubleBannerView;
	public static AdDoubleBannerViewFailedSendAdRequestDelegate 		OnFailedSendAdRequestAdDoubleBannerView;
	public static AdDoubleBannerViewFinishedResponseAdRequestDelegate	OnFinishedResponseAdRequestAdDoubleBannerView;
	public static AdDoubleBannerViewFailedResponseAdRequestDelegate 	OnFailedResponseAdRequestAdDoubleBannerView;
	public static AdDoubleBannerViewEmptyResponseAdRequestDelegate 		OnEmptyResponseAdRequestAdDoubleBannerView;
	public static AdDoubleBannerViewFinishedCreateDelegate 				OnFinishedCreateAdDoubleBannerView;
	public static AdDoubleBannerViewFailedCreateDelegate 				OnFailedCreateAdDoubleBannerView;
	public static AdDoubleBannerViewFinishedAdClickDelegate 			OnFinishedAdClickAdDoubleBannerView;
	public static AdDoubleBannerViewFailedAdClickDelegate 				OnFailedAdClickAdDoubleBannerView;

	public void finishInitAdFSAdDoubleBannerView(string args) {
		if (OnFinishInitAdDoubleBannerView != null) {
			OnFinishInitAdDoubleBannerView ();
		}
	}
	public void failedInitAdFSAdDoubleBannerView(string args) {
		if (OnFailedInitAdDoubleBannerView != null) {
			OnFailedInitAdDoubleBannerView (args);
		}
	}
	public void failedSendAdRequestFSAdDoubleBannerView(string args) {
		if (OnFailedSendAdRequestAdDoubleBannerView != null) {
			OnFailedSendAdRequestAdDoubleBannerView (args);
		}
	}
	public void finishedResponseAdRequestFSAdDoubleBannerView(string args) {
		if (OnFinishedResponseAdRequestAdDoubleBannerView != null) {
			OnFinishedResponseAdRequestAdDoubleBannerView ();
		}
	}
	public void failedResponseAdRequestFSAdDoubleBannerView(string args) {
		if (OnFailedResponseAdRequestAdDoubleBannerView != null) {
			OnFailedResponseAdRequestAdDoubleBannerView (args);
		}
	}
	public void emptyAdResponseAdRequestFSAdDoubleBannerView(string args) {
		if (OnEmptyResponseAdRequestAdDoubleBannerView != null) {
			OnEmptyResponseAdRequestAdDoubleBannerView ();
		}
	}
	public void finishedCreateFSAdDoubleBannerView(string args) {
		if (OnFinishedCreateAdDoubleBannerView != null) {
			OnFinishedCreateAdDoubleBannerView ();
		}
	}
	public void failedCreateFSAdDoubleBannerView(string args) {
		if (OnFailedCreateAdDoubleBannerView != null) {
			OnFailedCreateAdDoubleBannerView (args);
		}
	}
	public void finishedAdClickFSAdDoubleBannerView(string args) {
		if (OnFinishedAdClickAdDoubleBannerView != null) {
			OnFinishedAdClickAdDoubleBannerView ();
		}
	}
	public void failedAdClickFSAdDoubleBannerView(string args) {
		if (OnFailedAdClickAdDoubleBannerView != null) {
			OnFailedAdClickAdDoubleBannerView (args);
		}
	}

	// FSAdTwinPanelViewDelegate
	public delegate void AdTwinPanelViewFinishInitDelegate();
	public delegate void AdTwinPanelViewFailedInitDelegate(string error);
	public delegate void AdTwinPanelViewFailedSendAdRequestDelegate (string error);
	public delegate void AdTwinPanelViewFinishedResponseAdRequestDelegate ();
	public delegate void AdTwinPanelViewFailedResponseAdRequestDelegate (string error);
	public delegate void AdTwinPanelViewEmptyResponseAdRequestDelegate ();
	public delegate void AdTwinPanelViewFinishedCreateDelegate();
	public delegate void AdTwinPanelViewFailedCreateDelegate(string error);
	public delegate void AdTwinPanelViewFinishedAdClickDelegate();
	public delegate void AdTwinPanelViewFailedAdClickDelegate(string error);

	public static AdTwinPanelViewFinishInitDelegate 				OnFinishInitAdTwinPanelView;
	public static AdTwinPanelViewFailedInitDelegate 				OnFailedInitAdTwinPanelView;
	public static AdTwinPanelViewFailedSendAdRequestDelegate 		OnFailedSendAdRequestAdTwinPanelView;
	public static AdTwinPanelViewFinishedResponseAdRequestDelegate	OnFinishedResponseAdRequestAdTwinPanelView;
	public static AdTwinPanelViewFailedResponseAdRequestDelegate 	OnFailedResponseAdRequestAdTwinPanelView;
	public static AdTwinPanelViewEmptyResponseAdRequestDelegate 	OnEmptyResponseAdRequestAdTwinPanelView;
	public static AdTwinPanelViewFinishedCreateDelegate 			OnFinishedCreateAdTwinPanelView;
	public static AdTwinPanelViewFailedCreateDelegate 				OnFailedCreateAdTwinPanelView;
	public static AdTwinPanelViewFinishedAdClickDelegate 			OnFinishedAdClickAdTwinPanelView;
	public static AdTwinPanelViewFailedAdClickDelegate 				OnFailedAdClickAdTwinPanelView;

	public void finishInitAdFSAdTwinPanelView(string args) {
		if (OnFinishInitAdTwinPanelView != null) {
			OnFinishInitAdTwinPanelView ();
		}
	}
	public void failedInitAdFSAdTwinPanelView(string args) {
		if (OnFailedInitAdTwinPanelView != null) {
			OnFailedInitAdTwinPanelView (args);
		}
	}
	public void failedSendAdRequestFSAdTwinPanelView(string args) {
		if (OnFailedSendAdRequestAdTwinPanelView != null) {
			OnFailedSendAdRequestAdTwinPanelView (args);
		}
	}
	public void finishedResponseAdRequestFSAdTwinPanelView(string args) {
		if (OnFinishedResponseAdRequestAdTwinPanelView != null) {
			OnFinishedResponseAdRequestAdTwinPanelView ();
		}
	}
	public void failedResponseAdRequestFSAdTwinPanelView(string args) {
		if (OnFailedResponseAdRequestAdTwinPanelView != null) {
			OnFailedResponseAdRequestAdTwinPanelView (args);
		}
	}
	public void emptyAdResponseAdRequestFSAdTwinPanelView(string args) {
		if (OnEmptyResponseAdRequestAdTwinPanelView != null) {
			OnEmptyResponseAdRequestAdTwinPanelView ();
		}
	}
	public void finishedCreateFSAdTwinPanelView(string args) {
		if (OnFinishedCreateAdTwinPanelView != null) {
			OnFinishedCreateAdTwinPanelView ();
		}
	}
	public void failedCreateFSAdTwinPanelView(string args) {
		if (OnFailedCreateAdTwinPanelView != null) {
			OnFailedCreateAdTwinPanelView (args);
		}
	}
	public void finishedAdClickFSAdTwinPanelView(string args) {
		if (OnFinishedAdClickAdTwinPanelView != null) {
			OnFinishedAdClickAdTwinPanelView ();
		}
	}
	public void failedAdClickFSAdTwinPanelView(string args) {
		if (OnFailedAdClickAdTwinPanelView != null) {
			OnFailedAdClickAdTwinPanelView (args);
		}
	}

	// FSAdInterstitialAdLoader Delegate
	public delegate void AdInterstitialFinishInitDelegate();
	public delegate void AdInterstitialFailedInitDelegate (string error);
	public delegate void AdInterstitialFailedSendAdRequestDelegate (string error);
	public delegate void AdInterstitialFinishedResponseAdRequestDelegate ();
	public delegate void AdInterstitialFailedResponseAdRequestDelegate (string error);
	public delegate void AdInterstitialEmptyResponseAdRequestDelegate ();
	public delegate void AdInterstitialFinishedAdCreateDelegate ();
	public delegate void AdInterstitialFailedAdCreateDelegate (string error);
	public delegate void AdInterstitialFinishedAdClickDelegate ();
	public delegate void AdInterstitialFailedAdClickDelegate (string error);
	public delegate void AdInterstitialSkipAdCreateDelegate ();
	public delegate void AdInterstitialHideAdViewDelegate ();

	public static AdInterstitialFinishInitDelegate 					OnFinishInitAdInterstitial;
	public static AdInterstitialFailedInitDelegate 					OnFailedInitAdInterstitial;
	public static AdInterstitialFailedSendAdRequestDelegate 		OnFailedSendAdRequestAdInterstitial;
	public static AdInterstitialFinishedResponseAdRequestDelegate 	OnFinishedResponseAdRequestAdInterstitial;
	public static AdInterstitialFailedResponseAdRequestDelegate 	OnFailedResponseAdRequestAdInterstitial;
	public static AdInterstitialEmptyResponseAdRequestDelegate 		OnEmptyResponseAdRequestAdInterstitial;
	public static AdInterstitialFinishedAdCreateDelegate 			OnFinishedAdCreateAdInterstitial;
	public static AdInterstitialFailedAdCreateDelegate 				OnFailedAdCreateAdInterstitial;
	public static AdInterstitialFinishedAdClickDelegate 			OnFinishedAdClickAdInterstitial;
	public static AdInterstitialFailedAdClickDelegate 				OnFailedAdClickAdInterstitial;
	public static AdInterstitialSkipAdCreateDelegate 				OnSkipAdCreateAdInterstitial;
	public static AdInterstitialHideAdViewDelegate 					OnHideAdViewAdInterstitial;

	public void finishInitAdFSAdInterstitial(string args) {
		if (OnFinishInitAdInterstitial != null) {
			OnFinishInitAdInterstitial ();
		}
	}
	public void failedInitAdFSAdInterstitial(string args) {
		if (OnFailedInitAdInterstitial != null) {
			OnFailedInitAdInterstitial (args);
		}
	}
	public void failedSendAdRequestFSAdInterstitial(string args) {
		if (OnFailedSendAdRequestAdInterstitial != null) {
			OnFailedSendAdRequestAdInterstitial (args);
		}
	}
	public void finishedResponseAdRequestFSAdInterstitial(string args) {
		if (OnFinishedResponseAdRequestAdInterstitial != null) {
			OnFinishedResponseAdRequestAdInterstitial ();
		}
	}
	public void failedResponseAdRequestFSAdInterstitial(string args) {
		if (OnFailedResponseAdRequestAdInterstitial != null) {
			OnFailedResponseAdRequestAdInterstitial (args);
		}
	}
	public void emptyAdResponseAdRequestFSAdInterstitial(string args) {
		if (OnEmptyResponseAdRequestAdInterstitial != null) {
			OnEmptyResponseAdRequestAdInterstitial ();
		}
	}
	public void finishedAdCreateFSAdInterstitial(string args) {
		if (OnFinishedAdCreateAdInterstitial != null) {
			OnFinishedAdCreateAdInterstitial ();
		}
	}
	public void failedAdCreateFSAdInterstitial(string args) {
		if (OnFailedAdCreateAdInterstitial != null) {
			OnFailedAdCreateAdInterstitial (args);
		}
	}
	public void finishedAdClickFSAdInterstitial(string args) {
		if (OnFinishedAdClickAdInterstitial != null) {
			OnFinishedAdClickAdInterstitial ();
		}
	}
	public void failedAdClickFSAdInterstitial(string args) {
		if (OnFailedAdClickAdInterstitial != null) {
			OnFailedAdClickAdInterstitial (args);
		}
	}
	public void skipAdCreateFSAdInterstitial(string args) {
		if (OnSkipAdCreateAdInterstitial != null) {
			OnSkipAdCreateAdInterstitial ();
		}
	}
	public void hideFSAdInterstitial(string args) {
		if (OnHideAdViewAdInterstitial != null) {
			OnHideAdViewAdInterstitial ();
		}
	}


	// FSAdPopupAdLoader Delegate
	public delegate void AdPopupFinishInitDelegate();
	public delegate void AdPopupFailedInitDelegate (string error);
	public delegate void AdPopupFailedSendAdRequestDelegate (string error);
	public delegate void AdPopupFinishedResponseAdRequestDelegate ();
	public delegate void AdPopupFailedResponseAdRequestDelegate (string error);
	public delegate void AdPopupEmptyResponseAdRequestDelegate ();
	public delegate void AdPopupFinishedAdCreateDelegate();
	public delegate void AdPopupFailedAdCreateDelegate(string error);
	public delegate void AdPopupFinishedAdClickDelegate();
	public delegate void AdPopupFailedAdClickDelegate(string error);
	public delegate void AdPopupSkipAdCreateDelegate();
	public delegate void AdPopupHideAdViewDelegate();

	public static AdPopupFinishInitDelegate 					OnFinishInitAdPopup;
	public static AdPopupFailedInitDelegate 					OnFailedInitAdPopup;
	public static AdPopupFailedSendAdRequestDelegate 			OnFailedSendAdRequestAdPopup;
	public static AdPopupFinishedResponseAdRequestDelegate 		OnFinishedResponseAdRequestAdPopup;
	public static AdPopupFailedResponseAdRequestDelegate 		OnFailedResponseAdRequestAdPopup;
	public static AdPopupEmptyResponseAdRequestDelegate 		OnEmptyResponseAdRequestAdPopup;
	public static AdPopupFinishedAdCreateDelegate 				OnFinishedAdCreateAdPopup;
	public static AdPopupFailedAdCreateDelegate 				OnFailedAdCreateAdPopup;
	public static AdPopupFinishedAdClickDelegate 				OnFinishedAdClickAdPopup;
	public static AdPopupFailedAdClickDelegate 					OnFailedAdClickAdPopup;
	public static AdPopupSkipAdCreateDelegate 					OnSkipAdCreateAdPopup;
	public static AdPopupHideAdViewDelegate 					OnHideAdViewAdPopup;

	public void finishInitAdFSAdPopup(string args) {
		if (OnFinishInitAdPopup != null) {
			OnFinishInitAdPopup ();
		}
	}
	public void failedInitAdFSAdPopup(string args) {
		if (OnFailedInitAdPopup != null) {
			OnFailedInitAdPopup (args);
		}
	}
	public void failedSendAdRequestFSAdPopup(string args) {
		if (OnFailedSendAdRequestAdPopup != null) {
			OnFailedSendAdRequestAdPopup (args);
		}
	}
	public void finishedResponseAdRequestFSAdPopup(string args) {
		if (OnFinishedResponseAdRequestAdPopup != null) {
			OnFinishedResponseAdRequestAdPopup ();
		}
	}
	public void failedResponseAdRequestFSAdPopup(string args) {
		if (OnFailedResponseAdRequestAdPopup != null) {
			OnFailedResponseAdRequestAdPopup (args);
		}
	}
	public void emptyAdResponseAdRequestFSAdPopup(string args) {
		if (OnEmptyResponseAdRequestAdPopup != null) {
			OnEmptyResponseAdRequestAdPopup ();
		}
	}
	public void finishedAdCreateFSAdPopup(string args) {
		if (OnFinishedAdCreateAdPopup != null) {
			OnFinishedAdCreateAdPopup ();
		}
	}
	public void failedAdCreateFSAdPopup(string args) {
		if (OnFailedAdCreateAdPopup != null) {
			OnFailedAdCreateAdPopup (args);
		}
	}
	public void finishedAdClickFSAdPopup(string args) {
		if (OnFinishedAdClickAdPopup != null) {
			OnFinishedAdClickAdPopup ();
		}
	}
	public void failedAdClickFSAdPopup(string args) {
		if (OnFailedAdClickAdPopup != null) {
			OnFailedAdClickAdPopup (args);
		}
	}
	public void skipAdCreateFSAdPopup(string args) {
		if (OnSkipAdCreateAdPopup != null) {
			OnSkipAdCreateAdPopup ();
		}
	}
	public void hideFSAdPopup(string args) {
		if (OnHideAdViewAdPopup != null) {
			OnHideAdViewAdPopup ();
		}
	}


	// FSAdSlideInAdLoader Delegate
	public delegate void AdSlideinFinishInitDelegate();
	public delegate void AdSlideinFailedInitDelegate (string error);
	public delegate void AdSlideinFailedSendAdRequestDelegate(string error);
	public delegate void AdSlideinFinishedResponseAdRequestDelegate ();
	public delegate void AdSlideinFailedResponseAdRequestDelegate (string error);
	public delegate void AdSlideinEmptyResponseAdRequestDelegate();
	public delegate void AdSlideinFinishedAdCreateDelegate();
	public delegate void AdSlideinFailedAdCreateDelegate(string error);
	public delegate void AdSlideinFinishedAdClickDelegate();
	public delegate void AdSlideinFailedAdClickDelegate(string error);
	public delegate void AdSlideinSkipAdCreateDelegate();
	public delegate void AdSlideinHideAdViewDelegate();

	public static AdSlideinFinishInitDelegate 					OnFinishInitAdSlidein;
	public static AdSlideinFailedInitDelegate 					OnFailedInitAdSlidein;
	public static AdSlideinFailedSendAdRequestDelegate 			OnFailedSendAdRequestAdSlidein;
	public static AdSlideinFinishedResponseAdRequestDelegate 	OnFinishedResponseAdRequestAdSlidein;
	public static AdSlideinFailedResponseAdRequestDelegate 		OnFailedResponseAdRequestAdSlidein;
	public static AdSlideinEmptyResponseAdRequestDelegate 		OnEmptyResponseAdRequestAdSlidein;
	public static AdSlideinFinishedAdCreateDelegate 			OnFinishedAdCreateAdSlidein;
	public static AdSlideinFailedAdCreateDelegate 				OnFailedAdCreateAdSlidein;
	public static AdSlideinFinishedAdClickDelegate 				OnFinishedAdClickAdSlidein;
	public static AdSlideinFailedAdClickDelegate 				OnFailedAdClickAdSlidein;
	public static AdSlideinSkipAdCreateDelegate 				OnSkipAdCreateAdSlidein;
	public static AdSlideinHideAdViewDelegate 					OnHideAdViewAdSlidein;

	public void finishInitAdFSAdSlideIn(string args) {
		if (OnFinishInitAdSlidein != null) {
			OnFinishInitAdSlidein ();
		}
	}
	public void failedInitAdFSAdSlideIn(string args) {
		if (OnFailedInitAdSlidein != null) {
			OnFailedInitAdSlidein (args);
		}
	}
	public void failedSendAdRequestFSAdSlideIn(string args) {
		if (OnFailedSendAdRequestAdSlidein != null) {
			OnFailedSendAdRequestAdSlidein (args);
		}
	}
	public void finishedResponseAdRequestFSAdSlideIn(string args) {
		if (OnFinishedResponseAdRequestAdSlidein != null) {
			OnFinishedResponseAdRequestAdSlidein ();
		}
	}
	public void failedResponseAdRequestFSAdSlideIn(string args) {
		if (OnFailedResponseAdRequestAdSlidein != null) {
			OnFailedResponseAdRequestAdSlidein (args);
		}
	}
	public void emptyAdResponseAdRequestFSAdSlideIn(string args) {
		if (OnEmptyResponseAdRequestAdSlidein != null) {
			OnEmptyResponseAdRequestAdSlidein ();
		}
	}
	public void finishedAdCreateFSAdSlideIn(string args) {
		if (OnFinishedAdCreateAdSlidein != null) {
			OnFinishedAdCreateAdSlidein ();
		}
	}
	public void failedAdCreateFSAdSlideIn(string args) {
		if (OnFailedAdCreateAdSlidein != null) {
			OnFailedAdCreateAdSlidein (args);
		}
	}
	public void finishedAdClickFSAdSlideIn(string args) {
		if (OnFinishedAdClickAdSlidein != null) {
			OnFinishedAdClickAdSlidein ();
		}
	}
	public void failedAdClickFSAdSlideIn(string args) {
		if (OnFailedAdClickAdSlidein != null) {
			OnFailedAdClickAdSlidein (args);
		}
	}
	public void skipAdCreateFSAdSlideIn(string args) {
		if (OnSkipAdCreateAdSlidein != null) {
			OnSkipAdCreateAdSlidein ();
		}
	}
	public void hideFSAdSlideIn(string args) {
		if (OnHideAdViewAdSlidein != null) {
			OnHideAdViewAdSlidein ();
		}
	}


	// FSAdPiPAdLoader Delegate
	public delegate void AdPipFinishInitDelegate();
	public delegate void AdPipFailedInitDelegate(string error);
	public delegate void AdPipFailedSendAdRequestDelegate (string error);
	public delegate void AdPipFinishedResponseAdRequestDelegate();
	public delegate void AdPipFailedResponseAdRequestDelegate (string error);
	public delegate void AdPipEmptyResponseAdRequestDelegate();
	public delegate void AdPipFinishedReadyMovieDelegate();
	public delegate void AdPipFailedReadyMovieDelegate(string error);
	public delegate void AdPipFinishedCreateDelegate();
	public delegate void AdPipFailedCreateDelegate(string error);
	public delegate void AdPipCompletedMovieDelegate();
	public delegate void AdPipFinishedAdClickDelegate();
	public delegate void AdPipFailedAdClickDelegate(string error);
	public delegate void AdPipHideAdViewDelegate();
	public delegate void AdPipExpandedAdViewDelegate ();

	public static AdPipFinishInitDelegate 					OnFinishInitAdPiP;
	public static AdPipFailedInitDelegate 					OnFailedInitAdPiP;
	public static AdPipFailedSendAdRequestDelegate 			OnFailedSendAdRequestAdPiP;
	public static AdPipFinishedResponseAdRequestDelegate 	OnFinishedResponseAdRequestAdPiP;
	public static AdPipFailedResponseAdRequestDelegate 		OnFailedResponseAdRequestAdPiP;
	public static AdPipEmptyResponseAdRequestDelegate 		OnEmptyResponseAdRequestAdPiP;
	public static AdPipFinishedReadyMovieDelegate 			OnFinishedReadyMovieAdPiP;
	public static AdPipFailedReadyMovieDelegate 			OnFailedReadyMovieAdPiP;
	public static AdPipFinishedCreateDelegate 				OnFinishedCreateAdPiP;
	public static AdPipFailedCreateDelegate 				OnFailedCreateAdPiP;
	public static AdPipCompletedMovieDelegate 				OnCompletedMovieAdPiP;
	public static AdPipFinishedAdClickDelegate 				OnFinishedAdClickAdPiP;
	public static AdPipFailedAdClickDelegate 				OnFailedAdClickAdPiP;
	public static AdPipHideAdViewDelegate 					OnHideAdViewAdPiP;
	public static AdPipExpandedAdViewDelegate 				OnExpandedAdViewAdPiP;

	public void finishInitAdFSAdPiP(string args) {
		if (OnFinishInitAdPiP != null) {
			OnFinishInitAdPiP ();
		}
	}
	public void failedInitAdFSAdPiP(string args) {
		if (OnFailedInitAdPiP != null) {
			OnFailedInitAdPiP (args);
		}
	}
	public void failedSendAdRequestFSAdPiP(string args) {
		if (OnFailedSendAdRequestAdPiP != null) {
			OnFailedSendAdRequestAdPiP (args);
		}
	}
	public void finishedResponseAdRequestFSAdPiP(string args) {
		if (OnFinishedResponseAdRequestAdPiP != null) {
			OnFinishedResponseAdRequestAdPiP ();
		}
	}
	public void failedResponseAdRequestFSAdPiP(string args) {
		if (OnFailedResponseAdRequestAdPiP != null) {
			OnFailedResponseAdRequestAdPiP (args);
		}
	}
	public void emptyAdResponseAdRequestFSAdPiP(string args) {
		if (OnEmptyResponseAdRequestAdPiP != null) {
			OnEmptyResponseAdRequestAdPiP ();
		}
	}
	public void finishedReadyMovieFSAdPiP(string args) {
		if (OnFinishedReadyMovieAdPiP != null) {
			OnFinishedReadyMovieAdPiP ();
		}
	}
	public void failedReadyMovieFSAdPiP(string args) {
		if (OnFailedReadyMovieAdPiP != null) {
			OnFailedReadyMovieAdPiP (args);
		}
	}
	public void finishedCreateFSAdPiP(string args) {
		if (OnFinishedCreateAdPiP != null) {
			OnFinishedCreateAdPiP ();
		}
	}
	public void failedCreateFSAdPiP(string args) {
		if (OnFailedCreateAdPiP != null) {
			OnFailedCreateAdPiP (args);
		}
	}
	public void completedMovieFSAdPiP(string args) {
		if (OnCompletedMovieAdPiP != null) {
			OnCompletedMovieAdPiP ();
		}
	}
	public void finishedAdClickFSAdPiP(string args) {
		if (OnFinishedAdClickAdPiP != null) {
			OnFinishedAdClickAdPiP ();
		}
	}
	public void failedAdClickFSAdPiP(string args) {
		if (OnFailedAdClickAdPiP != null) {
			OnFailedAdClickAdPiP (args);
		}
	}
	public void hideAdViewFSAdPiP(string args) {
		if (OnHideAdViewAdPiP != null) {
			OnHideAdViewAdPiP ();
		}
	} 
	public void expandedAdViewFSAdPiP(string args) {
		if (OnExpandedAdViewAdPiP != null) {
			OnExpandedAdViewAdPiP ();
		}
	}

	// FSAdForcedMovieAdLoader Delegate
	public delegate void AdForcedMovieFinishInitDelegate();
	public delegate void AdForcedMovieFailedInitDelegate (string error);
	public delegate void AdForcedMovieFailedSendAdRequestDelegate(string error);
	public delegate void AdForcedMovieFinishedResponseAdRequestDelegate();
	public delegate void AdForcedMovieFailedResponseAdRequestDelegate (string error);
	public delegate void AdForcedMovieEmptyResponseAdRequestDelegate();
	public delegate void AdForcedMovieFinishedReadyMovieDelegate();
	public delegate void AdForcedMovieFailedReadyMovieDelegate(string error);
	public delegate void AdForcedMovieFinishedCreateDelegate();
	public delegate void AdForcedMovieFailedCreateDelegate(string error);
	public delegate void AdForcedMovieCompletedMovieDelegate();
	public delegate void AdForcedMovieFinishedAdClickDelegate();
	public delegate void AdForcedMovieFailedAdClickDelegate (string error);
	public delegate void AdForcedMovieHideAdViewDelegate();

	public static AdForcedMovieFinishInitDelegate 					OnFinishInitAdForcedMovie;
	public static AdForcedMovieFailedInitDelegate 					OnFailedInitAdForcedMovie;
	public static AdForcedMovieFailedSendAdRequestDelegate 			OnFailedSendAdRequestAdForcedMovie;
	public static AdForcedMovieFinishedResponseAdRequestDelegate 	OnFinishedResponseAdRequestAdForcedMovie;
	public static AdForcedMovieFailedResponseAdRequestDelegate 		OnFailedResponseAdRequestAdForcedMovie;
	public static AdForcedMovieEmptyResponseAdRequestDelegate 		OnEmptyResponseAdRequestAdForcedMovie;
	public static AdForcedMovieFinishedReadyMovieDelegate 			OnFinishedReadyMovieAdForcedMovie;
	public static AdForcedMovieFailedReadyMovieDelegate 			OnFailedReadyMovieAdForcedMovie;
	public static AdForcedMovieFinishedCreateDelegate 				OnFinishedCreateAdForcedMovie;
	public static AdForcedMovieFailedCreateDelegate 				OnFailedCreateAdForcedMovie;
	public static AdForcedMovieCompletedMovieDelegate 				OnCompletedMovieAdForcedMovie;
	public static AdForcedMovieFinishedAdClickDelegate 				OnFinishedAdClickAdForcedMovie;
	public static AdForcedMovieFailedAdClickDelegate 				OnFailedAdClickAdForcedMovie;
	public static AdForcedMovieHideAdViewDelegate 					OnHideAdViewAdForcedMovie;

	public void finishInitAdFSAdForcedMovie(string args) {
		if (OnFinishInitAdForcedMovie != null) {
			OnFinishInitAdForcedMovie ();
		}
	}
	public void failedInitAdFSAdForcedMovie(string args) {
		if (OnFailedInitAdForcedMovie != null) {
			OnFailedInitAdForcedMovie (args);
		}
	}
	public void failedSendAdRequestFSAdForcedMovie(string args) {
		if (OnFailedSendAdRequestAdForcedMovie != null) {
			OnFailedSendAdRequestAdForcedMovie (args);
		}
	}
	public void finishedResponseAdRequestFSAdForcedMovie(string args) {
		if (OnFinishedResponseAdRequestAdForcedMovie != null) {
			OnFinishedResponseAdRequestAdForcedMovie ();
		}
	}
	public void failedResponseAdRequestFSAdForcedMovie(string args) {
		if (OnFailedResponseAdRequestAdForcedMovie != null) {
			OnFailedResponseAdRequestAdForcedMovie (args);
		}
	}
	public void emptyAdResponseAdRequestFSAdForcedMovie(string args) {
		if (OnEmptyResponseAdRequestAdForcedMovie != null) {
			OnEmptyResponseAdRequestAdForcedMovie ();
		}
	}
	public void finishedReadyMovieFSAdForcedMovie(string args) {
		if (OnFinishedReadyMovieAdForcedMovie != null) {
			OnFinishedReadyMovieAdForcedMovie ();
		}
	}
	public void failedReadyMovieFSAdForcedMovie(string args) {
		if (OnFailedReadyMovieAdForcedMovie != null) {
			OnFailedReadyMovieAdForcedMovie (args);
		}
	}
	public void finishedCreateFSAdForcedMovie(string args) {
		if (OnFinishedCreateAdForcedMovie != null) {
			OnFinishedCreateAdForcedMovie ();
		}
	}
	public void failedCreateFSAdForcedMovie(string args) {
		if (OnFailedCreateAdForcedMovie != null) {
			OnFailedCreateAdForcedMovie (args);
		}
	}
	public void completedMovieFSAdForcedMovie(string args) {
		if (OnCompletedMovieAdForcedMovie != null) {
			OnCompletedMovieAdForcedMovie ();
		}
	}
	public void finishedAdClickFSAdForcedMovie(string args) {
		if (OnFinishedAdClickAdForcedMovie != null) {
			OnFinishedAdClickAdForcedMovie ();
		}
	}
	public void failedAdClickFSAdForcedMovie(string args) {
		if (OnFailedAdClickAdForcedMovie != null) {
			OnFailedAdClickAdForcedMovie (args);
		}
	}
	public void hideAdViewFSAdForcedMovie(string args) {
		if (OnHideAdViewAdForcedMovie != null) {
			OnHideAdViewAdForcedMovie ();
		}
	}

	// FSAdRectangleBannerViewDelegate
	public delegate void AdRectangleBannerViewFinishInitDelegate();
	public delegate void AdRectangleBannerViewFailedInitDelegate(string error);
	public delegate void AdRectangleBannerViewFailedSendAdRequestDelegate (string error);
	public delegate void AdRectangleBannerViewFinishedResponseAdRequestDelegate ();
	public delegate void AdRectangleBannerViewFailedResponseAdRequestDelegate (string error);
	public delegate void AdRectangleBannerViewEmptyResponseAdRequestDelegate ();
	public delegate void AdRectangleBannerViewFinishedCreateDelegate();
	public delegate void AdRectangleBannerViewFailedCreateDelegate(string error);
	public delegate void AdRectangleBannerViewFinishedAdClickDelegate();
	public delegate void AdRectangleBannerViewFailedAdClickDelegate(string error);

	public static AdRectangleBannerViewFinishInitDelegate 					OnFinishInitAdRectangleBannerView;
	public static AdRectangleBannerViewFailedInitDelegate 					OnFailedInitAdRectangleBannerView;
	public static AdRectangleBannerViewFailedSendAdRequestDelegate 			OnFailedSendAdRequestAdRectangleBannerView;
	public static AdRectangleBannerViewFinishedResponseAdRequestDelegate	OnFinishedResponseAdRequestAdRectangleBannerView;
	public static AdRectangleBannerViewFailedResponseAdRequestDelegate 		OnFailedResponseAdRequestAdRectangleBannerView;
	public static AdRectangleBannerViewEmptyResponseAdRequestDelegate 		OnEmptyResponseAdRequestAdRectangleBannerView;
	public static AdRectangleBannerViewFinishedCreateDelegate 				OnFinishedCreateAdRectangleBannerView;
	public static AdRectangleBannerViewFailedCreateDelegate 				OnFailedCreateAdRectangleBannerView;
	public static AdRectangleBannerViewFinishedAdClickDelegate 				OnFinishedAdClickAdRectangleBannerView;
	public static AdRectangleBannerViewFailedAdClickDelegate 				OnFailedAdClickAdRectangleBannerView;

	public void finishInitAdFSAdRectangleBannerView(string args) {
		if (OnFinishInitAdRectangleBannerView != null) {
			OnFinishInitAdRectangleBannerView ();
		}
	}
	public void failedInitAdFSAdRectangleBannerView(string args) {
		if (OnFailedInitAdRectangleBannerView != null) {
			OnFailedInitAdRectangleBannerView (args);
		}
	}
	public void failedSendAdRequestFSAdRectangleBannerView(string args) {
		if (OnFailedSendAdRequestAdRectangleBannerView != null) {
			OnFailedSendAdRequestAdRectangleBannerView (args);
		}
	}
	public void finishedResponseAdRequestFSAdRectangleBannerView(string args) {
		if (OnFinishedResponseAdRequestAdRectangleBannerView != null) {
			OnFinishedResponseAdRequestAdRectangleBannerView ();
		}
	}
	public void failedResponseAdRequestFSAdRectangleBannerView(string args) {
		if (OnFailedResponseAdRequestAdRectangleBannerView != null) {
			OnFailedResponseAdRequestAdRectangleBannerView (args);
		}
	}
	public void emptyAdResponseAdRequestFSAdRectangleBannerView(string args) {
		if (OnEmptyResponseAdRequestAdRectangleBannerView != null) {
			OnEmptyResponseAdRequestAdRectangleBannerView ();
		}
	}
	public void finishedCreateFSAdRectangleBannerView(string args) {
		if (OnFinishedCreateAdRectangleBannerView != null) {
			OnFinishedCreateAdRectangleBannerView ();
		}
	}
	public void failedCreateFSAdRectangleBannerView(string args) {
		if (OnFailedCreateAdRectangleBannerView != null) {
			OnFailedCreateAdRectangleBannerView (args);
		}
	}
	public void finishedAdClickFSAdRectangleBannerView(string args) {
		if (OnFinishedAdClickAdRectangleBannerView != null) {
			OnFinishedAdClickAdRectangleBannerView ();
		}
	}
	public void failedAdClickFSAdRectangleBannerView(string args) {
		if (OnFailedAdClickAdRectangleBannerView != null) {
			OnFailedAdClickAdRectangleBannerView (args);
		}
	}

//// Unity Editor
#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IPHONE)

	static public void Configure() {}

	// Option
	static public void debugLogEnable(bool enable) {}
	static public void testModeEnable(bool enable) {}

	// Ad Banner
	static public void initAdBannerView(string adUnitId, int x, int y, int w, int h) {}
	static public void hideAdBannerView() {}
	static public void loadAndShowAdBannerView() {}
	static public void pauseAdBannerView() {}
	static public void resumeAdBannerView() {}
	static public void setRectAdBannerView(int x, int y, int w, int h) {}

	// Ad Double Banner
	static public void initAdDoubleBannerView(string adUnitId, int x, int y, int w, int h) {}
	static public void hideAdDoubleBannerView() {}
	static public void loadAndShowAdDoubleBannerView() {}
	static public void pauseAdDoubleBannerView() {}
	static public void resumeAdDoubleBannerView() {}
	static public void setRectAdDoubleBannerView(int x, int y, int w, int h) {}

	// Ad Twin Panel
	static public void initAdTwinPanelView(string adUnitId, int x, int y, int w, int h) {}
	static public void hideAdTwinPanelView() {}
	static public void loadAndShowAdTwinPanelView() {}
	static public void pauseAdTwinPanelView() {}
	static public void resumeAdTwinPanelView() {}
	static public void setRectAdTwinPanelView(int x, int y, int w, int h) {}

	// Ad Interstitial
	static public void initAdInterstitial(string adUnitId) {}
	static public void initSetAdInterstitial(string adUnitId, int intervalTime, int skipCount) {}
	static public void loadAdInterstitial(string adUnitId) {}
	static public void showAdInterstitial(string adUnitId) {}
	static public void hideAdInterstitial() {}
	static public bool isReadyAdInterstitial(string adUnitId) { return false; }

	// Ad Popup
	static public void initAdPopup(string adUnitId) {}
	static public void initSetAdPopup(string adUnitId, int intervalTime, int skipCount) {}
	static public void loadAdPopup(string adUnitId) {}
	static public void showAdPopup(string adUnitId) {}
	static public void hideAdPopup() {}

	// Ad Slide In
	static public void initAdSlidein(string adUnitId) {}
	static public void initSetAdSlidein(string adUnitId, int intervalTime, int skipCount, int displayTime) {}
	static public void loadAdSlidein(string adUnitId) {}
	static public void showAdSlidein(string adUnitId) {}
	static public void hideAdSlidein() {}

	// Ad Picture in Picture
	static public void initAdPiP(string adUnitId) {}
	static public void loadAdPiP(string adUnitId) {}
	static public void createAdPiP(string adUnitId) {}
	static public void loadAndCreateAdPiP(string adUnitId) {}
	static public void showAdPiP(string adUnitId) {}
	static public void showPosAdPiP(string adUnitId, int positionType) {}
	static public void hideAdPiP(string adUnitId) {}
	static public bool isReadyAdPiP(string adUnitId) { return false; }
	static public bool isDisplayAdPiP(string adUnitId) { return false; }

	// Ad Forced Movie
	static public void initAdForcedMovie(string adUnitId) {}
	static public void loadAdForcedMovie(string adUnitId) {}
	static public void createAdForcedMovie(string adUnitId) {}
	static public void loadAndCreateAdForcedMovie(string adUnitId) {}
	static public void showAdForcedMovie(string adUnitId) {}
	static public void hideAdForcedMovie(string adUnitId) {}
	static public bool isReadyAdForcedMovie(string adUnitId) { return false; }
	static public bool isDisplayAdForcedMovie(string adUnitId) { return false; }

	// Ad Rectangle Banner
	static public void initAdRectangleBannerView(string adUnitId, int x, int y, int w, int h) {}
	static public void hideAdRectangleBannerView() {}
	static public void loadAndShowAdRectangleBannerView() {}
	static public void pauseAdRectangleBannerView() {}
	static public void resumeAdRectangleBannerView() {}
	static public void setRectAdRectangleBannerView(int x, int y, int w, int h) {}

//// iOS
#elif UNITY_IPHONE && !UNITY_EDITOR

	static public void Configure() {
		// iOS関係の初期化
		// 現在は特に必要なし
	}

	// Option
	[DllImport ("__Internal")]
	extern static public void debugLogEnable(bool enable);
	[DllImport ("__Internal")]
	extern static public void testModeEnable(bool enable);

	// Ad Banner
	[DllImport ("__Internal")]
	extern static public void initAdBannerView(string adUnitId, int x, int y, int w, int h);
	[DllImport ("__Internal")]
	extern static public void hideAdBannerView();
	[DllImport ("__Internal")]
	extern static public void loadAndShowAdBannerView();
	[DllImport ("__Internal")]
	extern static public void pauseAdBannerView();
	[DllImport ("__Internal")]
	extern static public void resumeAdBannerView();
	[DllImport ("__Internal")]
	extern static public void setRectAdBannerView(int x, int y, int w, int h);

	// Ad Double Banner
	[DllImport ("__Internal")]
	extern static public void initAdDoubleBannerView(string adUnitId, int x, int y, int w, int h);
	[DllImport ("__Internal")]
	extern static public void hideAdDoubleBannerView();
	[DllImport ("__Internal")]
	extern static public void loadAndShowAdDoubleBannerView();
	[DllImport ("__Internal")]
	extern static public void pauseAdDoubleBannerView();
	[DllImport ("__Internal")]
	extern static public void resumeAdDoubleBannerView();
	[DllImport ("__Internal")]
	extern static public void setRectAdDoubleBannerView(int x, int y, int w, int h);

	// Ad Twin Panel
	[DllImport ("__Internal")]
	extern static public void initAdTwinPanelView(string adUnitId, int x, int y, int w, int h);
	[DllImport ("__Internal")]
	extern static public void hideAdTwinPanelView();
	[DllImport ("__Internal")]
	extern static public void loadAndShowAdTwinPanelView();
	[DllImport ("__Internal")]
	extern static public void pauseAdTwinPanelView();
	[DllImport ("__Internal")]
	extern static public void resumeAdTwinPanelView();
	[DllImport ("__Internal")]
	extern static public void setRectAdTwinPanelView(int x, int y, int w, int h);

	// Ad Interstitial
	[DllImport ("__Internal")]
	extern static public void initAdInterstitial(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void initSetAdInterstitial(string adUnitId, int intervalTime, int skipCount);
	[DllImport ("__Internal")]
	extern static public void loadAdInterstitial(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void showAdInterstitial(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void hideAdInterstitial();
	[DllImport ("__Internal")]
	extern static public bool isReadyAdInterstitial(string adUnitId);

	// Ad Popup
	[DllImport ("__Internal")]
	extern static public void initAdPopup(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void initSetAdPopup(string adUnitId, int intervalTime, int skipCount);
	[DllImport ("__Internal")]
	extern static public void loadAdPopup(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void showAdPopup(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void hideAdPopup();

	// Ad Slide In
	[DllImport ("__Internal")]
	extern static public void initAdSlidein(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void initSetAdSlidein(string adUnitId, int intervalTime, int skipCount, int displayTime);
	[DllImport ("__Internal")]
	extern static public void loadAdSlidein(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void showAdSlidein(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void hideAdSlidein();

	// Ad Picture in Picture
	[DllImport ("__Internal")]
	extern static public void initAdPiP(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void loadAdPiP(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void createAdPiP(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void loadAndCreateAdPiP(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void showAdPiP(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void showPosAdPiP(string adUnitId, int positionType);
	[DllImport ("__Internal")]
	extern static public void hideAdPiP(string adUnitId);
	[DllImport ("__Internal")]
	extern static public bool isReadyAdPiP(string adUnitId);
	[DllImport ("__Internal")]
	extern static public bool isDisplayAdPiP(string adUnitId);

	// Ad Forced Movie
	[DllImport ("__Internal")]
	extern static public void initAdForcedMovie(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void loadAdForcedMovie(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void createAdForcedMovie(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void loadAndCreateAdForcedMovie(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void showAdForcedMovie(string adUnitId);
	[DllImport ("__Internal")]
	extern static public void hideAdForcedMovie(string adUnitId);
	[DllImport ("__Internal")]
	extern static public bool isReadyAdForcedMovie(string adUnitId);
	[DllImport ("__Internal")]
	extern static public bool isDisplayAdForcedMovie(string adUnitId);

	// Ad Rectangle Banner
	[DllImport ("__Internal")]
	extern static public void initAdRectangleBannerView(string adUnitId, int x, int y, int w, int h);
	[DllImport ("__Internal")]
	extern static public void hideAdRectangleBannerView();
	[DllImport ("__Internal")]
	extern static public void loadAndShowAdRectangleBannerView();
	[DllImport ("__Internal")]
	extern static public void pauseAdRectangleBannerView();
	[DllImport ("__Internal")]
	extern static public void resumeAdRectangleBannerView();
	[DllImport ("__Internal")]
	extern static public void setRectAdRectangleBannerView(int x, int y, int w, int h);

//// Android
#elif UNITY_ANDROID && !UNITY_EDITOR

	static bool adr_initialized = false;
	static AndroidJavaClass class_UnityPlayer;

	static public void Configure() {
		Debug.Log ("FSAdNetwork - Configure Android");
		// Android関係の初期化
		if(!adr_initialized) {
			AndroidInitializePlugin();

			initFSAdNetwork();
		}
	}


	static IntPtr class_UnityFSAd              		= IntPtr.Zero;

	static IntPtr method_initFSAdNetwork			= IntPtr.Zero;
	static IntPtr method_setTestMode           		= IntPtr.Zero;
	static IntPtr method_setLogMode            		= IntPtr.Zero;

	static IntPtr method_initAdBanner          		= IntPtr.Zero;
	static IntPtr method_loadAndShowBanner     		= IntPtr.Zero;
	static IntPtr method_pauseAdBanner         		= IntPtr.Zero;
	static IntPtr method_resumeAdBanner        		= IntPtr.Zero;
	static IntPtr method_hideAdBanner				= IntPtr.Zero;

	static IntPtr method_initAdDoubleBanner			= IntPtr.Zero;
	static IntPtr method_loadAndShowDoubleBanner	= IntPtr.Zero;
	static IntPtr method_pauseAdDoubleBanner		= IntPtr.Zero;
	static IntPtr method_resumeAdDoubleBanner		= IntPtr.Zero;
	static IntPtr method_hideAdDoubleBanner			= IntPtr.Zero;

	static IntPtr method_initAdTwinPanel         	= IntPtr.Zero;
	static IntPtr method_loadAndShowTwinPanel    	= IntPtr.Zero;
	static IntPtr method_pauseAdTwinPanel		 	= IntPtr.Zero;
	static IntPtr method_resumeAdTwinPanel		 	= IntPtr.Zero;
	static IntPtr method_hideAdTwinPanel			= IntPtr.Zero;

	static IntPtr method_initAdInterstitial    		= IntPtr.Zero;
	static IntPtr method_loadAdInterstitial    		= IntPtr.Zero;
	static IntPtr method_showAdInterstitial    		= IntPtr.Zero;
	static IntPtr method_hideAdInterstitial    		= IntPtr.Zero;
	static IntPtr method_isReadyAdInterstitial 		= IntPtr.Zero;

	static IntPtr method_initAdPopup           		= IntPtr.Zero;
	static IntPtr method_loadAdPopup           		= IntPtr.Zero;
	static IntPtr method_showAdPopup           		= IntPtr.Zero;
	static IntPtr method_hideAdPopup           		= IntPtr.Zero;

	static IntPtr method_initAdSlideIn         		= IntPtr.Zero;
	static IntPtr method_loadAdSlideIn         		= IntPtr.Zero;
	static IntPtr method_showAdSlideIn         		= IntPtr.Zero;
	static IntPtr method_hideAdSlideIn         		= IntPtr.Zero;

	static IntPtr method_initAdPiP             		= IntPtr.Zero;
	static IntPtr method_loadAdPiP             		= IntPtr.Zero;
	static IntPtr method_showAdPiP             		= IntPtr.Zero;
	static IntPtr method_hideAdPiP             		= IntPtr.Zero;
	static IntPtr method_isReadyAdPiP          		= IntPtr.Zero;
	static IntPtr method_isDisplayAdPiP        		= IntPtr.Zero;

	static IntPtr method_initAdForceMovieAd    		= IntPtr.Zero;
	static IntPtr method_loadAdForceMovieAd    		= IntPtr.Zero;
	static IntPtr method_showAdForceMovieAd    		= IntPtr.Zero;
	static IntPtr method_hideAdForceMovieAd    		= IntPtr.Zero;
	static IntPtr method_isReadyAdForceMovieAd    	= IntPtr.Zero;
	static IntPtr method_isDisplayAdForceMovieAd  	= IntPtr.Zero;

	static IntPtr method_initAdRectangleBanner          	= IntPtr.Zero;
	static IntPtr method_loadAndShowRectangleBanner     	= IntPtr.Zero;
	static IntPtr method_pauseAdRectangleBanner         	= IntPtr.Zero;
	static IntPtr method_resumeAdRectangleBanner        	= IntPtr.Zero;
	static IntPtr method_hideAdRectangleBanner				= IntPtr.Zero;

	static void AndroidInitializePlugin() {
		bool success = true;
		IntPtr local_class_UnityFSAd = AndroidJNI.FindClass("jp/co/fullspeed/polymorphicads/adapter/FSAdNetworkUnityPlugin");
		if (local_class_UnityFSAd != IntPtr.Zero) {
			class_UnityFSAd = AndroidJNI.NewGlobalRef( local_class_UnityFSAd );
			AndroidJNI.DeleteLocalRef( local_class_UnityFSAd );
		} else {
			success = false;
		}

		if (success) {

			class_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

			method_initFSAdNetwork = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "initFSAdNetwork", "(Landroid/app/Activity;)V" );
			method_setTestMode = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "setTestMode", "(Z)V" );
			method_setLogMode = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "setLogMode", "(Z)V" );

			method_initAdBanner = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "initAdBanner", "(Ljava/lang/String;)V" );
			method_loadAndShowBanner = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "loadAndShowBanner", "(Ljava/lang/String;)V" );
			method_pauseAdBanner = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "pauseAdBanner", "(Ljava/lang/String;)V" );
			method_resumeAdBanner = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "resumeAdBanner", "(Ljava/lang/String;)V" );
			method_hideAdBanner = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "hideAdBanner", "(Ljava/lang/String;)V" );

			method_initAdDoubleBanner = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "initAdDoubleBanner", "(Ljava/lang/String;)V" );
			method_loadAndShowDoubleBanner = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "loadAndShowDoubleBanner", "(Ljava/lang/String;)V" );
			method_pauseAdDoubleBanner = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "pauseAdDoubleBanner", "(Ljava/lang/String;)V" );
			method_resumeAdDoubleBanner = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "resumeAdDoubleBanner", "(Ljava/lang/String;)V" );
			method_hideAdDoubleBanner = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "hideAdDoubleBanner", "(Ljava/lang/String;)V" );

			method_initAdTwinPanel = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "initAdTwinPanel", "(Ljava/lang/String;)V" );
			method_loadAndShowTwinPanel = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "loadAndShowAdTwinPanel", "(Ljava/lang/String;)V" );
			method_pauseAdTwinPanel = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "pauseAdTwinPanel", "(Ljava/lang/String;)V" );
			method_resumeAdTwinPanel = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "resumeAdTwinPanel", "(Ljava/lang/String;)V" );
			method_hideAdTwinPanel = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "hideAdTwinPanel", "(Ljava/lang/String;)V" );

			method_initAdInterstitial = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "initAdInterstitial", "(Ljava/lang/String;II)V" );
			method_loadAdInterstitial = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "loadAdInterstitial", "(Ljava/lang/String;)V" );
			method_showAdInterstitial = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "showAdInterstitial", "(Ljava/lang/String;)V" );
			method_hideAdInterstitial = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "hideAdInterstitial", "(Ljava/lang/String;)V" );
			method_isReadyAdInterstitial = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "isReadyAdInterstitial", "(Ljava/lang/String;)Z" );

			method_initAdPopup = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "initAdPopup", "(Ljava/lang/String;II)V" );
			method_loadAdPopup = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "loadAdPopup", "(Ljava/lang/String;)V" );
			method_showAdPopup = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "showAdPopup", "(Ljava/lang/String;)V" );
			method_hideAdPopup = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "hideAdPopup", "(Ljava/lang/String;)V" );

			method_initAdSlideIn = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "initAdSlideIn", "(Ljava/lang/String;III)V" );
			method_loadAdSlideIn = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "loadAdSlideIn", "(Ljava/lang/String;)V" );
			method_showAdSlideIn = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "showAdSlideIn", "(Ljava/lang/String;)V" );
			method_hideAdSlideIn = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "hideAdSlideIn", "(Ljava/lang/String;)V" );

			method_initAdPiP = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "initAdPiP", "(Ljava/lang/String;)V" );
			method_loadAdPiP = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "loadAdPiP", "(Ljava/lang/String;)V" );
			method_showAdPiP = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "showAdPiP", "(Ljava/lang/String;I)V" );
			method_hideAdPiP = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "hideAdPiP", "(Ljava/lang/String;)V" );
			method_isReadyAdPiP = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "isReadyAdPiP", "(Ljava/lang/String;)Z" );
			method_isDisplayAdPiP = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "isDisplayAdPiP", "(Ljava/lang/String;)Z" );

			method_initAdForceMovieAd = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "initAdForceMovieAd", "(Ljava/lang/String;)V" );
			method_loadAdForceMovieAd = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "loadAdForceMovieAd", "(Ljava/lang/String;)V" );
			method_showAdForceMovieAd = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "showAdForceMovieAd", "(Ljava/lang/String;)V" );
			method_hideAdForceMovieAd = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "hideAdForceMovieAd", "(Ljava/lang/String;)V" );
			method_isReadyAdForceMovieAd = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "isReadyAdForceMovieAd", "(Ljava/lang/String;)Z" );
			method_isDisplayAdForceMovieAd = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "isDisplayAdForceMovieAd", "(Ljava/lang/String;)Z" );

			method_initAdRectangleBanner = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "initAdRectangleBanner", "(Ljava/lang/String;)V" );
			method_loadAndShowRectangleBanner = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "loadAndShowRectangleBanner", "(Ljava/lang/String;)V" );
			method_pauseAdRectangleBanner = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "pauseAdRectangleBanner", "(Ljava/lang/String;)V" );
			method_resumeAdRectangleBanner = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "resumeAdRectangleBanner", "(Ljava/lang/String;)V" );
			method_hideAdRectangleBanner = AndroidJNI.GetStaticMethodID( class_UnityFSAd, "hideAdRectangleBanner", "(Ljava/lang/String;)V" );

			adr_initialized = true;

		} else {
			// adcolony.jar most both be in Assets/Plugins/Android/ !
			Debug.LogError( "FSAdNetwork configuration error - make sure polymorphicads-ad-sdk-x.x.x.aar"
				+ "libraries are in your Unity project's Assets/Plugins/Android folder." );
		}
	}

	static public void initFSAdNetwork() {
		// plugin init
		Debug.Log ("FSAdNetwork - Plugin Init Android");
		jvalue[] args = new jvalue[1];
		var j_activity = class_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
		args[0].l = j_activity.GetRawObject();
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_initFSAdNetwork, args );
	}


	// Option
	static public void debugLogEnable(bool enable) {
		jvalue[] args = new jvalue[1];
		args[0].z = enable;
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_setLogMode, args );
	}
	static public void testModeEnable(bool enable) {
		jvalue[] args = new jvalue[1];
		args[0].z = enable;
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_setTestMode, args );
	}

	// Ad Banner
	static private string bannerAdUnitId = "";
	static public void initAdBannerView(string adUnitId, int x, int y, int w, int h) {
		bannerAdUnitId = adUnitId;
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_initAdBanner, args );
	}
	static public void hideAdBannerView() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( bannerAdUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_hideAdBanner, args );
	}
	static public void loadAndShowAdBannerView() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( bannerAdUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_loadAndShowBanner, args );
	}
	static public void pauseAdBannerView() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( bannerAdUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_pauseAdBanner, args );
	}
	static public void resumeAdBannerView() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( bannerAdUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_resumeAdBanner, args );
	}
	static public void setRectAdBannerView(int x, int y, int w, int h) {

	}


	// Ad Double Banner
	static private string doubleBannerAdUnitId = "";
	static public void initAdDoubleBannerView(string adUnitId, int x, int y, int w, int h) {
	Debug.Log ("FSAdNetwork - initAdDoubleBannerView");
		doubleBannerAdUnitId = adUnitId;
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_initAdDoubleBanner, args );
	}
	static public void hideAdDoubleBannerView() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( doubleBannerAdUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_hideAdDoubleBanner, args );
	}
	static public void loadAndShowAdDoubleBannerView() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( doubleBannerAdUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_loadAndShowDoubleBanner, args );
	}
	static public void pauseAdDoubleBannerView() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( doubleBannerAdUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_pauseAdDoubleBanner, args );
	}
	static public void resumeAdDoubleBannerView() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( doubleBannerAdUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_resumeAdDoubleBanner, args );
	}
	static public void setRectAdDoubleBannerView(int x, int y, int w, int h) {

	}


	// Ad Twin Panel
	static private string twinPanelAdUnitId = "";
	static public void initAdTwinPanelView(string adUnitId, int x, int y, int w, int h) {
		twinPanelAdUnitId = adUnitId;
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_initAdTwinPanel, args );
	}
	static public void hideAdTwinPanelView() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( twinPanelAdUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_hideAdTwinPanel, args );
	}
	static public void loadAndShowAdTwinPanelView() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( twinPanelAdUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_loadAndShowTwinPanel, args );
	}
	static public void pauseAdTwinPanelView() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( twinPanelAdUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_pauseAdTwinPanel, args );
	}
	static public void resumeAdTwinPanelView() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( twinPanelAdUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_resumeAdTwinPanel, args );
	}
	static public void setRectAdTwinPanelView(int x, int y, int w, int h) {

	}


	// Ad Interstitial
	static private string _adUnitIdInterstitial;
	static public void initAdInterstitial(string adUnitId) {
	Debug.Log ("FSAdNetwork - initAdInterstitial Android");

		_adUnitIdInterstitial = adUnitId;
		jvalue[] args = new jvalue[3];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		args[1].i = 0;
		args[2].i = 0;
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_initAdInterstitial, args );
	}
	static public void initSetAdInterstitial(string adUnitId, int intervalTime, int skipCount) {
		_adUnitIdInterstitial = adUnitId;
		jvalue[] args = new jvalue[3];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		args[1].i = intervalTime;
		args[2].i = skipCount;
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_initAdInterstitial, args );
	}
	static public void loadAdInterstitial(string adUnitId) {
	Debug.Log ("FSAdNetwork - loadAdInterstitial Android");

		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_loadAdInterstitial, args );
	}
	static public void showAdInterstitial(string adUnitId) {
	Debug.Log ("FSAdNetwork - showAdInterstitial Android");

		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_showAdInterstitial, args );
	}
	static public void hideAdInterstitial() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( _adUnitIdInterstitial );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_hideAdInterstitial, args );
	}
	static public bool isReadyAdInterstitial(string adUnitId) { 
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		return AndroidJNI.CallStaticBooleanMethod( class_UnityFSAd, method_isReadyAdInterstitial, args );
	}


	// Ad Popup
	static private string _adUnitIdPopup;
	static public void initAdPopup(string adUnitId) {
		_adUnitIdPopup = adUnitId;
		jvalue[] args = new jvalue[3];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		args[1].i = 0;
		args[2].i = 0;
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_initAdPopup, args );
	}
	static public void initSetAdPopup(string adUnitId, int intervalTime, int skipCount) {
		_adUnitIdPopup = adUnitId;
		jvalue[] args = new jvalue[3];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		args[1].i = intervalTime;
		args[2].i = skipCount;
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_initAdPopup, args );
	}
	static public void loadAdPopup(string adUnitId) {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_loadAdPopup, args );
	}
	static public void showAdPopup(string adUnitId) {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_showAdPopup, args );
	}
	static public void hideAdPopup() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( _adUnitIdPopup );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_hideAdPopup, args );
	}


	// Ad Slide In
	static string _adUnitIdSlidein;
	static public void initAdSlidein(string adUnitId) {
		_adUnitIdSlidein = adUnitId;
		jvalue[] args = new jvalue[4];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		args[1].i = 0;
		args[2].i = 0;
		args[3].i = 10;
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_initAdSlideIn, args );
	}
	static public void initSetAdSlidein(string adUnitId, int intervalTime, int skipCount, int displayTime) {
		_adUnitIdSlidein = adUnitId;
		jvalue[] args = new jvalue[4];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		args[1].i = intervalTime;
		args[2].i = skipCount;
		args[3].i = displayTime;
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_initAdSlideIn, args );
	}
	static public void loadAdSlidein(string adUnitId) {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_loadAdSlideIn, args );
	}
	static public void showAdSlidein(string adUnitId) {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_showAdSlideIn, args );
	}
	static public void hideAdSlidein() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( _adUnitIdSlidein );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_hideAdSlideIn, args );
	}


	// Ad Picture in Picture
	static public void initAdPiP(string adUnitId) {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_initAdPiP, args );
	}
	static public void loadAdPiP(string adUnitId) {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_loadAdPiP, args );
	}
	static public void createAdPiP(string adUnitId) {}
	static public void loadAndCreateAdPiP(string adUnitId) {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_loadAdPiP, args );
	}
	static public void showAdPiP(string adUnitId) {
		jvalue[] args = new jvalue[2];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		args[1].i = 3;
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_showAdPiP, args );
	}
	static public void showPosAdPiP(string adUnitId, int positionType) {
		jvalue[] args = new jvalue[2];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		args[1].i = positionType;
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_showAdPiP, args );
	}
	static public void hideAdPiP(string adUnitId) {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_hideAdPiP, args );
	}
	static public bool isReadyAdPiP(string adUnitId) { 
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		return AndroidJNI.CallStaticBooleanMethod( class_UnityFSAd, method_isReadyAdPiP, args );
	}
	static public bool isDisplayAdPiP(string adUnitId) { 
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		return AndroidJNI.CallStaticBooleanMethod( class_UnityFSAd, method_isDisplayAdPiP, args );
	}


	// Ad Forced Movie
	static public void initAdForcedMovie(string adUnitId) {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_initAdForceMovieAd, args );
	}
	static public void loadAdForcedMovie(string adUnitId) {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_loadAdForceMovieAd, args );
	}
	static public void createAdForcedMovie(string adUnitId) {}
	static public void loadAndCreateAdForcedMovie(string adUnitId) {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_loadAdForceMovieAd, args );
	}
	static public void showAdForcedMovie(string adUnitId) {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_showAdForceMovieAd, args );
	}
	static public void hideAdForcedMovie(string adUnitId) {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_hideAdForceMovieAd, args );
	}
	static public bool isReadyAdForcedMovie(string adUnitId) { 
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		return AndroidJNI.CallStaticBooleanMethod( class_UnityFSAd, method_isReadyAdForceMovieAd, args );
	}
	static public bool isDisplayAdForcedMovie(string adUnitId) { 
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		return AndroidJNI.CallStaticBooleanMethod( class_UnityFSAd, method_isDisplayAdForceMovieAd, args );
	}


	// Ad Rectangle Banner
	static private string rectangleBannerAdUnitId = "";
	static public void initAdRectangleBannerView(string adUnitId, int x, int y, int w, int h) {
		rectangleBannerAdUnitId = adUnitId;
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( adUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_initAdRectangleBanner, args );
	}
	static public void hideAdRectangleBannerView() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( rectangleBannerAdUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_hideAdRectangleBanner, args );
	}
	static public void loadAndShowAdRectangleBannerView() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( rectangleBannerAdUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_loadAndShowRectangleBanner, args );
	}
	static public void pauseAdRectangleBannerView() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( rectangleBannerAdUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_pauseAdRectangleBanner, args );
	}
	static public void resumeAdRectangleBannerView() {
		jvalue[] args = new jvalue[1];
		args[0].l = AndroidJNI.NewStringUTF( rectangleBannerAdUnitId );
		AndroidJNI.CallStaticVoidMethod( class_UnityFSAd, method_resumeAdRectangleBanner, args );
	}
	static public void setRectAdRectangleBannerView(int x, int y, int w, int h) {

	}

#endif

}
