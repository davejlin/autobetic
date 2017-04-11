//
//  GameTable.h
//  Baccarat
//
//  Created by Parveen Khatkar on 8/23/15.
//  Copyright (c) 2015 Codetrix Studio. All rights reserved.
//

#import <Foundation/Foundation.h>
#include "Card.h"
#include "Deck.h"
#include "Shoe.h"
#include "Hand.h"

@interface GameTable : NSObject

@property NSMutableArray<Hand> *hands;
@property NSMutableArray<Card> *currentPlayerCards;
@property NSMutableArray<Card> *currentBankerCards;
@property int turn;

-(void)dealHand;

@end
