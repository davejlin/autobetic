//
//  SessionStatistics.h
//  Baccarat
//
//  Created by Lin David, US-205 on 4/28/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface SessionStatistics : NSObject

@property (nonatomic,assign) int nWinB;
@property (nonatomic,assign) int nWinP;
@property (nonatomic,assign) int nWinT;
@property (nonatomic,assign) int nWinTotal;

@property (nonatomic,assign) int nLossB;
@property (nonatomic,assign) int nLossP;
@property (nonatomic,assign) int nLossT;
@property (nonatomic,assign) int nLossTotal;

@property (nonatomic,assign) double nWinUnits;
@property (nonatomic,assign) double nLossUnits;

@property (nonatomic,assign) int nNetB;
@property (nonatomic,assign) int nNetP;
@property (nonatomic,assign) int nNetT;
@property (nonatomic,assign) int nNetTotal;
@property (nonatomic,assign) double nNetUnits;

@property (nonatomic,assign) int nBetTotal;
@property (nonatomic,assign) double nBetUnits;

@property (nonatomic,assign) double winPercentage;
@property (nonatomic,assign) double lossPercentage;
@property (nonatomic,assign) double playersAdvantage;

- (void) winBanker: (double) units;
- (void) winPlayer: (double) units;
- (void) winTie: (double) units;
- (void) lossBanker: (double) units;
- (void) lossPlayer: (double) units;
- (void) lossTie: (double) units;
- (void) calcTotals;

@end
