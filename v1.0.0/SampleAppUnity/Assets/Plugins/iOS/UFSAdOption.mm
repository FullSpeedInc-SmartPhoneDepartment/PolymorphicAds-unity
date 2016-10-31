//
//  UFSAdForcedMovieAdLoader.m
//  SampleApp
//
//  Created by RN-079 on 2016/06/03.
//
//
#import <FSAdNetwork/FSAdOption.h>


#include <iostream>
using namespace std;

extern "C" {
    
    void debugLogEnable(bool enable) {
        [FSAdOption debugLogEnable:enable];
    }
    
    void testModeEnable(bool enable) {
        [FSAdOption testModeEnable:enable];
    }
    
}


