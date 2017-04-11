//
//  GameController.m
//  Baccarat
//
//  Created by Parveen Khatkar on 8/23/15.
//  Copyright (c) 2015 Codetrix Studio. All rights reserved.
//

#import "GameController.h"
#import "HandCell.h"
#import "GameTable.h"

@interface GameController ()
{
    NSString *cellIdentifier;

    GameTable *gameTable;
}

@end

@implementation GameController

- (void)viewDidLoad
{
    [super viewDidLoad];

    cellIdentifier = @"HandCell";
    
    [self.tableView registerNib:[UINib nibWithNibName:cellIdentifier bundle:nil] forCellReuseIdentifier:cellIdentifier];
    
    self.tableView.dataSource = self;
    self.tableView.delegate = self;
    
    gameTable = [GameTable new];
}

- (void)didReceiveMemoryWarning
{
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

-(NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return gameTable.hands.count;
}

-(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    HandCell *cell = [tableView dequeueReusableCellWithIdentifier:cellIdentifier forIndexPath:indexPath];
    [cell initialize:[gameTable.hands objectAtIndex:indexPath.row]];
    return cell;
}

- (IBAction)deal:(id)sender
{
    int handsToPlay = 1;//[self.txtHands.text intValue];
    for (int i = 0; i < handsToPlay; i++)
    {
        Hand *hand = [Hand new];
        hand.bettedOn = (int)self.segmentBet.selectedSegmentIndex;
        hand.betAmount = 0;
        hand.betAmount += [self.txtBetAmount.text intValue];
        [gameTable.hands addObject:hand];
        [gameTable dealHand];
    }
    
//    NSLog(@"%d", gameTable.hands.count);
    [self.tableView reloadData];
    
    NSUInteger bankerWins = [gameTable.hands indexesOfObjectsPassingTest:^BOOL(id obj, NSUInteger idx, BOOL *stop) {
        if (((Hand*)obj).winner == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }].count;
    
    
    NSUInteger playerWins = [gameTable.hands indexesOfObjectsPassingTest:^BOOL(id obj, NSUInteger idx, BOOL *stop) {
        if (((Hand*)obj).winner == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }].count;
    
    self.lblBankerWins.text = [NSString stringWithFormat:@"%lu", (unsigned long)bankerWins];
    self.lblPlayerWins.text = [NSString stringWithFormat:@"%lu", (unsigned long)playerWins];
    NSInteger won = [[gameTable.hands valueForKeyPath:@"@sum.self.returnAmount"] integerValue];
    NSInteger total = [[gameTable.hands valueForKeyPath:@"@sum.self.betAmount"] integerValue];
    self.lblMeta.text = [NSString stringWithFormat:@"won:$%ld  lost:$%ld of total:$%ld", (long)won, total - won, total];
    
    [self.tableView scrollToRowAtIndexPath:[NSIndexPath indexPathForRow:gameTable.hands.count-1 inSection:0] atScrollPosition:UITableViewScrollPositionBottom animated:YES];
}

@end
