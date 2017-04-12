//
//  Baccarat.h
//  Baccarat
//
//  Created by Chicago Team on 1/1/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Card.h"
#import "ShoeResults.h"
#import "Coup.h"

@interface Baccarat : NSObject

- (ShoeResults *)getShoeResults:(NSMutableArray *)shoe cutCardPosition:(int)nCut;

@end
