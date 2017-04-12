//
//  Game.m
//  Baccarat
//
//  Created by Lin David, US-205 on 4/26/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "Session.h"

@implementation Session

int decksPerShoe = 0;
int shoesPerSession = 0;
SessionResults *sessionResults;
SessionStatistics *sessionStatistics;
NSArray *shoeScores;

-(id)init {
    self = [super init];
    if (self != nil) {
        _standardUserDefaults = [NSUserDefaults standardUserDefaults];
    }
    return self;
}

-(void) startSession {
    [self loadSettings];
    [self runSession];
}

-(void) runSession {
    int nCutCardPosition = 16;
    
    sessionResults = [[SessionResults alloc] init];
    sessionStatistics = [[SessionStatistics alloc] init];
    Dealer *dealer = [[Dealer alloc] init];
    Baccarat *baccarat = [[Baccarat alloc] init];
    
    for (int i=0; i < shoesPerSession; i++) {
        NSMutableArray *shoe = [dealer createShoeOfCards:decksPerShoe];
        shoe = [dealer shuffleShoeOfCards:shoe];
        shoe = [dealer burnShoeOfCards:shoe];
        
        ShoeResults *shoeResults = [baccarat getShoeResults:shoe cutCardPosition:nCutCardPosition];
        
        [sessionResults addAShoeToSession:shoeResults];
    }
    
    //[Utilities printSession:sessionResults];
    //[Utilities printSessionCoupResults:sessionResults];
    
    shoeScores = [Strategy executeStrategy:[Utilities getBetPlacement]
                          withBetFrequency:[Utilities getBetFrequency]
                        withBetProgression:[Utilities getBetProgression]
                               withBaseBet: _baseBet
                              withBankroll: _bankroll
                               withResults:sessionResults
                                 withStats:sessionStatistics];
    [sessionStatistics calcTotals];
    [Utilities printSessionStatistics:sessionStatistics];
}

-(void) loadSettings {
    [self loadSimulatorSettingsParameters];
    
    decksPerShoe = (int)_nDecksPerShoe.integerValue;
    if (decksPerShoe==0) decksPerShoe=1;
    
    shoesPerSession = (int)_nShoesPerSession.integerValue;
    if (shoesPerSession == 0) shoesPerSession = 1;
}

-(void) loadSimulatorSettingsParameters {
    _nShoesPerSession = [self.standardUserDefaults objectForKey:@"nShoesPerSession"];
    _nDecksPerShoe = [self.standardUserDefaults objectForKey:@"nDecksPerShoe"];
    
    int betProgressionSelection = (int)[[[NSUserDefaults standardUserDefaults] objectForKey:@"simBasicBetProgression"] integerValue];
    if (betProgressionSelection == 2) {
        [Utilities initCustomProgressionDoubleArray];
        _baseBet = [Utilities getBaseBetFromCustomProgressionDoubleArray];
    } else {
        _baseBet = (double)[[self.standardUserDefaults objectForKey:@"simBasicBaseBet"] doubleValue];
    }
    
    _bankroll = (double)[[[NSUserDefaults standardUserDefaults] objectForKey:@"simBasicBankroll"] doubleValue];
}

- (SessionStatistics*) getSessionStatistics {
    return sessionStatistics;
}
- (NSArray*) getShoeScores {
    return shoeScores;
}

@end
