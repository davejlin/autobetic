//
//  Shoe.m
//  Baccarat
//
//  Created by Parveen Khatkar on 8/2/15.
//  Copyright (c) 2015 Codetrix Studio. All rights reserved.
//

#import "Shoe.h"

@implementation Shoe

-(instancetype)initWithDecks:(int)count
{
    self.decks = [[NSMutableArray alloc] init];
    self.cards = [[NSMutableArray alloc] init];
    
    self.deckCount = count;
    [self newDecks];
    [self shuffle];
    return self;
}

-(void)shuffle
{
    for (int i = 0; i < self.cards.count - 1; i++)
    {
        NSInteger remainingCount = self.cards.count - i;
        NSInteger exchangeIndex = i + arc4random_uniform((u_int32_t )remainingCount);
        [self.cards exchangeObjectAtIndex:i withObjectAtIndex:exchangeIndex];
    }
}

-(void)newDecks
{
    for (int i = 0; i < self.deckCount; i++)
    {
        [self.decks addObject:[[Deck alloc] init]];
        [self.cards addObjectsFromArray:((Deck*)self.decks[i]).cards];
    }
}

-(Card*)drawCard:(int)index
{
    Card* card = self.cards[index];
    [self.cards removeObjectAtIndex:index];
    return card;
}

@end
