//
//  UFSAdBannerView.m
//  SampleApp
//
//  Created by RN-079 on 2016/06/03.
//
//
#import <FSAdNetwork/FSAdBannerView.h>


#pragma mark - UAdBannerView

@interface UAdBannerView : NSObject <FSAdBannerViewDelegate>
{
}

@property (nonatomic, strong) FSAdBannerView* adView;

@end


@implementation UAdBannerView

+ (instancetype)sharedInstance
{
    static id sharedInstance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        UAdBannerView *loader = [[self alloc] init];
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
    self.adView = [[FSAdBannerView alloc] initWithFrame:CGRectMake(x, y, w, h)];
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

#pragma mark - FSAdBannerViewDelegate

- (void)finishInitAdFSAdBannerView:(FSAdBannerView *)sender
{
    UnitySendMessage("FSAdNetwork", "finishInitAdFSAdBannerView", "" );
}

- (void)failedInitAdFSAdBannerView:(FSAdBannerView *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedInitAdFSAdBannerView", [error.errorMessage UTF8String]);
}

- (void)failedSendAdRequestFSAdBannerView:(FSAdBannerView *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedSendAdRequestFSAdBannerView", [error.errorMessage UTF8String]);
}

- (void)finishedResponseAdRequestFSAdBannerView:(FSAdBannerView *)sender
{
    UnitySendMessage("FSAdNetwork", "finishedResponseAdRequestFSAdBannerView", "" );
}

- (void)failedResponseAdRequestFSAdBannerView:(FSAdBannerView *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedResponseAdRequestFSAdBannerView", [error.errorMessage UTF8String]);
}

- (void)emptyAdResponseAdRequestFSAdBannerView:(FSAdBannerView *)sender
{
    UnitySendMessage("FSAdNetwork", "emptyAdResponseAdRequestFSAdBannerView", "" );
}

- (void)finishedCreateFSAdBannerView:(FSAdBannerView *)sender
{
    UnitySendMessage("FSAdNetwork", "finishedCreateFSAdBannerView", "" );
}

- (void)failedCreateFSAdBannerView:(FSAdBannerView *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedCreateFSAdBannerView", [error.errorMessage UTF8String]);
}

- (void)finishedAdClickFSAdBannerView:(FSAdBannerView *)adView
{
    UnitySendMessage("FSAdNetwork", "finishedAdClickFSAdBannerView", "" );
}

- (void)failedAdClickFSAdBannerView:(FSAdBannerView *)adView error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedAdClickFSAdBannerView", [error.errorMessage UTF8String]);
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
    
    void initAdBannerView(const char* adUnitId, int x, int y, int w, int h)
    {
        [[UAdBannerView sharedInstance] initAdBanner:[NSString stringWithUTF8String:adUnitId] x:x y:y w:w h:h];
        
        UIView* adView = [[UAdBannerView sharedInstance] GetAdBiew];
        UIViewController* parent = UnityGetGLViewController();
        [parent.view addSubview:adView];
    }
    
    void hideAdBannerView()
    {
        [[UAdBannerView sharedInstance] hideAdBanner];
    }
    
    void loadAndShowAdBannerView()
    {
        [[UAdBannerView sharedInstance] loadAdBanner];
    }
    
    void pauseAdBannerView()
    {
        [[UAdBannerView sharedInstance] pauseAdBanner];
    }
    
    void resumeAdBannerView()
    {
        [[UAdBannerView sharedInstance] resumeAdBanner];
    }
    
    void setRectAdBannerView(int x, int y, int w, int h)
    {
        [[UAdBannerView sharedInstance] setRectAdBanner:x y:y w:w h:h];
    }
    
}


