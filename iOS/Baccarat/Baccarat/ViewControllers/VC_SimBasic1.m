//
//  VC_SimBasic1
//  Baccarat
//
//  Created by Chicago Team on 1/4/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "VC_SimBasic1.h"

@interface VC_SimBasic1 ()

@end

@implementation VC_SimBasic1

@synthesize delegate = _delegate;
@synthesize indexNumber = _indexNumber;

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    _indexNumber = 0;
    
    // for KeyboardAvoider:
    _bankrollField.delegate = self;
    _baseBetField.delegate = self;
    _maxBetField.delegate = self;
    _minTableBetField.delegate = self;
    _maxTableBetField.delegate = self;
    
    // on normal keyboard, show "Done" instead of "return"
    /*
    _bankrollField.returnKeyType = UIReturnKeyDone;
    _baseBetField.returnKeyType = UIReturnKeyDone;
    _maxBetField.returnKeyType = UIReturnKeyDone;
    _minTableBetField.returnKeyType = UIReturnKeyDone;
    _maxTableBetField.returnKeyType = UIReturnKeyDone;
    */
     
    _bankrollField.keyboardType = UIKeyboardTypeNumberPad;
    _baseBetField.keyboardType = UIKeyboardTypeNumberPad;
    _maxBetField.keyboardType = UIKeyboardTypeNumberPad;
    _minTableBetField.keyboardType = UIKeyboardTypeNumberPad;
    _maxTableBetField.keyboardType = UIKeyboardTypeNumberPad;
}

- (void)dealloc {
    //NSLog(@"*** SIM BASIC 1 DEALLOC ***");
}

- (void) viewDidAppear:(BOOL)animated{
    [self populateSettingValues];
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

- (IBAction)bankrollEditEnd:(id)sender {
    [self.standardUserDefaults setObject:_bankrollField.text forKey:@"simBasicBankroll"];
}

- (IBAction)baseBetEditEnd:(id)sender {
    [self.standardUserDefaults setObject:_baseBetField.text forKey:@"simBasicBaseBet"];
}

- (IBAction)maxBetEditEnd:(id)sender {
    [self.standardUserDefaults setObject:_maxBetField.text forKey:@"simBasicMaxBet"];
}

- (IBAction)minTableBetEditEnd:(id)sender {
    [self.standardUserDefaults setObject:_minTableBetField.text forKey:@"simBasicTableLimitsMin"];
}

- (IBAction)maxTableBetEditEnd:(id)sender {
    [self.standardUserDefaults setObject:_maxTableBetField.text forKey:@"simBasicTableLimitsMax"];
}

- (IBAction)bankrollEditBegin:(id)sender {
}

- (IBAction)baseBetEditBegin:(id)sender {
}

- (IBAction)maxBetEditBegin:(id)sender {
}

- (IBAction)minTableBetEditBegin:(id)sender {
}

- (IBAction)maxTableBetEditBegin:(id)sender {
}

- (IBAction)nextButton:(id)sender {
    //Is anyone listening
    if([_delegate respondsToSelector:@selector(goToBetSelectionPage)])
    {
        //send the delegate function with the amount entered by the user
        [_delegate goToBetSelectionPage];
    }
}

- (void) populateSettingValues {
    _bankrollField.text = [self.standardUserDefaults objectForKey:@"simBasicBankroll"];
    _baseBetField.text = [self.standardUserDefaults objectForKey:@"simBasicBaseBet"];
    _maxBetField.text = [self.standardUserDefaults objectForKey:@"simBasicMaxBet"];
    _minTableBetField.text = [self.standardUserDefaults objectForKey:@"simBasicTableLimitsMin"];
    _maxTableBetField.text = [self.standardUserDefaults objectForKey:@"simBasicTableLimitsMax"];
}

@end
