//
//  ShoeResults.h
//  Baccarat
//
//  Created by Chicago Team on 2/14/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Coup.h"

@interface ShoeResults : NSObject
@property (nonatomic, strong) NSMutableArray *shoe;
-(void) addACoupToShoe:(Coup*) aCoup;
@end
