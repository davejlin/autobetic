//
//  Game.h
//  Baccarat
//
//  Created by Lin David, US-205 on 4/26/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import "Dealer.h"
#import "Baccarat.h"
#import "SessionResults.h"
#import "SessionStatistics.h"
#import "Strategy.h"
#import "Utilities.h"
#import "Constants.h"

@interface Session : NSObject
-(void) startSession;
-(SessionStatistics*) getSessionStatistics;
-(NSArray*) getShoeScores;
@property (strong, nonatomic) NSUserDefaults *standardUserDefaults;
@property (weak, nonatomic) NSString *nShoesPerSession;
@property (weak, nonatomic) NSString *nDecksPerShoe;
@property (assign, nonatomic) double baseBet;
@property (assign, nonatomic) double bankroll;
@property (weak, nonatomic) NSString *simBasicBetPlacement;
@property (weak, nonatomic) NSString *simBasicBetFrequency;
@end
