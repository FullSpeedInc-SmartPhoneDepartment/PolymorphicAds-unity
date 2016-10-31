//
//  UFSAdForcedMovieAdLoader.m
//  SampleApp
//
//  Created by RN-079 on 2016/06/03.
//
//
#import <FSAdAnalytics/FSAdAnalytics.h>
#import <FSAdAnalytics/FSAnalyticsOption.h>


#pragma mark - 

@interface UAdAnalytics : NSObject <FSAdAnalyticsDelegate>

@end

@implementation UAdAnalytics

+ (instancetype)sharedInstance
{
    static id sharedInstance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        UAdAnalytics *loader = [[self alloc] init];
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

- (void)debugLogEnable:(BOOL)enable
{
    [FSAnalyticsOption debugLogEnable:enable];
}

- (void)conversion:(NSString*)conversionId
{
    [FSAdAnalytics sharedInstance].delegate = self;
    [[FSAdAnalytics sharedInstance] conversion:conversionId];
}

#pragma mark - FSAdAnalyticsDelegate

- (void)finishedConversionFSAdAnalytics
{
    UnitySendMessage("FSAdNetwork", "finishedConversionFSAdAnalytics", "" );
}

- (void)failedConversionFSAdAnalytics
{
    UnitySendMessage("FSAdNetwork", "failedConversionFSAdAnalytics", "" );
}

@end


#include <iostream>
using namespace std;

extern "C" {
    
    void analyticsDebugLogEnable(bool enable) {
        [[UAdAnalytics sharedInstance] debugLogEnable:enable];
    }
    
    void analyticsConversion(const char* conversionId) {
        [[UAdAnalytics sharedInstance] conversion:[NSString stringWithUTF8String:conversionId]];
    }
    
}


