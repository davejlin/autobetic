//
//  DismissHelp.m
//  Baccarat
//
//  Created by Chicago Team on 1/11/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "DismissHelp.h"

@implementation DismissHelp

- (void)perform {
    UIViewController *sourceViewController = self.sourceViewController;
    [sourceViewController.presentingViewController dismissViewControllerAnimated:YES completion:nil];
}

@end
