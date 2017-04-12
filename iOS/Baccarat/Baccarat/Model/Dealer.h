//
//  Dealer.h
//  Baccarat
//
//  Created by Chicago Team on 12/30/14.
//  Copyright (c) 2014 AutoBetic. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Card.h"

@interface Dealer : NSObject

- (NSMutableArray *)createShoeOfCards:(int)nDecks;
- (NSMutableArray *)shuffleShoeOfCards:(NSMutableArray *)shoe;
- (NSMutableArray *)burnShoeOfCards:(NSMutableArray *)shoe;

@end
