//
//  Card.h
//  Baccarat
//
//  Created by Chicago Team on 12/30/14.
//  Copyright (c) 2014 AutoBetic. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Constants.h"

@interface Card : NSObject
-(id)initWithName:(CardValue)aValue withSuite:(CardSuite)aSuite;
@property (nonatomic,assign)CardSuite suite;
@property (nonatomic,assign)CardValue value;

@end
