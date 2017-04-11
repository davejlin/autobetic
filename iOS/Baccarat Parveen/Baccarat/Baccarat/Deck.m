//
//  Deck.m
//  Baccarat
//
//  Created by Parveen Khatkar on 8/2/15.
//  Copyright (c) 2015 Codetrix Studio. All rights reserved.
//

#import "Deck.h"
#import "Card.h"

@implementation Deck

-(instancetype)init
{
    self.cards = [[NSMutableArray alloc] init];
    const char *suits = [@"scdh" UTF8String];
    
    for (int j = 0; j <4; j++)
    {
        for (int i = 1; i <= 13; i++)
        {
            [self.cards addObject:[[Card alloc] initWithSuit:suits[j] Card:i]];
        }
    }
    return self;
}

@end
