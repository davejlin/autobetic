//
//  Dealer.m
//  Baccarat
//
//  Created by Chicago Team on 12/30/14.
//  Copyright (c) 2014 AutoBetic. All rights reserved.
//

#import "Dealer.h"

@implementation Dealer

-(id)init {
    self = [super init];
    if (self != nil) {
    }
    return self;
}

- (NSMutableArray *) createShoeOfCards: (int) nDecks {
    
    int totalNCards = nDecks * 52;
    NSMutableArray *myDeck = [NSMutableArray arrayWithCapacity:totalNCards];
    
    for(int d=0; d<nDecks; d++) {
        for(int s=0; s<4; s++) {
            for(int v=1; v<14; v++) {
                
                Card *aCard = [[Card alloc] initWithName:v withSuite:s];

                [myDeck addObject:aCard];
            }
        }
    }
    
    return myDeck;
}

- (NSMutableArray *)shuffleShoeOfCards:(NSMutableArray *)shoe {
    int nCards = (int)[shoe count];
    for (int i = 0; i < nCards; i++) {
        int r = arc4random_uniform(nCards);
        NSNumber *temp = shoe[i];
        shoe[i] = shoe[r];
        shoe[r] = temp;
    }
    
    return shoe;
}

- (NSMutableArray *)burnShoeOfCards:(NSMutableArray *)shoe {
    int firstCardValue = ((Card *)shoe[0]).value;
    [shoe removeObjectAtIndex:0];
    
    firstCardValue = (firstCardValue < 11) ? firstCardValue : 10;
    
    NSRange r;
    r.location = 0;
    r.length = firstCardValue;
    
    [shoe removeObjectsInRange:r];
    
    return shoe;
}

@end
