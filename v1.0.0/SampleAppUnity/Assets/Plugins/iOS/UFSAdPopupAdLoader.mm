//
//  UFSAdPopupAdLoader.m
//  SampleApp
//
//  Created by RN-079 on 2016/06/03.
//
//
#import <FSAdNetwork/FSAdPopupAdLoader.h>


#pragma mark - UFSAdPopupAdLoader

@interface UFSAdPopupAdLoader : NSObject <FSAdPopupAdLoaderDelegate>
{
}

@end

@implementation UFSAdPopupAdLoader

+ (instancetype)sharedInstance
{
    static id sharedInstance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        UFSAdPopupAdLoader *loader = [[self alloc] init];
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
    [FSAdPopupAdLoader sharedInstance].delegate = self;
    [[FSAdPopupAdLoader sharedInstance] initAd:adUnitId intervalTime:0 skipCount:0];
}

- (void)initAd:(NSString *)adUnitId intervalTime:(NSInteger)intervalTime skipCount:(NSInteger)skipCount
{
    [FSAdPopupAdLoader sharedInstance].delegate = self;
    [[FSAdPopupAdLoader sharedInstance] initAd:adUnitId intervalTime:intervalTime skipCount:skipCount];
}

- (void)loadAd:(NSString *)adUnitId
{
    [[FSAdPopupAdLoader sharedInstance] loadAd:adUnitId];
}

- (void)showAd:(NSString *)adUnitId
{
    [[FSAdPopupAdLoader sharedInstance] showAd:adUnitId];
}

- (void)hideAd
{
    [[FSAdPopupAdLoader sharedInstance] hideAd];
}

#pragma mark - FSAdPopupAdLoaderDelegate

- (void)finishInitAdFSAdPopup:(FSAdPopupAdLoader *)sender
{
    UnitySendMessage("FSAdNetwork", "finishInitAdFSAdPopup", "" );
}

- (void)failedInitAdFSAdPopup:(FSAdPopupAdLoader *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedInitAdFSAdPopup", [error.errorMessage UTF8String] );
}

- (void)failedSendAdRequestFSAdPopup:(FSAdPopupAdLoader *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedSendAdRequestFSAdPopup", [error.errorMessage UTF8String] );
}

- (void)finishedResponseAdRequestFSAdPopup:(FSAdPopupAdLoader *)sender
{
    UnitySendMessage("FSAdNetwork", "finishedResponseAdRequestFSAdPopup", "" );
}

- (void)failedResponseAdRequestFSAdPopup:(FSAdPopupAdLoader *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedResponseAdRequestFSAdPopup", [error.errorMessage UTF8String] );
}

- (void)emptyAdResponseAdRequestFSAdPopup:(FSAdPopupAdLoader *)sender
{
    UnitySendMessage("FSAdNetwork", "emptyAdResponseAdRequestFSAdPopup", "" );
}

- (void)finishedAdCreateFSAdPopup:(FSAdPopupAdLoader *)sender
{
    UnitySendMessage("FSAdNetwork", "finishedAdCreateFSAdPopup", "" );
}

- (void)failedAdCreateFSAdPopup:(FSAdPopupAdLoader *)sender error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedAdCreateFSAdPopup", [error.errorMessage UTF8String] );
}

- (void)finishedAdClickFSAdPopup:(FSAdPopupAdLoader *)adView
{
    UnitySendMessage("FSAdNetwork", "finishedAdClickFSAdPopup", "" );
}

- (void)failedAdClickFSAdPopup:(FSAdPopupAdLoader *)adView error:(FSError *)error
{
    UnitySendMessage("FSAdNetwork", "failedAdClickFSAdPopup", [error.errorMessage UTF8String] );
}

- (void)skipAdCreateFSAdPopup:(FSAdPopupAdLoader *)adLoader
{
    UnitySendMessage("FSAdNetwork", "skipAdCreateFSAdPopup", "" );
}

- (void)hideFSAdPopup:(FSAdPopupAdLoader *)adLoader
{
    UnitySendMessage("FSAdNetwork", "hideFSAdPopup", "" );
}

@end


#include <iostream>
using namespace std;

extern "C" {
    
    void initAdPopup(const char* adUnitId)
    {
        [[UFSAdPopupAdLoader sharedInstance] initAd:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void initSetAdPopup(const char* adUnitId, int intervalTime, int skipCount)
    {
        [[UFSAdPopupAdLoader sharedInstance] initAd:[NSString stringWithUTF8String:adUnitId] intervalTime:intervalTime skipCount:skipCount];
    }
    
    void loadAdPopup(const char* adUnitId)
    {
        [[UFSAdPopupAdLoader sharedInstance] loadAd:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void showAdPopup(const char* adUnitId)
    {
        [[UFSAdPopupAdLoader sharedInstance] showAd:[NSString stringWithUTF8String:adUnitId]];
    }
    
    void hideAdPopup()
    {
        [[UFSAdPopupAdLoader sharedInstance] hideAd];
    }
    
}

