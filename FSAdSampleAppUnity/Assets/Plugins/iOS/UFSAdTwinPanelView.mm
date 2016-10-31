//
//  UFSAdBannerView.m
//  SampleApp
//
//  Created by RN-079 on 2016/06/03.
//
//
#import <FSAdNetwork/FSAdTwinPanelView.h>


#pragma mark - UAdTwinPanelView

@interface UAdTwinPanelView : NSObject <FSAdTwinPanelViewDelegate>
{
}

@property (nonatomic, strong) FSAdTwinPanelView* adView;

@end


@implementation UAdTwinPanelView

+ (instancetype)sharedInstance
{
    static id sharedInstance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        UAdTwinPanelView *loader = [[self alloc] init];
        sharedInstance = loader;
    });
    return sharedInstance;
}

- (id)init
{
    self = [super init];
    if (self) {
        
    }
    return self;
}

- (UIView*)GetAdBiew
{
    return self.adView;
}

- (void)hideAdBanner
{
    if (self.adView) {
        self.adView.delegate = nil;
        [self.adView removeFromSuperview];
        self.adView = nil;
    }
}

- (void)initAdBanner:(NSString*)adUnitId x:(int)x y:(int)y w:(int)w h:(int)h
{
    self.adView = [[FSAdTwinPanelView alloc] initWithFrame:CGRectMake(x, y, w, h)];
    self.adView.delegate = self;
    [self.adView initAd:adUnitId];
}

- (void)loadAdBanner
{
    [self.adView loadAd];
}

- (void)pauseAdBanner
{
    [self.adView pause];
}

- (void)resumeAdBanner
{
    [self.adView resume];
}

- (void)setRectAdBanner:(int)x y:(int)y w:(int)w h:(int)h
{
    self.adView.frame = CGRectMake(x, y, w, h);
}


#pragma mark - FSAdTwinPanelViewDelegate

- (void)finishInitAdFSAdTwinPanelView:(FSAdTwinPanelView *)sender
{
    UnitySendMessage("FSAdNetwork", "finishInitAdFSAdTwinPanelView", "" );
}

- (void)failedInitAdFSAdTwinPanelView:(FSAdTwinPanelView *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedInitAdFSAdTwinPanelView", [error.errorMessage UTF8String] );
}

- (void)failedSendAdRequestFSAdTwinPanelView:(FSAdTwinPanelView *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedSendAdRequestFSAdTwinPanelView", [error.errorMessage UTF8String] );
}

- (void)finishedResponseAdRequestFSAdTwinPanelView:(FSAdTwinPanelView *)sender
{
    UnitySendMessage("FSAdNetwork", "finishedResponseAdRequestFSAdTwinPanelView", "" );
}

- (void)failedResponseAdRequestFSAdTwinPanelView:(FSAdTwinPanelView *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedResponseAdRequestFSAdTwinPanelView", [error.errorMessage UTF8String] );
}

- (void)emptyAdResponseAdRequestFSAdTwinPanelView:(FSAdTwinPanelView *)sender
{
    UnitySendMessage("FSAdNetwork", "emptyAdResponseAdRequestFSAdTwinPanelView", "" );
}

- (void)finishedCreateFSAdTwinPanelView:(FSAdTwinPanelView *)sender
{
    UnitySendMessage("FSAdNetwork", "finishedCreateFSAdTwinPanelView", "" );
}

- (void)failedCreateFSAdTwinPanelView:(FSAdTwinPanelView *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedCreateFSAdTwinPanelView", [error.errorMessage UTF8String] );
}

- (void)finishedAdClickFSAdTwinPanelView:(FSAdTwinPanelView *)adView
{
    UnitySendMessage("FSAdNetwork", "finishedAdClickFSAdTwinPanelView", "" );
}

- (void)failedAdClickFSAdTwinPanelView:(FSAdTwinPanelView *)adView error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedAdClickFSAdTwinPanelView", [error.errorMessage UTF8String] );
}

@end


#include <iostream>
using namespace std;

// Unityのバージョンが4.3.4以前であれば
#if UNITY_VERSION <= 434

// Unity4.3.4ではUnityGetGLViewControllerを使用するためにiPhone_Viewのインポートが必要
#import "iPhone_View.h"

#endif

extern "C" {
    
    void initAdTwinPanelView(const char* adUnitId, int x, int y, int w, int h)
    {
        [[UAdTwinPanelView sharedInstance] initAdBanner:[NSString stringWithUTF8String:adUnitId] x:x y:y w:w h:h];
        
        UIView* adView = [[UAdTwinPanelView sharedInstance] GetAdBiew];
        UIViewController* parent = UnityGetGLViewController();
        [parent.view addSubview:adView];
    }
    
    void hideAdTwinPanelView()
    {
        [[UAdTwinPanelView sharedInstance] hideAdBanner];
    }
    
    void loadAndShowAdTwinPanelView()
    {
        [[UAdTwinPanelView sharedInstance] loadAdBanner];
    }
    
    void pauseAdTwinPanelView()
    {
        [[UAdTwinPanelView sharedInstance] pauseAdBanner];
    }
    
    void resumeAdTwinPanelView()
    {
        [[UAdTwinPanelView sharedInstance] resumeAdBanner];
    }
    
    void setRectAdTwinPanelView(int x, int y, int w, int h)
    {
        [[UAdTwinPanelView sharedInstance] setRectAdBanner:x y:y w:w h:h];
    }
    
}


