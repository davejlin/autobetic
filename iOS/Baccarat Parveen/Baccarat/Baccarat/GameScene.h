//
//  GameScene.h
//  Baccarat
//

//  Copyright (c) 2015 Codetrix Studio. All rights reserved.
//

#import <SpriteKit/SpriteKit.h>
#import "Table.h"

@interface GameScene : SKScene

@property Table* table;
@property SKLabelNode* lblScore;
@property SKLabelNode* myLabel;

@end
