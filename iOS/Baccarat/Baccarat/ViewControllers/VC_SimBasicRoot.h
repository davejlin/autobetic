//
//  VC_SimBasicRoot.h
//  Baccarat
//
//  Created by Chicago Team on 1/4/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "VC_Sim.h"
#import "VC_SimBasic1.h"
#import "VC_SimBasic2.h"
#import "UIToolbarViewController.h"

@interface VC_SimBasicRoot : UIToolbarViewController <UIPageViewControllerDataSource, VC_SimDelegate>
@property (strong, nonatomic) UIPageViewController *pageViewController;
@property (weak, nonatomic) IBOutlet UIToolbar *toolbar;
@end
