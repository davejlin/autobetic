//
//  VC_Sim.m
//  Baccarat
//
//  Created by Chicago Team on 1/11/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "VC_Sim.h"

@interface VC_Sim ()

@end

@implementation VC_Sim

@synthesize scrollView = _scrollView;

UIGestureRecognizer *tapper;

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    _indexNumber = -1;
    _standardUserDefaults = [NSUserDefaults standardUserDefaults];
    
    // retract keyboard when tapping outside textfield:
    tapper = [[UITapGestureRecognizer alloc]
              initWithTarget:self action:@selector(handleSingleTap:)];
    tapper.cancelsTouchesInView = NO;
    [self.view addGestureRecognizer:tapper];
}

- (void)handleSingleTap:(UITapGestureRecognizer *) sender
{
    [self.view endEditing:YES];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
