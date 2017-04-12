//
//  Coup.h
//  Baccarat
//
//  Created by Chicago Team on 2/14/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Card.h"
#import "Constants.h"

@interface Coup : NSObject
@property (nonatomic, weak) Card *p1;
@property (nonatomic, weak) Card *p2;
@property (nonatomic, weak) Card *p3;
@property (nonatomic, weak) Card *b1;
@property (nonatomic, weak) Card *b2;
@property (nonatomic, weak) Card *b3;
@property (nonatomic, assign) CoupResult coupResult;
@end
