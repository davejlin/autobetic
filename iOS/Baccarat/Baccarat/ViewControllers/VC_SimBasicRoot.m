//
//  VC_SimBasicRoot.m
//  Baccarat
//
//  Created by Chicago Team on 1/4/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "VC_SimBasicRoot.h"

@interface VC_SimBasicRoot ()

@end

@implementation VC_SimBasicRoot

VC_SimBasic1 *vc1;
VC_SimBasic2 *vc2;
int currentIndex;

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    // Create page view controller
    self.pageViewController = [self.storyboard instantiateViewControllerWithIdentifier:@"PageViewController"];
    self.pageViewController.dataSource = self;

    vc1 = [self viewController1];
    vc2 = [self viewController2];

    currentIndex = 0;
    NSArray *viewControllers = @[vc1];
    [self.pageViewController setViewControllers:viewControllers direction:UIPageViewControllerNavigationDirectionForward animated:NO completion:nil];
    
    // Change the size of page view controller
    self.pageViewController.view.frame = CGRectMake(0, 0, self.view.frame.size.width, self.view.frame.size.height - 44);
    
    [self addChildViewController:_pageViewController];
    [self.view addSubview:_pageViewController.view];
    [self.pageViewController didMoveToParentViewController:self];
}

- (void)dealloc {
    //NSLog(@"*** SIM BASIC ROOT DEALLOC ***");
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

#pragma mark - Page View Controller Data Source

- (UIViewController *)pageViewController:(UIPageViewController *)pageViewController viewControllerBeforeViewController:(UIViewController *)viewController
{
    NSInteger indexNumber = ((VC_Sim *) viewController).indexNumber;
    if (indexNumber == NSNotFound || indexNumber == 0) {
        return nil;
    }
    
    currentIndex = 0;
    
    return vc1;
}

- (UIViewController *)pageViewController:(UIPageViewController *)pageViewController viewControllerAfterViewController:(UIViewController *)viewController
{
    NSInteger indexNumber = ((VC_Sim *) viewController).indexNumber;
    if (indexNumber == NSNotFound || indexNumber == 1) {
        return nil;
    }
    
    currentIndex = 1;
    
    return vc2;
}

- (VC_SimBasic1 *)viewController1
{
    VC_SimBasic1 *vc = [self.storyboard instantiateViewControllerWithIdentifier:@"SimBasicViewController1"];
    vc.delegate = self;
    return vc;
}

- (VC_SimBasic2 *)viewController2
{
    return [self.storyboard instantiateViewControllerWithIdentifier:@"SimBasicViewController2"];
    
}

//- (NSInteger)presentationCountForPageViewController:(UIPageViewController *)pageViewController
//{
//    return 2;
//}
//
//- (NSInteger)presentationIndexForPageViewController:(UIPageViewController *)pageViewController
//{
//    return currentIndex;
//}
//
//- (UIStatusBarStyle)preferredStatusBarStyle
//{
//    return UIStatusBarStyleLightContent;
//}

- (BOOL) canPerformUnwindSegueAction:(SEL)action fromViewController:(UIViewController *)fromViewController withSender:(id)sender {
    return NO;
}

#pragma mark - VC_Sim Delegate

-(void)goToBetSelectionPage {

    currentIndex = 1;
    NSArray *viewControllers = @[vc2];
    [self.pageViewController setViewControllers:viewControllers direction:UIPageViewControllerNavigationDirectionForward animated:YES completion:NULL];
}

@end