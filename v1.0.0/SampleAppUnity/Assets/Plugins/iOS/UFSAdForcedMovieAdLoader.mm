//
//  UFSAdForcedMovieAdLoader.m
//  SampleApp
//
//  Created by RN-079 on 2016/06/03.
//
//
#import <FSAdNetwork/FSAdForcedMovieAdLoader.h>

@interface UFSAdForcedMovieAdLoader : NSObject <FSAdForcedMovieAdLoaderDelegate>
{
}

@end

@implementation UFSAdForcedMovieAdLoader

+ (instancetype)sharedInstance
{
    static id sharedInstance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        UFSAdForcedMovieAdLoader *loader = [[self alloc] init];
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

- (void)initAdForcedMovie:(NSString*)adUnitId
{
    [FSAdForcedMovieAdLoader sharedInstance].delegate = self;
    [[FSAdForcedMovieAdLoader sharedInstance] initAd:adUnitId];
}

- (void)loadAdForcedMovie:(NSString*)adUnitId
{
    [[FSAdForcedMovieAdLoader sharedInstance] loadAd:adUnitId];
}

- (void)createAdForcedMovie:(NSString*)adUnitId
{
    [[FSAdForcedMovieAdLoader sharedInstance] createAd:adUnitId];
}

- (void)loadAndCreateAdCorcedMovie:(NSString*)adUnitId
{
    [[FSAdForcedMovieAdLoader sharedInstance] loadAndCreateAd:adUnitId];
}

- (void)showAdForcedMovie:(NSString*)adUnitId
{
    [[FSAdForcedMovieAdLoader sharedInstance] showAd:adUnitId];
}

- (void)hideAdForcedMovie:(NSString*)adUnitId
{
    [[FSAdForcedMovieAdLoader sharedInstance] hideAd:adUnitId];
}

- (BOOL)isReadyAdForcedMovie:(NSString*)adUnitId
{
    return [[FSAdForcedMovieAdLoader sharedInstance] isReadyAd:adUnitId];
}

- (BOOL)isDisplayAdForcedMovie:(NSString*)adUnitId
{
    return [[FSAdForcedMovieAdLoader sharedInstance] isDisplayAd:adUnitId];
}

#pragma mark - FSAdForcedMovieAdLoaderDelegate

- (void)finishInitAdFSAdForcedMovie:(FSAdForcedMovieAdLoader *)sender adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "finishInitAdFSAdForcedMovie", "" );
}

- (void)failedInitAdFSAdForcedMovie:(FSAdForcedMovieAdLoader *)sender adUnitId:(NSString *)adUnitId error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedInitAdFSAdForcedMovie", [error.errorMessage UTF8String] );
}

- (void)failedSendAdRequestFSAdForcedMovie:(FSAdForcedMovieAdLoader *)sender adUnitId:(NSString *)adUnitId error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedSendAdRequestFSAdForcedMovie", [error.errorMessage UTF8String] );
}

- (void)finishedResponseAdRequestFSAdForcedMovie:(FSAdForcedMovieAdLoader *)sender adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "finishedResponseAdRequestFSAdForcedMovie", "" );
}

- (void)failedResponseAdRequestFSAdForcedMovie:(FSAdForcedMovieAdLoader *)sender adUnitId:(NSString *)adUnitId error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedResponseAdRequestFSAdForcedMovie", [error.errorMessage UTF8String] );
}

- (void)emptyAdResponseAdRequestFSAdForcedMovie:(FSAdForcedMovieAdLoader *)sender adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "emptyAdResponseAdRequestFSAdForcedMovie", "" );
}

- (void)finishedReadyMovieFSAdForcedMovie:(FSAdForcedMovieAdLoader *)sender adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "finishedReadyMovieFSAdForcedMovie", "" );
}

- (void)failedReadyMovieFSAdForcedMovie:(FSAdForcedMovieAdLoader *)sender adUnitId:(NSString *)adUnitId error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedReadyMovieFSAdForcedMovie", [error.errorMessage UTF8String] );
}

- (void)finishedCreateFSAdForcedMovie:(FSAdForcedMovieAdLoader *)sender adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "finishedCreateFSAdForcedMovie", "" );
}

- (void)failedCreateFSAdForcedMovie:(FSAdForcedMovieAdLoader *)sender adUnitId:(NSString *)adUnitId error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedCreateFSAdForcedMovie", [error.errorMessage UTF8String] );
}

- (void)completedMovieFSAdForcedMovie:(FSAdForcedMovieAdLoader *)sender adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "completedMovieFSAdForcedMovie", "" );
}

- (void)finishedAdClickFSAdForcedMovie:(FSAdForcedMovieAdLoader *)adView adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "finishedAdClickFSAdForcedMovie", "" );
}

- (void)failedAdClickFSAdForcedMovie:(FSAdForcedMovieAdLoader *)adView adUnitId:(NSString *)adUnitId error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedAdClickFSAdForcedMovie", [error.errorMessage UTF8String] );
}

- (void)hideAdViewFSAdForcedMovie:(FSAdForcedMovieAdLoader *)adView adUnitId:(NSString *)adUnitId
{
    UnitySendMessage("FSAdNetwork", "hideAdViewFSAdForcedMovie", "" );
}

- (void)failedShowMovieFSAdForcedMovie:(FSAdForcedMovieAdLoader *)sender adUnitId:(NSString *)adUnitId error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedShowMovieFSAdForcedMovie", [error.errorMessage UTF8String] );
}

@end


#include <iostream>
using namespace std;

extern "C" {
    
    void initAdForcedMovie(const char* adUnitId)
    {
        [[UFSAdForcedMovieAdLoader sharedInstance] initAdForcedMovie:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void loadAdForcedMovie(const char* adUnitId)
    {
        [[UFSAdForcedMovieAdLoader sharedInstance] loadAdForcedMovie:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void createAdForcedMovie(const char* adUnitId)
    {
        [[UFSAdForcedMovieAdLoader sharedInstance] createAdForcedMovie:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void loadAndCreateAdForcedMovie(const char* adUnitId)
    {
        [[UFSAdForcedMovieAdLoader sharedInstance] loadAndCreateAdCorcedMovie:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void showAdForcedMovie(const char* adUnitId)
    {
        [[UFSAdForcedMovieAdLoader sharedInstance] showAdForcedMovie:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void hideAdForcedMovie(const char* adUnitId)
    {
        [[UFSAdForcedMovieAdLoader sharedInstance] hideAdForcedMovie:[NSString stringWithUTF8String:adUnitId]];
    }
    
    bool isReadyAdForcedMovie(const char* adUnitId)
    {
        return [[UFSAdForcedMovieAdLoader sharedInstance] isReadyAdForcedMovie:[NSString stringWithUTF8String:adUnitId]];
    }
    
    bool isDisplayAdForcedMovie(const char* adUnitId)
    {
        return [[UFSAdForcedMovieAdLoader sharedInstance] isDisplayAdForcedMovie:[NSString stringWithUTF8String:adUnitId]];
    }
    
}


