//
//  SessionStatistics.m
//  Baccarat
//
//  Created by Lin David, US-205 on 4/28/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "SessionStatistics.h"

@implementation SessionStatistics

double bankerCommissions = 0.95;
double tieMultiplier = 8.0;

-(id)init {
    self = [super init];
    if (self != nil) {
    }
    return self;
}

- (void) winBanker: (double) units {
    _nWinB++;
    _nWinTotal++;
    _nWinUnits += bankerCommissions * units;
    _nBetTotal++;
    _nBetUnits += units;
}
- (void) winPlayer: (double) units {
    _nWinP++;
    _nWinTotal++;
    _nWinUnits += units;
    _nBetTotal++;
    _nBetUnits += units;
}
- (void) winTie: (double) units {
    _nWinT++;
    _nWinTotal++;
    _nWinUnits += tieMultiplier * units;
    _nBetTotal++;
    _nBetUnits += units;
}

- (void) lossBanker: (double) units {
    _nLossB++;
    _nLossTotal++;
    _nLossUnits += units;
    _nBetTotal++;
    _nBetUnits += units;
}
- (void) lossPlayer: (double) units {
    _nLossP++;
    _nLossTotal++;
    _nLossUnits += units;
    _nBetTotal++;
    _nBetUnits += units;
}
- (void) lossTie: (double) units {
    _nLossT++;
    _nLossTotal++;
    _nLossUnits += units;
    _nBetTotal++;
    _nBetUnits += units;
}

- (void) calcTotals {
    _nNetB = _nWinB - _nLossB;
    _nNetP = _nWinP - _nLossP;
    _nNetT = _nWinT - _nLossT;
    _nNetTotal = _nWinTotal - _nLossTotal;
    _nNetUnits = _nWinUnits - _nLossUnits;
    _winPercentage = _nBetTotal == 0 ? 0.0 : 100.0 * (double)_nWinTotal / _nBetTotal;
    _lossPercentage = _nBetTotal == 0 ? 100.0 : 100.0 * (double)_nLossTotal / _nBetTotal;
    _playersAdvantage = _nBetUnits == 0 ? 0 : 100.0 * _nNetUnits / _nBetUnits;
}

@end
