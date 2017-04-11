//
//  Shoe.h
//  Baccarat
//
//  Created by Parveen Khatkar on 8/2/15.
//  Copyright (c) 2015 Codetrix Studio. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Deck.h"
#import "Card.h"

@interface Shoe : NSObject

@property (nonatomic, strong) NSMutableArray* cards;
@property (nonatomic, strong) NSMutableArray* decks;
@property (nonatomic) int deckCount;

-(instancetype)initWithDecks:(int)count;
-(void)shuffle;
-(Card*)drawCard:(int)index;
@end
