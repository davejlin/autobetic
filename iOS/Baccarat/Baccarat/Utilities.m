//
//  Utilities.m
//  Baccarat
//
//  Created by Lin David, US-205 on 4/28/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "Utilities.h"

@implementation Utilities

static NSMutableArray* customProgressionDoubleArray;
static double betMinimum;
static double betMaximum;
// Bet Placement:

+(BetPlacement) getBetPlacement {
    int betPlacementSelection = (int)[[[NSUserDefaults standardUserDefaults] objectForKey:@"simBasicBetPlacement"] integerValue];
    
    switch (betPlacementSelection) {
        case Banker:
            return [self getBankerBetPlacement];
            break;
        case Player:
            return [self getPlayerBetPlacement];
            break;
        case Tie:
            return [self getTieBetPlacement];
            break;
        default:
            return [self getBankerBetPlacement];
            break;
    }
}

+(BetPlacement) getBankerBetPlacement {
    return (BetPlacement) ^(SessionStatistics* sessionStatistics, CoupResult result, double bet) {
        if (result == Banker) {
            [sessionStatistics winBanker:bet];
            return BetWin;
        } else if (result == Player) {
            [sessionStatistics lossBanker:bet];
            return BetLoss;
        }
        
        return BetTie;
    };
}

+(BetPlacement) getPlayerBetPlacement {
    return (BetPlacement) ^(SessionStatistics* sessionStatistics, CoupResult result, double bet) {
        if (result == Player) {
            [sessionStatistics winPlayer:bet];
            return BetWin;
        } else if (result == Banker) {
            [sessionStatistics lossPlayer:bet];
            return BetLoss;
        }
        
        return BetTie;
    };
}

+(BetPlacement) getTieBetPlacement {
    return (BetPlacement) ^(SessionStatistics* sessionStatistics, CoupResult result, double bet) {
        if (Tie == result) {
            [sessionStatistics winTie:bet];
            return BetWin;
        } else {
            [sessionStatistics lossTie:bet];
            return BetLoss;
        }
        
        return BetLoss;
    };
}

// Bet Frequency:

+(BetFrequency) getBetFrequency {
    int betPlacementSelection = (int)[[[NSUserDefaults standardUserDefaults] objectForKey:@"simBasicBetFrequency"] integerValue];
    
    switch (betPlacementSelection) {
        case 0:
            return [self getBetAlways];
            break;
        case 1:
            return [self getBetCustomTrigger];
            break;
        default:
            return [self getBetAlways];
            break;
    }
}

+(BetFrequency) getBetAlways {
    return (BetFrequency) ^(NSArray* shoe, int hand) {
        return false;
    };
}

+(BetFrequency) getBetCustomTrigger {
    NSString* customTriggerString = [[NSUserDefaults standardUserDefaults] stringForKey:@"simBasicCustomTrigger"];
    
    unsigned long len = [customTriggerString length];
    
    if (len == 0) {
        return (BetFrequency) ^(NSArray* shoe, int hand) {
            return true;
        };
    }
    
    NSArray* customTriggerArray = [self convertCustomTriggerStringToArray: customTriggerString];
    
    return (BetFrequency) ^(NSArray* shoe, int nHand) {
        
        if (nHand < len) {return true;}
        
        for (unsigned long i=len; i>0; i--) {
            if ([customTriggerArray[i-1] integerValue] != ((Coup*)shoe[i-1]).coupResult) {
                return true;
            }
        }
        return false;
    };
}

+(NSArray*) convertCustomTriggerStringToArray: (NSString*) customTriggerString {
    NSMutableArray *array = [[NSMutableArray alloc] init];
    customTriggerString = [customTriggerString lowercaseString];
    
    const char *buffer = [customTriggerString UTF8String];
    
    for (int i=0; i < customTriggerString.length; i++) {
        switch (buffer[i]) {
            case 'b':
                [array addObject: [NSNumber numberWithInt:Banker]];
                break;
            case 'p':
                [array addObject: [NSNumber numberWithInt:Player]];
                break;
            case 't':
                [array addObject: [NSNumber numberWithInt:Tie]];
                break;
            default:
                break;
        }
    }
    return array;
}

// Bet Progression:

+(BetProgression) getBetProgression {
    int betProgressionSelection = (int)[[[NSUserDefaults standardUserDefaults] objectForKey:@"simBasicBetProgression"] integerValue];
    
    [self loadBetSettingsParameters];
    
    switch (betProgressionSelection) {
        case 0:
            return [self getProgressionFlat];
            break;
        case 1:
            return [self getProgressionMartingale];
            break;
        default:
            return [self getProgressionCustom];
            break;
    }
}

+(BetProgression) getProgressionFlat {
    return (BetProgression) ^(double bet, double baseBet, BetOutcome betOutcome) {
        return [self checkBetLimits:bet];
    };
}

+(BetProgression) getProgressionMartingale {
    return (BetProgression) ^(double bet, double baseBet, BetOutcome betOutcome) {
        if (betOutcome == BetWin) {
            return [self checkBetLimits:baseBet];
        } else if (betOutcome == BetLoss) {
            return [self checkBetLimits:2.0*bet];
        } else if (betOutcome == BetTie) {
            return [self checkBetLimits:bet];
        }
        
        return bet;
    };
}

+(BetProgression) getProgressionCustom {
    return (BetProgression) ^(double bet, double baseBet, BetOutcome betOutcome) {
        if (betOutcome == BetWin) {
            return [self checkBetLimits:[customProgressionDoubleArray[0] doubleValue]];
        } else if (betOutcome == BetLoss) {
            
            unsigned long index = [customProgressionDoubleArray indexOfObject:[NSNumber numberWithDouble:bet]];
            if (index != NSNotFound && index < customProgressionDoubleArray.count - 1) {
                return [self checkBetLimits:[customProgressionDoubleArray[index+1] doubleValue]];
            } else if (index == customProgressionDoubleArray.count - 1) {
                return [self checkBetLimits:bet];
            }

        } else if (betOutcome == BetTie) {
            return [self checkBetLimits:bet];
        }
        
        return [self checkBetLimits:bet];
    };
}

+ (void) initCustomProgressionDoubleArray {
    NSString* customProgressionString = [[NSUserDefaults standardUserDefaults] stringForKey:@"simBasicCustomProgression"];
    NSArray *customProgressionStringArray = [customProgressionString componentsSeparatedByString:@"."];
    customProgressionDoubleArray = [NSMutableArray array];
    
    for (int i=0; i<customProgressionStringArray.count; i++) {
        [customProgressionDoubleArray addObject:[NSNumber numberWithDouble:[customProgressionStringArray[i] doubleValue]]];
    }
}

+ (double) getBaseBetFromCustomProgressionDoubleArray {
    if (customProgressionDoubleArray != nil) {
        return [customProgressionDoubleArray[0] doubleValue];
    } else {
        return 0;
    }
}

// Money Management:

+ (void) loadBetSettingsParameters {
    double betBase = (double)[[[NSUserDefaults standardUserDefaults] objectForKey:@"simBasicBaseBet"] doubleValue];
    double betMax = (double)[[[NSUserDefaults standardUserDefaults] objectForKey:@"simBasicMaxBet"] doubleValue];
    double tableLimitMin = (double)[[[NSUserDefaults standardUserDefaults] objectForKey:@"simBasicTableLimitsMin"] doubleValue];
    double tableLimitMax = (double)[[[NSUserDefaults standardUserDefaults] objectForKey:@"simBasicTableLimitsMax"] doubleValue];
    
    betMinimum = MAX(betBase,tableLimitMin);
    betMaximum = MIN(betMax,tableLimitMax);
}

+ (double) checkBetLimits: (double) bet {
    return MAX(MIN(bet,betMaximum),betMinimum);
}

// Print Utilities:

+(void) printSessionCoupResults: (SessionResults*) sessionResults {
    for (int i=0; i<sessionResults.session.count; i++) {
        NSLog(@"Shoe # %d\n",i);
        ShoeResults *shoeResults = sessionResults.session[i];
        for (int j=0; j<shoeResults.shoe.count; j++) {
            Coup *coup = shoeResults.shoe[j];
            NSLog (@"%@", [Utilities getCoupResultString:coup.coupResult]);
        }
    }
}

+(void) printSession: (SessionResults*) sessionResults {
    for (int i=0; i<sessionResults.session.count; i++) {
        NSLog(@"Shoe # %d\n",i);
        ShoeResults *shoeResults = sessionResults.session[i];
        for (int j=0; j<shoeResults.shoe.count; j++) {
            Coup *coup = shoeResults.shoe[j];
            NSLog (@"%@ %@ %@ %@ %@ %@ %@",
                   [Utilities getCoupResultString:coup.coupResult],
                   [Utilities getCoupValueString:coup.p1.value],
                   [Utilities getCoupValueString:coup.p2.value],
                   [Utilities getCoupValueString:coup.p3.value],
                   [Utilities getCoupValueString:coup.b1.value],
                   [Utilities getCoupValueString:coup.b2.value],
                   [Utilities getCoupValueString:coup.b3.value]);
        }
    }
}

+(void) printSessionStatistics: (SessionStatistics*) sessionStatistics {
    NSLog (@"Win Statistics:");
    NSLog (@"B:%d P:%d T:%d Net:%d Units:%.2f", sessionStatistics.nWinB
                                              , sessionStatistics.nWinP
                                              , sessionStatistics.nWinT
                                              , sessionStatistics.nWinTotal
                                              , sessionStatistics.nWinUnits);
    
    NSLog (@"Loss Statistics:");
    NSLog (@"B:%d P:%d T:%d Net:%d Units:%.2f", sessionStatistics.nLossB
                                              , sessionStatistics.nLossP
                                              , sessionStatistics.nLossT
                                              , sessionStatistics.nLossTotal
                                              , sessionStatistics.nLossUnits);
    
    NSLog (@"Net Statistics:");
    NSLog (@"B:%d P:%d T:%d Net:%d Units:%.2f", sessionStatistics.nNetB
                                              , sessionStatistics.nNetP
                                              , sessionStatistics.nNetT
                                              , sessionStatistics.nNetTotal
                                              , sessionStatistics.nNetUnits);
    
    NSLog (@"Player's Advantage: %.2f %%", sessionStatistics.playersAdvantage);
}

// Conversion Utilities:

+ (NSString*) getCoupResultString: (CoupResult) result {
    switch (result) {
        case Banker:
            return @"B";
            break;
        case Player:
            return @"P";
            break;
        case Tie:
            return @"T";
            break;
        default:
            break;
    }
    return @"X";
}

+ (NSString*) getCoupValueString: (CardValue) value {
    switch (value) {
        case Zero:
            return @"-";
            break;
        case Ace:
            return @"A";
            break;
        case Two:
            return @"2";
            break;
        case Three:
            return @"3";
            break;
        case Four:
            return @"4";
            break;
        case Five:
            return @"5";
            break;
        case Six:
            return @"6";
            break;
        case Seven:
            return @"7";
            break;
        case Eight:
            return @"8";
            break;
        case Nine:
            return @"9";
            break;
        case Ten:
            return @"10";
            break;
        case Jack:
            return @"J";
            break;
        case Queen:
            return @"Q";
            break;
        case King:
            return @"K";
            break;
        default:
            break;
    }
    return @"X";
}
@end
