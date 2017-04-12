//
//  Strategy.m
//  Baccarat
//
//  Created by Lin David, US-205 on 4/28/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "Strategy.h"

@implementation Strategy

+(NSArray*) executeStrategy:(BetPlacement) betPlacement
           withBetFrequency:(BetFrequency) betFrequency
         withBetProgression:(BetProgression) betProgression
                withBaseBet:(double) baseBet
               withBankroll:(double) sessionBankroll
                withResults:(SessionResults*) sessionResults
                  withStats:(SessionStatistics*) sessionStatistics {
    
    double bet = baseBet;
    double bankroll = sessionBankroll;
    NSMutableArray *shoeScores = [[NSMutableArray alloc] init];
    
    for (int i=0; i<sessionResults.session.count; i++) {
        NSArray *shoe = ((ShoeResults*)sessionResults.session[i]).shoe;
        for (int j=0; j<shoe.count; j++) {
            
            if (betFrequency(shoe, j) || [self isExceedsBankroll:bankroll withNextBet:bet]) { continue; }
            
            CoupResult result = ((Coup*)shoe[j]).coupResult;
            BetOutcome outcome = betPlacement(sessionStatistics, result, bet);
            bankroll = [self updateBankroll:outcome withBankroll:bankroll withBet:bet];
            bet = betProgression(bet, baseBet, outcome);
        }
        
        [shoeScores addObject:[NSNumber numberWithDouble:sessionStatistics.nWinUnits - sessionStatistics.nLossUnits]];
    }
    return [shoeScores copy];
}

+ (Boolean) isExceedsBankroll:(double) bankroll withNextBet:(double) nextBet {
    if (bankroll-nextBet < 0) {
        return true;
    } else {
        return false;
    }
}

+ (double) updateBankroll:(BetOutcome) outcome withBankroll:(double) bankroll withBet:(double) bet {
    switch (outcome) {
        case BetLoss:
            bankroll -= bet;
            break;
        case BetWin:
            bankroll += bet;
            break;
        case BetTie:
            break;
        default:
            break;
    }
    return bankroll;
}
                 
@end
