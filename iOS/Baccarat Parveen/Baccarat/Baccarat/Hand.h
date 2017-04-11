//
//  Hand.h
//  Baccarat
//
//  Created by Parveen Khatkar on 8/23/15.
//  Copyright (c) 2015 Codetrix Studio. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Card.h"

@protocol Hand

@end

@interface Hand : NSObject

@property int winner;
@property NSMutableArray<Card> *playerCards;
@property NSMutableArray<Card> *bankerCards;
@property int betAmount;
@property int bettedOn;
@property int returnAmount;

@end
