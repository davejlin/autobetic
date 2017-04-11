//
//  Card.m
//  Baccarat
//
//  Created by Parveen Khatkar on 8/2/15.
//  Copyright (c) 2015 Codetrix Studio. All rights reserved.
//

#import "Card.h"

@implementation Card


-(instancetype)initWithSuit:(char) suit Card:(int)cardNumber
{
//    self = (Card *)[SKSpriteNode spriteNodeWithImageNamed:[NSString stringWithFormat:@"%d%c", cardNumber, suit]];
    self = [super init];
    self.texture = [SKTexture textureWithImageNamed:@"b1fv"];
    CGFloat scale = 0.8;
    self.size = CGSizeMake(76 * scale, 96 * scale);
    self.xScale = -1;
    
    self.number = cardNumber;
    self.suit = suit;
    return self;
}

-(void)flipAfter:(CGFloat)interval completion:(void (^)())completion
{
//    SKAction* action0 = [SKAction waitForDuration:interval];

//    SKAction* action1 = [SKAction scaleXTo:-1.1 y:1.05 duration:0.1];
//    SKAction* action2 = [SKAction scaleXTo:-0.1 duration:0.2];
//    SKAction* actionPre = [SKAction sequence:@[action0, action1, action2]];
    
//    [self runAction:actionPre completion:^{
//        SKAction* action5 = [SKAction scaleXTo:0.1 duration:0.01];
//        SKAction* action6 = [SKAction scaleXTo:1.1 duration:0.3];
//        SKAction* action7 = [SKAction scaleXTo:1 y:1 duration:0.1];
    
//        SKAction* action = [SKAction sequence:@[action5, action6, action7]];
//        [self runAction:action completion:^{
            if (completion)
            {
                completion();
            }
//        }];
    
//        self.texture = [SKTexture textureWithImageNamed:[NSString stringWithFormat:@"%d%c", self.number, self.suit]];
//    }];
}

-(void)makeSpaceForThridCard:(CGPoint)latestPos
{
    latestPos.x -= self.size.width / 2;
    
    SKAction* action0 = [SKAction waitForDuration:0.6];
    SKAction* action1 = [SKAction moveTo:latestPos duration:0.2];
    
    SKAction* action = [SKAction sequence:@[action0, action1]];
    [self runAction:action];
}

-(void)disposeTo:(CGPoint)pos delay:(CGFloat)delay completion:(void (^)())completion
{
//    SKAction* action0 = [SKAction waitForDuration:delay];
//    SKAction* action1 = [SKAction moveTo:pos duration:0.3 * (0.8 - delay) / 0.72];
    
    //just to add delay before next dealing
//    SKAction* action2 = [SKAction waitForDuration:1];
    
//    SKAction* action = [SKAction sequence:@[action0, action1, action2]];
//    [self runAction:action completion:^{
        if (completion)
        {
            completion();
        }
//    }];
}

-(int)value
{
    if (self.number < 11)
    {
        return self.number;
    }
    return 10;
}

@end
