//
//  UFSAdInterstitialAdLoader.m
//  SampleApp
//
//  Created by RN-079 on 2016/06/03.
//
//
#import <FSAdNetwork/FSAdInterstitialAdLoader.h>


#pragma mark - UAdInterstitialAdLoader

@interface UAdInterstitialAdLoader : NSObject <FSAdInterstitialAdLoaderDelegate>
{
}

@end

@implementation UAdInterstitialAdLoader

+ (instancetype)sharedInstance
{
    static id sharedInstance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        UAdInterstitialAdLoader *loader = [[self alloc] init];
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

- (void)initAd:(NSString*)adUnitId
{
    [FSAdInterstitialAdLoader sharedInstance].delegate = self;
    [[FSAdInterstitialAdLoader sharedInstance] initAd:adUnitId intervalTime:0 skipCount:0];
}

- (void)initAd:(NSString *)adUnitId intervalTime:(NSInteger)intervalTime skipCount:(NSInteger)skipCount
{
    [FSAdInterstitialAdLoader sharedInstance].delegate = self;
    [[FSAdInterstitialAdLoader sharedInstance] initAd:adUnitId intervalTime:intervalTime skipCount:skipCount];
}

- (void)loadAd:(NSString *)adUnitId
{
    [[FSAdInterstitialAdLoader sharedInstance] loadAd:adUnitId];
}

- (void)showAd:(NSString *)adUnitId
{
    [[FSAdInterstitialAdLoader sharedInstance] showAd:adUnitId];
}

- (void)hideAd
{
    [[FSAdInterstitialAdLoader sharedInstance] hideAd];
}

- (BOOL)isReadyAd:(NSString *)adUnitId
{
    return [[FSAdInterstitialAdLoader sharedInstance] isReadyAd:adUnitId];
}

#pragma mark - FSAdInterstitialAdLoaderDelegate

- (void)finishInitAdFSAdInterstitial:(FSAdInterstitialAdLoader *)sender
{
    UnitySendMessage("FSAdNetwork", "finishInitAdFSAdInterstitial", "" );
}

- (void)failedInitAdFSAdInterstitial:(FSAdInterstitialAdLoader *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedInitAdFSAdInterstitial", [error.errorMessage UTF8String] );
}

- (void)failedSendAdRequestFSAdInterstitial:(FSAdInterstitialAdLoader *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedSendAdRequestFSAdInterstitial", [error.errorMessage UTF8String] );
}

- (void)finishedResponseAdRequestFSAdInterstitial:(FSAdInterstitialAdLoader *)sender
{
    UnitySendMessage("FSAdNetwork", "finishedResponseAdRequestFSAdInterstitial", "" );
}

- (void)failedResponseAdRequestFSAdInterstitial:(FSAdInterstitialAdLoader *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedResponseAdRequestFSAdInterstitial", [error.errorMessage UTF8String] );
}

- (void)emptyAdResponseAdRequestFSAdInterstitial:(FSAdInterstitialAdLoader *)sender
{
    UnitySendMessage("FSAdNetwork", "emptyAdResponseAdRequestFSAdInterstitial", "" );
}

- (void)finishedAdCreateFSAdInterstitial:(FSAdInterstitialAdLoader *)sender
{
    UnitySendMessage("FSAdNetwork", "finishedAdCreateFSAdInterstitial", "" );
}

- (void)failedAdCreateFSAdInterstitial:(FSAdInterstitialAdLoader *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedAdCreateFSAdInterstitial", [error.errorMessage UTF8String] );
}

- (void)finishedAdClickFSAdInterstitial:(FSAdInterstitialAdLoader *)adView
{
    UnitySendMessage("FSAdNetwork", "finishedAdClickFSAdInterstitial", "" );
}

- (void)failedAdClickFSAdInterstitial:(FSAdInterstitialAdLoader *)adView error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedAdClickFSAdInterstitial", [error.errorMessage UTF8String] );
}

- (void)skipAdCreateFSAdInterstitial:(FSAdInterstitialAdLoader *)adLoader
{
    UnitySendMessage("FSAdNetwork", "skipAdCreateFSAdInterstitial", "" );
}

- (void)hideFSAdInterstitial:(FSAdInterstitialAdLoader *)adLoader
{
    UnitySendMessage("FSAdNetwork", "hideFSAdInterstitial", "" );
}

@end



#include <iostream>
using namespace std;

extern "C" {
    
    void initAdInterstitial(const char* adUnitId)
    {
        [[UAdInterstitialAdLoader sharedInstance] initAd:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void initSetAdInterstitial(const char* adUnitId, int intervalTime, int skipCount)
    {
        [[UAdInterstitialAdLoader sharedInstance] initAd:[NSString stringWithUTF8String:adUnitId] intervalTime:intervalTime skipCount:skipCount];
    }
    
    void loadAdInterstitial(const char* adUnitId)
    {
        [[UAdInterstitialAdLoader sharedInstance] loadAd:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void showAdInterstitial(const char* adUnitId)
    {
        [[UAdInterstitialAdLoader sharedInstance] showAd:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void hideAdInterstitial()
    {
        [[UAdInterstitialAdLoader sharedInstance] hideAd];
    }
    
    bool isReadyAdInterstitial(const char* adUnitId)
    {
        return [[UAdInterstitialAdLoader sharedInstance] isReadyAd:[NSString stringWithUTF8String:adUnitId]];
    }
}


