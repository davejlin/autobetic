//
//  UIToolbarViewController.m
//  Baccarat
//
//  Created by Chicago Team on 1/10/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "UIToolbarViewController.h"

static NSString *segueReturnToHome = @"returnToHome";
static NSString *segueGoToHelp = @"goToHelp";

@implementation UIToolbarViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    [self createToolbar];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)createToolbar {
    UIBarButtonItem *home = [[UIBarButtonItem alloc] initWithImage:[[UIImage imageNamed:@"Home"] imageWithRenderingMode:UIImageRenderingModeAlwaysOriginal] style:UIBarButtonItemStylePlain target:self action:@selector(returnToHome:)];
    UIBarButtonItem *help = [[UIBarButtonItem alloc] initWithImage:[[UIImage imageNamed:@"Help"] imageWithRenderingMode:UIImageRenderingModeAlwaysOriginal] style:UIBarButtonItemStylePlain target:self action:@selector(goToHelp:)];
    UIBarButtonItem *upload = [[UIBarButtonItem alloc] initWithImage:[[UIImage imageNamed:@"Upload"] imageWithRenderingMode:UIImageRenderingModeAlwaysOriginal] style:UIBarButtonItemStylePlain target:self action:@selector(goToUpload:)];
    UIBarButtonItem *settings = [[UIBarButtonItem alloc] initWithImage:[[UIImage imageNamed:@"Settings"] imageWithRenderingMode:UIImageRenderingModeAlwaysOriginal] style:UIBarButtonItemStylePlain target:self action:@selector(goToSettings:)];
    UIBarButtonItem *spacer = [[UIBarButtonItem alloc] initWithBarButtonSystemItem:UIBarButtonSystemItemFlexibleSpace target:self action:nil];
    
    NSArray *buttonItems = [NSArray arrayWithObjects:home, spacer, upload, spacer, settings, spacer, help, nil];
    [_toolbar setItems:buttonItems];
}

- (IBAction)returnToHome:(UIButton *)sender {
    [self performSegueWithIdentifier:segueReturnToHome sender:self];
}

- (IBAction)goToHelp:(UIButton *)sender {
    UIViewController *vc = [self.storyboard instantiateViewControllerWithIdentifier:@"HelpViewController"];
    vc.modalTransitionStyle = UIModalTransitionStyleCoverVertical;
    [self presentViewController:vc animated:YES completion:nil];
}

- (IBAction)goToUpload:(UIButton *)sender {
    
    NSString *texttoshare = @"Autobetic Baccarat is the best!"; //this is your text string to share
    NSURL *urltoshare = [NSURL URLWithString:@"http://www.autobetic.com"]; // this is your url to share
    UIImage *imagetoshare = [self saveViewToImage]; //this is your image to share
    NSArray *activityItems = @[texttoshare, urltoshare, imagetoshare];
    UIActivityViewController *activityVC = [[UIActivityViewController alloc] initWithActivityItems:activityItems applicationActivities:nil];
    activityVC.excludedActivityTypes = @[UIActivityTypeAssignToContact];
    [self presentViewController:activityVC animated:TRUE completion:nil];
}

- (IBAction)goToSettings:(UIButton *)sender {
    //[[UIApplication sharedApplication] openURL:[NSURL URLWithString:UIApplicationOpenSettingsURLString]]; // goes to device's app settings page
    
    IASKAppSettingsViewController *appSettingsViewController = [[IASKAppSettingsViewController alloc] init];
    appSettingsViewController.delegate = self;
    appSettingsViewController.showDoneButton = YES;
    UINavigationController *aNavController = [[UINavigationController alloc] initWithRootViewController:appSettingsViewController];
    [self presentViewController:aNavController animated:YES completion:nil];
}

#pragma mark IASKAppSettingsViewControllerDelegate protocol
- (void)settingsViewControllerDidEnd:(IASKAppSettingsViewController*)sender {
    [self dismissViewControllerAnimated:YES completion:nil];
}

- (UIImage *)saveViewToImage {
    // Define the dimensions of the screenshot you want to take (the entire screen in this case)
    CGSize size =  [[UIScreen mainScreen] bounds].size;
    
    // Create the screenshot
    UIGraphicsBeginImageContext(size);
    // Put everything in the current view into the screenshot
    [[self.view layer] renderInContext:UIGraphicsGetCurrentContext()];
    // Save the current image context info into a UIImage
    UIImage *newImage = UIGraphicsGetImageFromCurrentImageContext();
    UIGraphicsEndImageContext();
    
    return newImage;
}

- (UIStatusBarStyle)preferredStatusBarStyle
{
    return UIStatusBarStyleLightContent;
}

@end
