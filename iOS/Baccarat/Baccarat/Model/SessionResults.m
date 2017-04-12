//
//  SessionResults.m
//  Baccarat
//
//  Created by Chicago Team on 2/14/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "SessionResults.h"

@implementation SessionResults

-(id)init {
    self = [super init];
    if (self != nil) {
        _session = [[NSMutableArray alloc] init];
    }
    return self;
}

-(void) addAShoeToSession:(ShoeResults*) aShoe {
    [_session addObject:aShoe];
}
@end
