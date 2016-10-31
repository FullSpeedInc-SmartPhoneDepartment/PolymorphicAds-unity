//
//  UFSAdSlideInAdLoader.m
//  SampleApp
//
//  Created by RN-079 on 2016/06/03.
//
//
#import <FSAdNetwork/FSAdSlideInAdLoader.h>

@interface UFSAdSlideInAdLoader : NSObject <FSAdSlideInAdLoaderDelegate>
{
}

@end

@implementation UFSAdSlideInAdLoader

+ (instancetype)sharedInstance
{
    static id sharedInstance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        UFSAdSlideInAdLoader *loader = [[self alloc] init];
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
    [FSAdSlideInAdLoader sharedInstance].delegate = self;
    [[FSAdSlideInAdLoader sharedInstance] initAd:adUnitId intervalTime:0 skipCount:0 displayTime:6];
}

- (void)initAd:(NSString *)adUnitId intervalTime:(NSInteger)intervalTime skipCount:(NSInteger)skipCount displayTime:(NSInteger)displayTime
{
    [FSAdSlideInAdLoader sharedInstance].delegate = self;
    [[FSAdSlideInAdLoader sharedInstance] initAd:adUnitId intervalTime:intervalTime skipCount:skipCount displayTime:displayTime];
}

- (void)loadAd:(NSString *)adUnitId
{
    [[FSAdSlideInAdLoader sharedInstance] loadAd:adUnitId];
}

- (void)showAd:(NSString *)adUnitId
{
    [[FSAdSlideInAdLoader sharedInstance] showAd:adUnitId];
}

- (void)hideAd
{
    [[FSAdSlideInAdLoader sharedInstance] hideAd];
}

#pragma mark - FSAdSlideInAdLoaderDelegate

- (void)finishInitAdFSAdSlideIn:(FSAdSlideInAdLoader *)sender
{
    UnitySendMessage("FSAdNetwork", "finishInitAdFSAdSlideIn", "" );
}

- (void)failedInitAdFSAdSlideIn:(FSAdSlideInAdLoader *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedInitAdFSAdSlideIn", [error.errorMessage UTF8String] );
}

- (void)failedSendAdRequestFSAdSlideIn:(FSAdSlideInAdLoader *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedSendAdRequestFSAdSlideIn", [error.errorMessage UTF8String] );
}

- (void)finishedResponseAdRequestFSAdSlideIn:(FSAdSlideInAdLoader *)sender
{
    UnitySendMessage("FSAdNetwork", "finishedResponseAdRequestFSAdSlideIn", "" );
}

- (void)failedResponseAdRequestFSAdSlideIn:(FSAdSlideInAdLoader *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedResponseAdRequestFSAdSlideIn", [error.errorMessage UTF8String] );
}

- (void)emptyAdResponseAdRequestFSAdSlideIn:(FSAdSlideInAdLoader *)sender
{
    UnitySendMessage("FSAdNetwork", "emptyAdResponseAdRequestFSAdSlideIn", "" );
}

- (void)finishedAdCreateFSAdSlideIn:(FSAdSlideInAdLoader *)sender
{
    UnitySendMessage("FSAdNetwork", "finishedAdCreateFSAdSlideIn", "" );
}

- (void)failedAdCreateFSAdSlideIn:(FSAdSlideInAdLoader *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedAdCreateFSAdSlideIn", [error.errorMessage UTF8String] );
}

- (void)finishedAdClickFSAdSlideIn:(FSAdSlideInAdLoader *)adView
{
    UnitySendMessage("FSAdNetwork", "finishedAdClickFSAdSlideIn", "" );
}

- (void)failedAdClickFSAdSlideIn:(FSAdSlideInAdLoader *)adView error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedAdClickFSAdSlideIn", [error.errorMessage UTF8String] );
}

- (void)skipAdCreateFSAdSlideIn:(FSAdSlideInAdLoader *)adLoader
{
    UnitySendMessage("FSAdNetwork", "skipAdCreateFSAdSlideIn", "" );
}

- (void)hideFSAdSlideIn:(FSAdSlideInAdLoader *)adLoader
{
    UnitySendMessage("FSAdNetwork", "hideFSAdSlideIn", "" );
}

@end


#include <iostream>
using namespace std;

extern "C" {
    
    void initAdSlidein(const char* adUnitId)
    {
        [[UFSAdSlideInAdLoader sharedInstance] initAd:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void initSetAdSlidein(const char* adUnitId, int intervalTime, int skipCount, int displayTime)
    {
        [[UFSAdSlideInAdLoader sharedInstance] initAd:[NSString stringWithUTF8String:adUnitId] intervalTime:intervalTime skipCount:skipCount displayTime:displayTime];
    }
    
    void loadAdSlidein(const char* adUnitId)
    {
        [[UFSAdSlideInAdLoader sharedInstance] loadAd:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void showAdSlidein(const char* adUnitId)
    {
        [[UFSAdSlideInAdLoader sharedInstance] showAd:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void hideAdSlidein()
    {
        [[UFSAdSlideInAdLoader sharedInstance] hideAd];
    }
}

