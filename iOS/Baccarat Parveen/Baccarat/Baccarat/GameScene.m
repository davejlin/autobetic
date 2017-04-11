//
//  GameScene.m
//  Baccarat
//
//  Created by Parveen Khatkar on 8/2/15.
//  Copyright (c) 2015 Codetrix Studio. All rights reserved.
//

#import "GameScene.h"
#import "Card.h"
#import "Shoe.h"
#import "Table.h"

@interface GameScene()
{
    
}
@end

@implementation GameScene

-(void)didMoveToView:(SKView *)view {
    /* Setup your scene here */
    self.myLabel = [SKLabelNode labelNodeWithFontNamed:@"Chalkduster"];
    
    self.myLabel.text = @"Hello!";
    self.myLabel.fontSize = 30;
    self.myLabel.position = CGPointMake(CGRectGetMidX(self.frame),
                                        CGRectGetMidY(self.frame));
    
    self.lblScore = [SKLabelNode labelNodeWithFontNamed:@"Chalkduster"];
    
    self.lblScore.text = @"";
    self.lblScore.fontSize = 20;
    self.lblScore.position = CGPointMake(CGRectGetMidX(self.frame),
                                        CGRectGetMidY(self.frame) + 50);
    
    [self addChild:self.myLabel];
    [self addChild:self.lblScore];
    
        
    self.table = [[Table alloc] initWithScene:self];
}

-(void)touchesBegan:(NSSet *)touches withEvent:(UIEvent *)event {
    /* Called when a touch begins */
    
//    for (UITouch *touch in touches)
//    {
//        CGPoint location = [touch locationInNode:self];
//        
//        Card *sprite = [shoe drawCard:0];
//        if (shoe.cards.count == 0)
//        {
//            shoe = [shoe initWithDecks:4];
//        }
//        
//        sprite.xScale = 0.5;
//        sprite.yScale = 0.5;
//        sprite.position = location;
//        
////        SKAction *action = [SKAction rotateByAngle:M_PI duration:1];
//        
////        [sprite runAction:[SKAction repeatActionForever:action]];
//        
//        [self addChild:sprite];
//    }
}

-(void)update:(CFTimeInterval)currentTime {
    /* Called before each frame is rendered */
}


@end
