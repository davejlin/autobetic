//
//  Strategy.h
//  Baccarat
//
//  Created by Lin David, US-205 on 4/28/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SessionResults.h"
#import "SessionStatistics.h"
#import "Constants.h"

@interface Strategy : NSObject

typedef BetOutcome (^BetPlacement)(SessionStatistics* sessionStatistics, CoupResult coupResult, double bet);
typedef BOOL (^BetFrequency)(NSArray* shoe, int nHand);
typedef double (^BetProgression)(double bet, double baseBet, BetOutcome betOutcome);

+(NSArray*) executeStrategy:(BetPlacement) betPlacement
           withBetFrequency:(BetFrequency) betFrequency
         withBetProgression:(BetProgression) betProgression
                withBaseBet:(double) baseBet
               withBankroll:(double) bankroll
                withResults:(SessionResults*) sessionResults
                  withStats: (SessionStatistics*) sessionStatistics;
@end
