//
//  GameController.h
//  Baccarat
//
//  Created by Parveen Khatkar on 8/23/15.
//  Copyright (c) 2015 Codetrix Studio. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface GameController : UIViewController <UITableViewDelegate, UITableViewDataSource>

@property (weak, nonatomic) IBOutlet UITableView *tableView;
@property (weak, nonatomic) IBOutlet UILabel *lblBankerWins;
@property (weak, nonatomic) IBOutlet UILabel *lblPlayerWins;
@property (weak, nonatomic) IBOutlet UISegmentedControl *segmentBet;
@property (weak, nonatomic) IBOutlet UITextField *txtBetAmount;

@property (weak, nonatomic) IBOutlet UILabel *lblMeta;


@end
