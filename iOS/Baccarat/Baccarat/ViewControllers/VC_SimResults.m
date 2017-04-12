//
//  SimResults.m
//  Baccarat
//
//  Created by Chicago Team on 1/25/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "VC_SimResults.h"

@implementation VC_SimResults
NSArray *shoeScores;
double winPercentage = 0.0;
double lossPercentage = 0.0;
double pa = 0.0;
double netUnits = 0.0;
bool receivedResults = false;
Session *session;

- (void) dealloc
{
    // If you don't remove yourself as an observer, the Notification Center
    // will continue to try and send notification objects to the deallocated
    // object.
    [[NSNotificationCenter defaultCenter] removeObserver:self];
    //NSLog(@"*** SIM BASIC RESULTS DEALLOC ***");
}

- (void)viewDidLoad {
    [super viewDidLoad];
    [self onStatisticsView];
    [self offSegmentedControlOnActivitySpinner];

    [self clearVariables];
    [self setLineChartViewAttributes];
    
    [self startGame];
}

- (void) clearVariables {
    shoeScores = [[NSArray alloc] init];
    winPercentage = 0.0;
    lossPercentage = 0.0;
    pa = 0.0;
    netUnits = 0.0;
}

- (void) setLineChartViewAttributes {
    _lineChartView.drawsDataLines = true;
    _lineChartView.drawsDataPoints = false;
    _lineChartView.backgroundColor = [UIColor blackColor];
}

- (UIStatusBarStyle)preferredStatusBarStyle
{
    return UIStatusBarStyleLightContent;
}

- (IBAction)segmentedControlAction:(id)sender {
    if(_segmentedControl.selectedSegmentIndex == 0)
    {
        [self onStatisticsView];
    } else if (_segmentedControl.selectedSegmentIndex == 1)
    {
        [self onGraphView];
    }
}

- (void) onStatisticsView {
    _titleLabel.text = @"Autobet Sim Statistics";
    _statisticsView.hidden = false;
    _graphView.hidden = true;
}

- (void) onGraphView {
    _titleLabel.text = @"Autobet Sim Shoe vs Score";
    _statisticsView.hidden = true;
    _graphView.hidden = false;
}

- (void) offAllViews {
    _statisticsView.hidden = true;
    _graphView.hidden = true;
}

- (void) offSegmentedControlOnActivitySpinner {
    _segmentedControl.userInteractionEnabled = false;
    [_activitySpinner startAnimating];
}

- (void) onSegmentedControlOffActivitySpinner {
    _segmentedControl.userInteractionEnabled = true;
    [_activitySpinner stopAnimating];
}

- (void) switchSegmentedControlToStatisticsView {
    _segmentedControl.selectedSegmentIndex = 0;
    [_segmentedControl sendActionsForControlEvents:UIControlEventValueChanged];
}

- (void) reloadGraphsLabels {
    [self reloadPieGraph];
    [self reloadLineGraph];
    [self reloadLabels];
}

- (IBAction)refreshButtonPressed:(UIButton *)sender {
    [self switchSegmentedControlToStatisticsView];
    [self startGame];
}

- (IBAction)backButtonPressed:(id)sender {
    [self dismissViewControllerAnimated:YES completion:nil];
}

- (void) startGame {
    [self offAllViews];
    [self offSegmentedControlOnActivitySpinner];
    
    dispatch_async(dispatch_get_global_queue(0, 0),
    ^ {
        session = [[Session alloc] init];
        [session startSession];
        [self loadSessionResults];
        
        dispatch_async(dispatch_get_main_queue(), ^{
            [self reloadGraphsLabels];
            [self onStatisticsView];
            [self onSegmentedControlOffActivitySpinner];
        });
    });
}

- (void)loadSessionResults {
    SessionStatistics *sessionStatistics = [session getSessionStatistics];
    // statistics pie graph
    winPercentage = sessionStatistics.winPercentage;
    lossPercentage = sessionStatistics.lossPercentage;
    pa = sessionStatistics.playersAdvantage;
    netUnits = sessionStatistics.nNetUnits;
    
    // line graph:
    shoeScores = [session getShoeScores];
}

#pragma mark Line Graph Methods

- (void)reloadLineGraph {
    LCLineChartData *d = [LCLineChartData new];
    d.xMin = 0;
    d.xMax = shoeScores.count;
    //d.title = @"Shoe vs Score Graph";
    d.color = [UIColor blueColor];
    d.itemCount = shoeScores.count;
    d.getData = ^(NSUInteger item) {
        float x = item;
        float y = [shoeScores[item] floatValue];
        NSString *label1 = [NSString stringWithFormat:@"%lu", (unsigned long)item+1];
        NSString *label2 = [NSString stringWithFormat:@"%f", y];
        return [LCLineChartDataItem dataItemWithX:x y:y xLabel:label1 dataLabel:label2];
    };
    
    float max = -MAXFLOAT;
    float min = MAXFLOAT;
    for (NSNumber *num in shoeScores) {
        float x = num.floatValue;
        if (x < min) min = x;
        if (x > max) max = x;
    }
    _lineChartView.yMin = min;
    _lineChartView.yMax = max;
    
    _lineChartView.ySteps = @[[NSString stringWithFormat:@"%.02f", _lineChartView.yMin],
                              [NSString stringWithFormat:@"%.02f", 0.5*(_lineChartView.yMin+_lineChartView.yMax)],
                              [NSString stringWithFormat:@"%.02f", _lineChartView.yMax]];
    
    _lineChartView.data = @[d];
}

#pragma mark pie chart helper methods

- (void)reloadPieGraph {
    NSMutableArray *dataArray = [NSMutableArray arrayWithCapacity:2];
    NSNumber *one = [NSNumber numberWithDouble:lossPercentage]; [dataArray addObject:one];
    NSNumber *two = [NSNumber numberWithDouble:winPercentage]; [dataArray addObject:two];
    
    [_pieChartView renderInLayer:_pieChartView dataArray:dataArray];
}

- (void)reloadLabels {
    _playersAdvantageLabel.text = [NSString stringWithFormat:@"P.A.: %0.2f%%", pa];
    _netUnitsLabel.text = [NSString stringWithFormat:@"Net Units: %0.2f", netUnits];
}

@end
