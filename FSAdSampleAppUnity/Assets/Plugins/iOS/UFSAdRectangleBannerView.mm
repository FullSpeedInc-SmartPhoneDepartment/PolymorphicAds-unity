//
//  UFSAdBannerView.m
//  SampleApp
//
//  Created by RN-079 on 2016/06/03.
//
//
#import <FSAdNetwork/FSAdRectangleBannerView.h>


#pragma mark - UAdRectangleBannerView

@interface UAdRectangleBannerView : NSObject <FSAdRectangleBannerViewDelegate>
{
}

@property (nonatomic, strong) FSAdRectangleBannerView* adView;

@end


@implementation UAdRectangleBannerView

+ (instancetype)sharedInstance
{
    static id sharedInstance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        UAdRectangleBannerView *loader = [[self alloc] init];
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
    self.adView = [[FSAdRectangleBannerView alloc] initWithFrame:CGRectMake(x, y, w, h)];
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

#pragma mark - FSAdRectangleBannerViewDelegate

- (void)finishInitAdFSAdRectangleBannerView:(FSAdRectangleBannerView *)sender
{
    UnitySendMessage("FSAdNetwork", "finishInitAdFSAdRectangleBannerView", "" );
}

- (void)failedInitAdFSAdRectangleBannerView:(FSAdRectangleBannerView *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedInitAdFSAdRectangleBannerView", [error.errorMessage UTF8String]);
}

- (void)failedSendAdRequestFSAdRectangleBannerView:(FSAdRectangleBannerView *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedSendAdRequestFSAdRectangleBannerView", [error.errorMessage UTF8String]);
}

- (void)finishedResponseAdRequestFSAdRectangleBannerView:(FSAdRectangleBannerView *)sender
{
    UnitySendMessage("FSAdNetwork", "finishedResponseAdRequestFSAdRectangleBannerView", "" );
}

- (void)failedResponseAdRequestFSAdRectangleBannerView:(FSAdRectangleBannerView *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedResponseAdRequestFSAdRectangleBannerView", [error.errorMessage UTF8String]);
}

- (void)emptyAdResponseAdRequestFSAdRectangleBannerView:(FSAdRectangleBannerView *)sender
{
    UnitySendMessage("FSAdNetwork", "emptyAdResponseAdRequestFSAdRectangleBannerView", "" );
}

- (void)finishedCreateFSAdRectangleBannerView:(FSAdRectangleBannerView *)sender
{
    UnitySendMessage("FSAdNetwork", "finishedCreateFSAdRectangleBannerView", "" );
}

- (void)failedCreateFSAdRectangleBannerView:(FSAdRectangleBannerView *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedCreateFSAdRectangleBannerView", [error.errorMessage UTF8String]);
}

- (void)finishedAdClickFSAdRectangleBannerView:(FSAdRectangleBannerView *)adView
{
    UnitySendMessage("FSAdNetwork", "finishedAdClickFSAdRectangleBannerView", "" );
}

- (void)failedAdClickFSAdRectangleBannerView:(FSAdRectangleBannerView *)adView error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedAdClickFSAdRectangleBannerView", [error.errorMessage UTF8String]);
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
    
    void initAdRectangleBannerView(const char* adUnitId, int x, int y, int w, int h)
    {
        [[UAdRectangleBannerView sharedInstance] initAdBanner:[NSString stringWithUTF8String:adUnitId] x:x y:y w:w h:h];
        
        UIView* adView = [[UAdRectangleBannerView sharedInstance] GetAdBiew];
        UIViewController* parent = UnityGetGLViewController();
        [parent.view addSubview:adView];
    }
    
    void hideAdRectangleBannerView()
    {
        [[UAdRectangleBannerView sharedInstance] hideAdBanner];
    }
    
    void loadAndShowAdRectangleBannerView()
    {
        [[UAdRectangleBannerView sharedInstance] loadAdBanner];
    }
    
    void pauseAdRectangleBannerView()
    {
        [[UAdRectangleBannerView sharedInstance] pauseAdBanner];
    }
    
    void resumeAdRectangleBannerView()
    {
        [[UAdRectangleBannerView sharedInstance] resumeAdBanner];
    }
    
    void setRectAdRectangleBannerView(int x, int y, int w, int h)
    {
        [[UAdRectangleBannerView sharedInstance] setRectAdBanner:x y:y w:w h:h];
    }
    
}


