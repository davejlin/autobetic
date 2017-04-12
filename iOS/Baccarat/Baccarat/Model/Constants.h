//
//  Constants.h
//  Baccarat
//
//  Created by Chicago Team on 12/30/14.
//  Copyright (c) 2014 AutoBetic. All rights reserved.
//

typedef enum {
    Hearts,
    Diamonds,
    Spades,
    Clubs
} CardSuite;

typedef enum {
    Zero = 0,
    Ace = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13
} CardValue;

typedef enum {
    Unknown = -1,
    Banker = 0,
    Player = 1,
    Tie = 2
} CoupResult;

typedef enum {
    BetLoss = 0,
    BetWin = 1,
    BetTie = 2
} BetOutcome;

extern NSString *const NOTIFICATION_SESSION_RESULTS;
