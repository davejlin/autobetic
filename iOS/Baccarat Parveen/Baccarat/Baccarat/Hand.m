//
//  Hand.m
//  Baccarat
//
//  Created by Parveen Khatkar on 8/23/15.
//  Copyright (c) 2015 Codetrix Studio. All rights reserved.
//

#import "Hand.h"

@implementation Hand

-(instancetype) init
{
    self.bankerCards = (NSMutableArray<Card> *)[NSMutableArray new];
    self.playerCards = (NSMutableArray<Card> *)[NSMutableArray new];
    return self;
}

@end
