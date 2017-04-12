//
//  VC_SimBasic2.m
//  Baccarat
//
//  Created by Chicago Team on 1/11/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "VC_SimBasic2.h"

@interface VC_SimBasic2 ()

@end

@implementation VC_SimBasic2
@synthesize indexNumber = _indexNumber;
@synthesize scrollView = _scrollView;
int scrollExtra;

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    _indexNumber = 1;
    
    _scrollView.indicatorStyle = UIScrollViewIndicatorStyleWhite;
    _scrollView.directionalLockEnabled = YES;    
    
    // scroll picker data:
    _betOnArray = [[NSArray alloc] initWithObjects:@"Banker", @"Player", @"Tie", nil];
    _betWhenArray = [[NSArray alloc] initWithObjects:@"Always", @"Custom trigger", nil];
    _betProgArray = [[NSArray alloc] initWithObjects:@"Always base bet", @"Double on loss", @"Custom prog", nil];
    
    _betOnPicker = [[UIPickerView alloc] initWithFrame:CGRectZero];
    _betWhenPicker = [[UIPickerView alloc] initWithFrame:CGRectZero];
    _betProgPicker = [[UIPickerView alloc] initWithFrame:CGRectZero];
    
    [self attachPickerToTextField:_betOnField :_betOnPicker];
    [self attachPickerToTextField:_betWhenField :_betWhenPicker];
    [self attachPickerToTextField:_betProgField :_betProgPicker];
    
    _customTriggerField.delegate = self;
    _customProgField.delegate = self;
    
    _customTriggerField.keyboardType = UIKeyboardTypeAlphabet;
    _customProgField.keyboardType = UIKeyboardTypeDecimalPad;
    
    _customTriggerField.autocorrectionType = UITextAutocorrectionTypeNo;
    _customProgField.autocorrectionType = UITextAutocorrectionTypeNo;
    
    _customTriggerLabel.hidden = true;
    _customTriggerField.hidden = true;
    _customProgLabel.hidden = true;
    _customProgField.hidden = true;
}

- (void) viewDidAppear:(BOOL)animated{
    [self initPickerAndSettingValues];
}

- (void)dealloc {
    //NSLog(@"*** SIM BASIC 2 DEALLOC ***");
}

- (void)attachPickerToTextField: (UITextField*) textField :(UIPickerView*) picker{
    picker.delegate = self;
    picker.dataSource = self;
    
    textField.delegate = self;
    textField.inputView = picker;
}

// let tapping on the background (off the input field) close the thing
- (void)touchesBegan:(NSSet *)touches withEvent:(UIEvent *)event {
    [_betOnField resignFirstResponder];
    [_betWhenField resignFirstResponder];
    [_betProgField resignFirstResponder];
}
                    
#pragma mark - Picker delegate stuff
                    
- (NSInteger)numberOfComponentsInPickerView:(UIPickerView *)pickerView
{
    return 1;
}
                    
- (NSInteger)pickerView:(UIPickerView *)pickerView numberOfRowsInComponent:(NSInteger)component
{
    if (pickerView == _betOnPicker){
        return _betOnArray.count;
    } else if (pickerView == _betWhenPicker){
        return _betWhenArray.count;
    } else if (pickerView == _betProgPicker){
        return _betProgArray.count;
    }

    return 0;
}
    
-(NSString *)pickerView:(UIPickerView *)pickerView titleForRow:(NSInteger)row   forComponent:(NSInteger)component
{
    if (pickerView == _betOnPicker){
        return [_betOnArray objectAtIndex:row];
    } else if (pickerView == _betWhenPicker){
        return [_betWhenArray objectAtIndex:row];
    } else if (pickerView == _betProgPicker){
        return [_betProgArray objectAtIndex:row];
    }
    
    return @"???";
}
                    
- (void)pickerView:(UIPickerView *)pickerView didSelectRow:(NSInteger)row   inComponent:(NSInteger)component
{
    if (pickerView == _betOnPicker){
        _betOnField.text = [_betOnArray objectAtIndex:row];
    } else if (pickerView == _betWhenPicker){
        _betWhenField.text = [_betWhenArray objectAtIndex:row];
        if (row == 1) {
            _customTriggerLabel.hidden = false;
            _customTriggerField.hidden = false;
        } else {
            _customTriggerLabel.hidden = true;
            _customTriggerField.hidden = true;
        }
    } else if (pickerView == _betProgPicker){
        _betProgField.text = [_betProgArray objectAtIndex:row];
        if (row == 2) {
            _customProgLabel.hidden = false;
            _customProgField.hidden = false;
        } else {
            _customProgLabel.hidden = true;
            _customProgField.hidden = true;
        }
    }
}
                    
- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void) initPickerAndSettingValues {
    [self initSettingValues];
    [self initPickerRow];
}

- (void) initSettingValues {
    // bet placement
    NSInteger row = [[self.standardUserDefaults objectForKey:@"simBasicBetPlacement"] integerValue];
    _betOnField.text = [_betOnArray objectAtIndex:row];
    
    // bet frequency
    row = [[self.standardUserDefaults objectForKey:@"simBasicBetFrequency"] integerValue];
    _betWhenField.text = [_betWhenArray objectAtIndex:row];
    
    _customTriggerField.text = [self.standardUserDefaults stringForKey:@"simBasicCustomTrigger"];
    if (row == 1) {
        _customTriggerLabel.hidden = false;
        _customTriggerField.hidden = false;
    }
    
    // bet progression
    row = [[self.standardUserDefaults objectForKey:@"simBasicBetProgression"] integerValue];
    _betProgField.text = [_betProgArray objectAtIndex:row];
    
    _customProgField.text = [self.standardUserDefaults stringForKey:@"simBasicCustomProgression"];
    if (row == 2) {
        _customProgLabel.hidden = false;
        _customProgField.hidden = false;
    }
}

- (void) initPickerRow {
    int betPlacementSelection = (int)[[[NSUserDefaults standardUserDefaults] objectForKey:@"simBasicBetPlacement"] integerValue];
    int betFrequencySelection = (int)[[[NSUserDefaults standardUserDefaults] objectForKey:@"simBasicBetFrequency"] integerValue];
    int betProgressionSelection = (int)[[[NSUserDefaults standardUserDefaults] objectForKey:@"simBasicBetProgression"] integerValue];
    
    [_betOnPicker selectRow:betPlacementSelection inComponent:0 animated:true];
    [_betWhenPicker selectRow:betFrequencySelection inComponent:0 animated:true];
    [_betProgPicker selectRow:betProgressionSelection inComponent:0 animated:true];
}

 #pragma mark - Navigation
 
 // In a storyboard-based application, you will often want to do a little preparation before navigation
 - (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
     if ([[segue identifier] isEqualToString:@"segueToResults"])
     {
         // Get reference to the destination view controller
         // VC_SimResults *vc = [segue destinationViewController];
     }
 }

- (IBAction)runAutoBetButtonPressed:(id)sender {
    [self performSegueWithIdentifier:@"segueToResults" sender:self];
}

- (IBAction)betOnEditEnd:(id)sender {
    NSUInteger value = [_betOnArray indexOfObject:_betOnField.text];
    [self.standardUserDefaults setInteger:value forKey:@"simBasicBetPlacement"];
}

- (IBAction)betWhenEditEnd:(id)sender {
    NSUInteger value = [_betWhenArray indexOfObject:_betWhenField.text];
    [self.standardUserDefaults setInteger:value forKey:@"simBasicBetFrequency"];
}

- (IBAction)betProgEditEnd:(id)sender {
    NSUInteger value = [_betProgArray indexOfObject:_betProgField.text];
    [self.standardUserDefaults setInteger:value forKey:@"simBasicBetProgression"];
}

- (IBAction)customTriggerEditEnd:(id)sender {
    [self.standardUserDefaults setValue:_customTriggerField.text forKey:@"simBasicCustomTrigger"];
}

- (IBAction)customProgEditEnd:(id)sender {
    [self.standardUserDefaults setValue:_customProgField.text forKey:@"simBasicCustomProgression"];
}

@end
