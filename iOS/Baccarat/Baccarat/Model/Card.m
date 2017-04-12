//
//  Card.m
//  Baccarat
//
//  Created by Chicago Team on 12/30/14.
//  Copyright (c) 2014 AutoBetic. All rights reserved.
//

#import "Card.h"

@implementation Card

-(id)init {
    self = [super init];
    if (self != nil) {
    }
    return self;
}

-(id)initWithName:(CardValue)aValue withSuite:(CardSuite)aSuite {
    self = [super init];
    if (self != nil) {
        _value = aValue;
        _suite = aSuite;
    }
    return self;
}

@end
