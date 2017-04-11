//
//  HandCell.h
//  Baccarat
//
//  Created by Parveen Khatkar on 8/23/15.
//  Copyright (c) 2015 Codetrix Studio. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Hand.h"

@interface HandCell : UITableViewCell
@property (weak, nonatomic) IBOutlet UIButton *btnWinnerSymbol;
@property (weak, nonatomic) IBOutlet UIView *viewBanker;
@property (weak, nonatomic) IBOutlet UIView *viewPlayer;

-(void)initialize:(Hand*)hand;
@end
