//
//  Card.h
//  Baccarat
//
//  Created by Parveen Khatkar on 8/2/15.
//  Copyright (c) 2015 Codetrix Studio. All rights reserved.
//

#import <SpriteKit/SpriteKit.h>

@protocol Card

@end

@interface Card : SKSpriteNode

@property int number;
@property char suit;

-(instancetype)initWithSuit:(char) suit Card:(int)cardNumber;
-(int)value;
-(void)flipAfter:(CGFloat)interval completion:(void (^)())completion;
-(void)makeSpaceForThridCard:(CGPoint)latestPos;
-(void)disposeTo:(CGPoint)pos delay:(CGFloat)delay completion:(void (^)())completion;

@end
