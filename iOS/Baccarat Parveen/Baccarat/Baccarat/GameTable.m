//
//  GameTable.m
//  Baccarat
//
//  Created by Parveen Khatkar on 8/23/15.
//  Copyright (c) 2015 Codetrix Studio. All rights reserved.
//

#import "GameTable.h"

@interface GameTable()
{
    Shoe *shoe;
    
    CGPoint cardStartPos;
    CGPoint cardEndPos;
    CGPoint playerCardsStartPos;
    CGPoint bankerCardsStartPos;
    NSMutableArray *cardsPos;
    int zPos;
}
@end

@implementation GameTable

-(instancetype)init
{
    self.currentPlayerCards = (NSMutableArray<Card>*)[NSMutableArray new];
    self.currentBankerCards = (NSMutableArray<Card>*)[NSMutableArray new];
    self.hands = (NSMutableArray<Hand>*)[NSMutableArray new];
    
    shoe = [[Shoe alloc] initWithDecks:4];
    
//    cardStartPos = CGPointMake(gameScene.size.width / 2, gameScene.size.height + 100);
//    cardEndPos = CGPointMake(-60, gameScene.size.height - 50);
//    playerCardsStartPos = CGPointMake(40, gameScene.size.height - 50);
//    bankerCardsStartPos = CGPointMake(gameScene.size.width / 2 + 54, gameScene.size.height - 50);
//    cardsPos = [NSMutableArray arrayWithObjects:[NSValue valueWithCGPoint:playerCardsStartPos], [NSValue valueWithCGPoint:bankerCardsStartPos], nil];
    self.turn = 0;
    zPos = 10;
    

    return self;

}


-(int)winner
{
    //0 - player; 1 - banker; 2 - tie
    if ([self playerTotal] > [self bankerTotal])
    {
        return 0;
    }
    else if ([self playerTotal] < [self bankerTotal])
    {
        return 1;
    }
    return 2;
}

-(NSString*)winnerMessage
{
    //0 - player; 1 - banker; 2 - tie
    if ([self playerTotal] > [self bankerTotal])
    {
        return @"Player is winner!";
    }
    else if ([self playerTotal] < [self bankerTotal])
    {
        return @"Banker is winner!";
    }
    return @"It's a tie!";
}

-(int)playerTotal
{
    int total = 0;
    for (Card *card in self.currentPlayerCards)
    {
        total += [card value];
    }
    
    return [self normalizeTotal:total];
}

-(int)bankerTotal
{
    int total = 0;
    for (Card *card in self.currentBankerCards)
    {
        total += [card value];
    }
    return [self normalizeTotal:total];
}

-(int)normalizeTotal:(int)total
{
    if (total > 10)
    {
        return total % 10;
    }
    if (total == 10)
    {
        return 0;
    }
    return total;
}

-(int)playerThirdCard
{
    if (self.currentPlayerCards.count < 3)
    {
        return 0;
    }
    return ((Card*)self.currentPlayerCards[2]).value;
}

-(BOOL)playerNeedsAnotherCard
{
    int pTotal = [self playerTotal];
    int bTotal = [self bankerTotal];
    
    if (pTotal >= 8 || bTotal >= 8)
    {
        //natural hand
        return false;
    }
    else if (pTotal >= 6)
    {
        return false;
    }
    return true;
}

-(BOOL)bankerNeedsAnotherCard
{
    int pTotal = [self playerTotal];
    int bTotal = [self bankerTotal];
    
    if ((pTotal >= 8 || bTotal >= 7) && self.currentPlayerCards.count == 2)
    {
        return false;
    }
    else if (bTotal == 6 && [@[@6, @7] containsObject:@([self playerThirdCard])] && self.currentPlayerCards.count == 3)//player third card is 6 or 7 and player have drawn third card
    {
        return true;
    }
    else if (bTotal == 5 && [@[@0, @4, @5, @6, @7] containsObject:@([self playerThirdCard])])//@0 indicates no third card
    {
        return true;
    }
    else if (bTotal == 4 && [@[@0, @2, @3, @4, @5, @6, @7] containsObject:@([self playerThirdCard])])
    {
        return true;
    }
    else if (bTotal == 3 && [self playerThirdCard] != 8)
    {
        return true;
    }
    else if (bTotal <= 2)
    {
        return true;
    }
    return false;
}

-(void)showAll:(void (^)())completion
{
    NSMutableArray<Card> *cards = [self allCards];
    
    CGFloat delay = 0;
    for (int i = 0; i < 4; i++)
    {
        if (i == 3)
        {
            [cards[i] flipAfter:delay completion:^{
                completion();
            }];
        }
        else
        {
            [cards[i] flipAfter:delay completion:nil];
            delay+=0.3;
            if (i == 1) {
                delay += 0.7;
            }
        }
    }
}

-(NSMutableArray<Card>*)allCards
{
    NSMutableArray<Card> *cards = (NSMutableArray<Card>*)[NSMutableArray new];
    [cards addObjectsFromArray:self.currentPlayerCards];
    [cards addObjectsFromArray:self.currentBankerCards];
    return cards;
}

-(void)showCard:(Card*)card completion:(void (^)())completion
{
    [card flipAfter:0 completion:^{
        completion();
    }];
}

-(void)resetCompletion:(void (^)())completion
{
//    playerCardsStartPos = CGPointMake(40, scene.size.height - 50);
//    bankerCardsStartPos = CGPointMake(scene.size.width / 2 + 54, scene.size.height - 50);
    cardsPos = [NSMutableArray arrayWithObjects:[NSValue valueWithCGPoint:playerCardsStartPos], [NSValue valueWithCGPoint:bankerCardsStartPos], nil];
    self.turn = 0;
    zPos = 10;
    
    
    
    CGFloat delay = 0.72;
    NSMutableArray<Card> *cards = [self allCards];
    for (Card *card in cards)
    {
        delay -= 0.12;
        if (card == [cards lastObject]) {
            [card disposeTo:cardEndPos delay:delay completion:^{
                
                [self.currentPlayerCards removeAllObjects];
                [self.currentBankerCards removeAllObjects];
                completion();
            }];
        }
        else
        {
            [card disposeTo:cardEndPos delay:delay completion:nil];
        }
    }
    
}


-(void)dealHand
{
//    scene.lblScore.text = @"";
//    scene.myLabel.text = @"dealing...";
    if (self.currentPlayerCards.count > 0)
    {
        [self resetCompletion:^{
            [self nextHand];
        }];
    }
    else
    {
        [self nextHand];
    }
}

-(void)nextHand
{
    for (int i = 0; i < 4; i++)
    {
        CGFloat delay = (self.currentPlayerCards.count + self.currentBankerCards.count) * 0.2;
        
        if (i < 3)
        {
            [self dealCardAfter:delay completion:nil];
        }
        else
        {
            [self dealCardAfter:delay completion:^{
                //show cards to player
                [self showAll:^{
                    [self dealPlayerThirdCard];
                }];
            }];
        }
    }
}

-(void)dealPlayerThirdCard
{
    if (self.turn == 0 && [self playerNeedsAnotherCard])
    {
        Card *tempCard = (Card*)self.currentPlayerCards[1];
        
        CGPoint point = [cardsPos[self.turn] CGPointValue];
        point.x = point.x - tempCard.size.width - 5;
        [cardsPos replaceObjectAtIndex:self.turn withObject:[NSValue valueWithCGPoint: point]];
        
        [tempCard makeSpaceForThridCard:point];
        
        [self dealCardAfter:1 completion:^{
            [self showCard:self.currentPlayerCards[2] completion:^{
                [self dealBankerThirdCard];
            }];
        }];
    }
    else
    {
        self.turn = 1;
        [self dealBankerThirdCard];
    }
    
}

-(void)dealBankerThirdCard
{
    if (self.turn == 1 && [self bankerNeedsAnotherCard])
    {
        Card* tempCard = (Card*)self.currentBankerCards[1];
        
        CGPoint point = [cardsPos[self.turn] CGPointValue];
        point.x = point.x - tempCard.size.width - 5;
        [cardsPos replaceObjectAtIndex:self.turn withObject:[NSValue valueWithCGPoint: point]];
        
        [tempCard makeSpaceForThridCard: point];
        
        [self dealCardAfter:1 completion:^{
            [self showCard:self.currentBankerCards[2] completion:^{
                //winner is decided
                [self declareWinner];
            }];
        }];
    }
    else
    {
        ///winner is decided
        [self declareWinner];
    }
}

-(void)declareWinner
{
    Hand *hand = [self.hands lastObject];
    [hand.playerCards addObjectsFromArray:self.currentPlayerCards];
    [hand.bankerCards addObjectsFromArray:self.currentBankerCards];
    hand.winner = [self winner];
    //fix it when sid gives commision chart
    if (hand.bettedOn == hand.winner)
    {
        hand.returnAmount = hand.betAmount;
    }
    else
    {
        hand.returnAmount = 0;
    }
    
//    [self.hands replaceObjectAtIndex:self.hands.count-1 withObject:hand];
}

-(void)dealCardAfter:(CGFloat)delay completion:(void (^)())completion
{
    Card *card = [shoe drawCard:0];
    if (shoe.cards.count == 0)
    {
        shoe = [shoe initWithDecks:4];
    }
    
    card.position = cardStartPos;
    card.zPosition = zPos++;

    
    if (self.turn == 0)
    {
        //player
        [self.currentPlayerCards addObject:card];
        
        CGPoint point = [cardsPos[self.turn] CGPointValue];
        point.x = point.x + card.size.width + 5;
        [cardsPos replaceObjectAtIndex:self.turn withObject:[NSValue valueWithCGPoint: point]];
        
        self.turn = 1;
    }
    else
    {
        //banker
        [self.currentBankerCards addObject:card];
        
        CGPoint point = [cardsPos[self.turn] CGPointValue];
        point.x = point.x + card.size.width + 5;
        [cardsPos replaceObjectAtIndex:self.turn withObject:[NSValue valueWithCGPoint: point]];
        
        self.turn = 0;
    }
    
//    SKAction* action0 = [SKAction waitForDuration:delay];
//    SKAction* action1 = [SKAction moveTo:[cardsPos[self.turn] CGPointValue] duration:0.2];
    
//    SKAction* action = [SKAction sequence:@[action0, action1]];
//    [card runAction:action completion:^{
        if (completion)
        {
            completion();
        }
//    }];
    
//    [scene addChild:card];
}


@end
