//
//  SimResults.h
//  Baccarat
//
//  Created by Chicago Team on 1/25/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "UIToolbarViewController.h"
#import "Constants.h"
#import "Utilities.h"
#import "SessionStatistics.h"
#import "DLPieChart.h"
#import "LCLineChartView.h"
#import "Session.h"
#import "VC_SimBasic2.h"

@interface VC_SimResults : UIToolbarViewController
@property (strong, nonatomic) IBOutlet UISegmentedControl *segmentedControl;
- (IBAction)segmentedControlAction:(id)sender;

@property (strong, nonatomic) IBOutlet UIView *statisticsView;
@property (strong, nonatomic) IBOutlet UIView *graphView;
@property (strong, nonatomic) IBOutlet UILabel *titleLabel;
@property (weak, nonatomic) IBOutlet UIToolbar *toolbar;
@property (strong, nonatomic) IBOutlet DLPieChart *pieChartView;
@property (strong, nonatomic) IBOutlet UILabel *playersAdvantageLabel;
@property (weak, nonatomic) IBOutlet UILabel *netUnitsLabel;
@property (weak, nonatomic) IBOutlet LCLineChartView *lineChartView;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *activitySpinner;

- (IBAction)refreshButtonPressed:(UIButton *)sender;
- (IBAction)backButtonPressed:(id)sender;
@end
