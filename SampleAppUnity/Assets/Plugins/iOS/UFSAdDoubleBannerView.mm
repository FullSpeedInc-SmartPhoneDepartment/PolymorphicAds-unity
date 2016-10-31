//
//  UFSAdBannerView.m
//  SampleApp
//
//  Created by RN-079 on 2016/06/03.
//
//
#import <FSAdNetwork/FSAdDoubleBannerView.h>


#pragma mark - UAdDoubleBannerView

@interface UAdDoubleBannerView : NSObject <FSAdDoubleBannerViewDelegate>
{
}

@property (nonatomic, strong) FSAdDoubleBannerView* adView;

@end


@implementation UAdDoubleBannerView

+ (instancetype)sharedInstance
{
    static id sharedInstance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        UAdDoubleBannerView *loader = [[self alloc] init];
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
    self.adView = [[FSAdDoubleBannerView alloc] initWithFrame:CGRectMake(x, y, w, h)];
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

- (void)finishInitAdFSAdDoubleBannerView:(FSAdDoubleBannerView *)sender
{
    UnitySendMessage("FSAdNetwork", "finishInitAdFSAdDoubleBannerView", "" );
}

- (void)failedInitAdFSAdDoubleBannerView:(FSAdDoubleBannerView *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedInitAdFSAdDoubleBannerView", [error.errorMessage UTF8String] );
}

- (void)failedSendAdRequestFSAdDoubleBannerView:(FSAdDoubleBannerView *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedSendAdRequestFSAdDoubleBannerView", [error.errorMessage UTF8String] );
}

- (void)finishedResponseAdRequestFSAdDoubleBannerView:(FSAdDoubleBannerView *)sender
{
    UnitySendMessage("FSAdNetwork", "finishedResponseAdRequestFSAdDoubleBannerView", "" );
}

- (void)failedResponseAdRequestFSAdDoubleBannerView:(FSAdDoubleBannerView *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedResponseAdRequestFSAdDoubleBannerView", [error.errorMessage UTF8String] );
}

- (void)emptyAdResponseAdRequestFSAdDoubleBannerView:(FSAdDoubleBannerView *)sender
{
    UnitySendMessage("FSAdNetwork", "emptyAdResponseAdRequestFSAdDoubleBannerView", "" );
}

- (void)finishedCreateFSAdDoubleBannerView:(FSAdDoubleBannerView *)sender
{
    UnitySendMessage("FSAdNetwork", "finishedCreateFSAdDoubleBannerView", "" );
}

- (void)failedCreateFSAdDoubleBannerView:(FSAdDoubleBannerView *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedCreateFSAdDoubleBannerView", [error.errorMessage UTF8String] );
}

- (void)finishedAdClickFSAdDoubleBannerView:(FSAdDoubleBannerView *)adView
{
    UnitySendMessage("FSAdNetwork", "finishedAdClickFSAdDoubleBannerView", "" );
}

- (void)failedAdClickFSAdDoubleBannerView:(FSAdDoubleBannerView *)adView error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedAdClickFSAdDoubleBannerView", [error.errorMessage UTF8String] );
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
    
    void initAdDoubleBannerView(const char* adUnitId, int x, int y, int w, int h)
    {
        [[UAdDoubleBannerView sharedInstance] initAdBanner:[NSString stringWithUTF8String:adUnitId] x:x y:y w:w h:h];
        
        UIView* adView = [[UAdDoubleBannerView sharedInstance] GetAdBiew];
        UIViewController* parent = UnityGetGLViewController();
        [parent.view addSubview:adView];
    }
    
    void hideAdDoubleBannerView()
    {
        [[UAdDoubleBannerView sharedInstance] hideAdBanner];
    }
    
    void loadAndShowAdDoubleBannerView()
    {
        [[UAdDoubleBannerView sharedInstance] loadAdBanner];
    }
    
    void pauseAdDoubleBannerView()
    {
        [[UAdDoubleBannerView sharedInstance] pauseAdBanner];
    }
    
    void resumeAdDoubleBannerView()
    {
        [[UAdDoubleBannerView sharedInstance] resumeAdBanner];
    }
    
    void setRectAdDoubleBannerView(int x, int y, int w, int h)
    {
        [[UAdDoubleBannerView sharedInstance] setRectAdBanner:x y:y w:w h:h];
    }
    
}


