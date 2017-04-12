//
//  SessionResults.h
//  Baccarat
//
//  Created by Chicago Team on 2/14/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "ShoeResults.h"

@interface SessionResults : NSObject
@property (nonatomic, strong) NSMutableArray *session;
-(void) addAShoeToSession:(ShoeResults*) aShoe;
@end
