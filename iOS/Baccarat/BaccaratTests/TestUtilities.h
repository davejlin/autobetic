//
//  TestUtilities.h
//  Baccarat
//
//  Created by Lin David, US-205 on 4/29/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Baccarat.h"
#import "ShoeResults.h"
#import "SessionResults.h"
#import "Coup.h"
#import "Strategy.h"
#import "SessionStatistics.h"
#import "Utilities.h"

@interface TestUtilities : NSObject
+ (NSArray *)readTestShoeData;
+ (NSMutableArray *)getTestResultsData:(NSArray *)shoesData;
+ (SessionResults *)getTestSessionsData:(NSArray *)shoesData;
+ (Card *)createACardWithValue:(int)aValue;
@end
