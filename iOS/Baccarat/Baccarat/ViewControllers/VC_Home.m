//
//  ViewController.m
//  Baccarat
//
//  Created by Chicago Team on 12/29/14.
//  Copyright (c) 2014 AutoBetic. All rights reserved.
//

#import "VC_Home.h"

@interface VC_Home ()

@end

@implementation VC_Home

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view, typically from a nib.
}

- (void)dealloc {
    //NSLog(@"*** HOME DEALLOC ***");
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (UIStatusBarStyle)preferredStatusBarStyle
{
    return UIStatusBarStyleLightContent;
}

-(IBAction)returnToHome:(UIStoryboardSegue *)segue {
}

@end
