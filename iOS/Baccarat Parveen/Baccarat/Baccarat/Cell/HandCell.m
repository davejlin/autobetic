//
//  HandCell.m
//  Baccarat
//
//  Created by Parveen Khatkar on 8/23/15.
//  Copyright (c) 2015 Codetrix Studio. All rights reserved.
//

#import "HandCell.h"

@interface HandCell()
{
    
}
@end

@implementation HandCell

- (void)awakeFromNib
{
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated
{
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

-(void)initialize:(Hand*)hand
{
    
    //0 - player; 1 - banker; 2 - tie
    if (hand.winner == 0)
    {
        [self.btnWinnerSymbol setTintColor:[UIColor blackColor]];
    }
    else if (hand.winner == 1)
    {
        [self.btnWinnerSymbol setTintColor:[UIColor redColor]];
    }
    else
    {
        [self.btnWinnerSymbol setTintColor:[UIColor lightGrayColor]];
    }
    
    for (int i = 0; i < hand.bankerCards.count; i++)
    {
        Card *card = [hand.bankerCards objectAtIndex:i];
        ((UIImageView *)[self.viewBanker.subviews objectAtIndex:i]).image = [UIImage imageNamed:[NSString stringWithFormat:@"%d%c", card.number, card.suit]];
    }
    
    for (int i = 0; i < hand.playerCards.count; i++)
    {
        Card *card = [hand.playerCards objectAtIndex:i];
        ((UIImageView *)[self.viewPlayer.subviews objectAtIndex:i]).image = [UIImage imageNamed:[NSString stringWithFormat:@"%d%c", card.number, card.suit]];
    }
}

@end
