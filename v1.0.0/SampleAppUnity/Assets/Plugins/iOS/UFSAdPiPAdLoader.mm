//
//  UFSAdPiPAdLoader.m
//  SampleApp
//
//  Created by RN-079 on 2016/06/03.
//
//
#import <FSAdNetwork/FSAdPiPAdLoader.h>

@interface UFSAdPiPAdLoader : NSObject <FSAdPiPAdLoaderDelegate>
{
}

@end

@implementation UFSAdPiPAdLoader

+ (instancetype)sharedInstance
{
    static id sharedInstance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        UFSAdPiPAdLoader *loader = [[self alloc] init];
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

- (void)initAdPiP:(NSString*)adUnitId
{
    [FSAdPiPAdLoader sharedInstance].delegate = self;
    [[FSAdPiPAdLoader sharedInstance] initAd:adUnitId];
}

- (void)loadAndCreateAdPiP:(NSString*)adUnitId
{
    [[FSAdPiPAdLoader sharedInstance] loadAndCreateAd:adUnitId];
}

- (void)loadAdPiP:(NSString*)adUnitId
{
    [[FSAdPiPAdLoader sharedInstance] loadAd:adUnitId];
}

- (void)createAdPiP:(NSString*)adUnitId
{
    [[FSAdPiPAdLoader sharedInstance] createAd:adUnitId];
}

- (void)showAdPiP:(NSString*)adUnitId
{
    [[FSAdPiPAdLoader sharedInstance] showAd:adUnitId];
}

- (void)showAdPip:(NSString*)adUnitId position:(int)position
{
    [[FSAdPiPAdLoader sharedInstance] showAd:adUnitId position:(FSAdPiPPositionType)position];
}

- (void)hideAdPiP:(NSString*)adUnitId
{
    [[FSAdPiPAdLoader sharedInstance] hideAd:adUnitId];
}

- (BOOL)isReadyAdPiP:(NSString*)adUnitId
{
    return [[FSAdPiPAdLoader sharedInstance] isReadyAd:adUnitId];
}

- (BOOL)isDisplayAdPiP:(NSString*)adUnitId
{
    return [[FSAdPiPAdLoader sharedInstance] isDisplayAd:adUnitId];
}

#pragma mark - FSAdPiPAdLoaderDelegate

- (void)finishInitAdFSAdPiP:(FSAdPiPAdLoader *)sender adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "finishInitAdFSAdPiP", "" );
}

- (void)failedInitAdFSAdPiP:(FSAdPiPAdLoader *)sender adUnitId:(NSString *)adUnitId error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedInitAdFSAdPiP", [error.errorMessage UTF8String] );
}

- (void)failedSendAdRequestFSAdPiP:(FSAdPiPAdLoader *)sender adUnitId:(NSString *)adUnitId error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedSendAdRequestFSAdPiP", [error.errorMessage UTF8String] );
}

- (void)finishedResponseAdRequestFSAdPiP:(FSAdPiPAdLoader *)sender adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "finishedResponseAdRequestFSAdPiP", "" );
}

- (void)failedResponseAdRequestFSAdPiP:(FSAdPiPAdLoader *)sender adUnitId:(NSString *)adUnitId error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedResponseAdRequestFSAdPiP", [error.errorMessage UTF8String] );
}

- (void)emptyAdResponseAdRequestFSAdPiP:(FSAdPiPAdLoader *)sender adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "emptyAdResponseAdRequestFSAdPiP", "" );
}

- (void)finishedReadyMovieFSAdPiP:(FSAdPiPAdLoader *)sender adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "finishedReadyMovieFSAdPiP", "" );
}

- (void)failedReadyMovieFSAdPiP:(FSAdPiPAdLoader *)sender adUnitId:(NSString *)adUnitId error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedReadyMovieFSAdPiP", [error.errorMessage UTF8String] );
}

- (void)finishedCreateFSAdPiP:(FSAdPiPAdLoader *)sender adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "finishedCreateFSAdPiP", "" );
}

- (void)failedCreateFSAdPiP:(FSAdPiPAdLoader *)sender adUnitId:(NSString *)adUnitId error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedCreateFSAdPiP", [error.errorMessage UTF8String] );
}

- (void)completedMovieFSAdPiP:(FSAdPiPAdLoader *)sender adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "completedMovieFSAdPiP", "" );
}

- (void)finishedAdClickFSAdPiP:(FSAdPiPAdLoader *)adView adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "finishedAdClickFSAdPiP", "" );
}

- (void)failedAdClickFSAdPiP:(FSAdPiPAdLoader *)adView adUnitId:(NSString *)adUnitId error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedAdClickFSAdPiP", [error.errorMessage UTF8String] );
}

- (void)hideAdViewFSAdPiP:(FSAdPiPAdLoader *)adView adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "hideAdViewFSAdPiP", "" );
}

- (void)expandedAdViewFSAdPiP:(FSAdPiPAdLoader *)adView adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "expandedAdViewFSAdPiP", "" );
}

@end


#include <iostream>
using namespace std;

extern "C" {
    
    void initAdPiP(const char* adUnitId)
    {
        [[UFSAdPiPAdLoader sharedInstance] initAdPiP:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void loadAdPiP(const char* adUnitId)
    {
        [[UFSAdPiPAdLoader sharedInstance] loadAdPiP:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void createAdPiP(const char* adUnitId)
    {
        [[UFSAdPiPAdLoader sharedInstance] createAdPiP:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void loadAndCreateAdPiP(const char* adUnitId)
    {
        [[UFSAdPiPAdLoader sharedInstance] loadAndCreateAdPiP:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void showAdPiP(const char* adUnitId)
    {
        [[UFSAdPiPAdLoader sharedInstance] showAdPiP:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void showPosAdPiP(const char* adUnitId, int positionType)
    {
        [[UFSAdPiPAdLoader sharedInstance] showAdPip:[NSString stringWithUTF8String:adUnitId] position:positionType];
    }
    
    void hideAdPiP(const char* adUnitId)
    {
        [[UFSAdPiPAdLoader sharedInstance] hideAdPiP:[NSString stringWithUTF8String:adUnitId]];
    }
    
    bool isReadyAdPiP(const char* adUnitId)
    {
        return [[UFSAdPiPAdLoader sharedInstance] isReadyAdPiP:[NSString stringWithUTF8String:adUnitId]];
    }
    
    bool isDisplayAdPiP(const char* adUnitId)
    {
        return [[UFSAdPiPAdLoader sharedInstance] isDisplayAdPiP:[NSString stringWithUTF8String:adUnitId]];
    }
    
}


