//
//  UIToolbarViewController.h
//  Baccarat
//
//  Created by Chicago Team on 1/10/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "VC_Help.h"
#import "IASKAppSettingsViewController.h"

@interface UIToolbarViewController: UIViewController <IASKSettingsDelegate>
@property (weak, nonatomic) IBOutlet UIToolbar *toolbar;
@end
