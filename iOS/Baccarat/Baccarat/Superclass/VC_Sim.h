//
//  VC_Sim.h
//  Baccarat
//
//  Created by Chicago Team on 1/11/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//
#import <UIKit/UIKit.h>

@protocol VC_SimDelegate <NSObject>
-(void)goToBetSelectionPage;
@end

#import "KeyboardAvoider.h"

@interface VC_Sim : KeyboardAvoider
@property(nonatomic,assign)id delegate;
@property (nonatomic) NSUInteger indexNumber;
@property (weak, nonatomic) NSUserDefaults * standardUserDefaults;
@property (weak, nonatomic) IBOutlet UIScrollView *scrollView;
@end
