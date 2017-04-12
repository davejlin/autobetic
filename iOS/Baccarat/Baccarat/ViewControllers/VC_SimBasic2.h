//
//  VC_SimBasic2.h
//  Baccarat
//
//  Created by Chicago Team on 1/11/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "VC_Sim.h"
#import "VC_SimResults.h"

@interface VC_SimBasic2 : VC_Sim <UITextFieldDelegate, UIPickerViewDataSource, UIPickerViewDelegate>
@property (strong, nonatomic) IBOutlet UITextField *betOnField;
@property (strong, nonatomic) IBOutlet UITextField *betWhenField;
@property (strong, nonatomic) IBOutlet UITextField *betProgField;

@property (strong, nonatomic) IBOutlet UIPickerView *betOnPicker;
@property (strong, nonatomic) IBOutlet UIPickerView *betWhenPicker;
@property (strong, nonatomic) IBOutlet UIPickerView *betProgPicker;

@property (strong, nonatomic) NSArray *betOnArray;
@property (strong, nonatomic) NSArray *betWhenArray;
@property (strong, nonatomic) NSArray *betProgArray;

@property (strong, nonatomic) IBOutlet UITextField *customTriggerField;
@property (strong, nonatomic) IBOutlet UITextField *customProgField;

@property (strong, nonatomic) IBOutlet UILabel *customTriggerLabel;
@property (strong, nonatomic) IBOutlet UILabel *customProgLabel;

- (IBAction)runAutoBetButtonPressed:(id)sender;

- (IBAction)betOnEditEnd:(id)sender;
- (IBAction)betWhenEditEnd:(id)sender;
- (IBAction)betProgEditEnd:(id)sender;
- (IBAction)customTriggerEditEnd:(id)sender;
- (IBAction)customProgEditEnd:(id)sender;

@end
