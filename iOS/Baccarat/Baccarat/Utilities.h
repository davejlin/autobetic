//
//  Utilities.h
//  Baccarat
//
//  Created by Lin David, US-205 on 4/28/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Constants.h"
#import "SessionResults.h"
#import "SessionStatistics.h"
#import "Strategy.h"

@interface Utilities : NSObject
+ (void) printSessionCoupResults: (SessionResults*) sessionResults;
+ (void) printSession: (SessionResults*) sessionResults;
+ (void) printSessionStatistics: (SessionStatistics*) sessionStatistics;
+ (NSString*) getCoupResultString: (CoupResult) result;
+ (NSString*) getCoupValueString: (CardValue) value;
+ (BetPlacement) getBetPlacement;
+ (BetFrequency) getBetFrequency;
+ (BetProgression) getBetProgression;
+ (void) initCustomProgressionDoubleArray;
+ (double) getBaseBetFromCustomProgressionDoubleArray;
@end