//
//  VC_SimBasic1.h
//  Baccarat
//
//  Created by Chicago Team on 1/4/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "VC_Sim.h"

@interface VC_SimBasic1 : VC_Sim

@property (strong, nonatomic) IBOutlet UILabel *maxBetLabel;

@property (strong, nonatomic) IBOutlet UITextField *bankrollField;
@property (strong, nonatomic) IBOutlet UITextField *baseBetField;
@property (strong, nonatomic) IBOutlet UITextField *maxBetField;
@property (strong, nonatomic) IBOutlet UITextField *minTableBetField;
@property (strong, nonatomic) IBOutlet UITextField *maxTableBetField;

- (IBAction)bankrollEditEnd:(id)sender;
- (IBAction)baseBetEditEnd:(id)sender;
- (IBAction)maxBetEditEnd:(id)sender;
- (IBAction)minTableBetEditEnd:(id)sender;
- (IBAction)maxTableBetEditEnd:(id)sender;

- (IBAction)bankrollEditBegin:(id)sender;
- (IBAction)baseBetEditBegin:(id)sender;
- (IBAction)maxBetEditBegin:(id)sender;
- (IBAction)minTableBetEditBegin:(id)sender;
- (IBAction)maxTableBetEditBegin:(id)sender;

- (IBAction)nextButton:(id)sender;


@end
