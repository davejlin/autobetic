//
//  ShoeResults.m
//  Baccarat
//
//  Created by Chicago Team on 2/14/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "ShoeResults.h"


@implementation ShoeResults

-(id)init {
    self = [super init];
    if (self != nil) {
        _shoe = [[NSMutableArray alloc] init];
    }
    return self;
}

-(void) addACoupToShoe:(Coup*) aCoup {
    [_shoe addObject:aCoup];
}
@end
