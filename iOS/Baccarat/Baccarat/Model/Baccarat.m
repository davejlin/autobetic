//
//  Baccarat.m
//  Baccarat
//
//  Created by Chicago Team on 1/1/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "Baccarat.h"

@implementation Baccarat

-(id)init {
    self = [super init];
    if (self != nil) {
    }
    return self;
}

- (ShoeResults *)getShoeResults:(NSMutableArray *)shoe cutCardPosition:(int)nCut {
    ShoeResults *results = [[ShoeResults alloc] init];
    
    int nCutCardPosition = (int)[shoe count]-1-nCut;
    int nCard = 0;
    bool oneMoreCoup = NO;
    
    while (nCard < (int)[shoe count]-6) {
        
        Coup *coup = [[Coup alloc] init];
        
        Card *P1 = shoe[nCard++];
        Card *B1 = shoe[nCard++];
        Card *P2 = shoe[nCard++];
        Card *B2 = shoe[nCard++];
        
        coup.p1 = P1;
        coup.b1 = B1;
        coup.p2 = P2;
        coup.b2 = B2;
        
        int vP1 = [self checkValue:P1.value];
        int vB1 = [self checkValue:B1.value];
        int vP2 = [self checkValue:P2.value];
        int vB2 = [self checkValue:B2.value];
        int vP3 = 0;
        int vB3 = 0;
        
        int totP = (vP1 + vP2) % 10;
        int totB = (vB1 + vB2) % 10;
        
        if (totP >=8 || totB >=8) { // either side 8 or 9
            
            if (totP == totB)       coup.coupResult = Tie;
            else if (totP > totB)   coup.coupResult = Player;
            else                    coup.coupResult = Banker;
                
        } else { // neither side 8 or 9
            if (totP <= 5) {
                Card *P3 = shoe[nCard++];
                coup.p3 = P3;
                vP3 = [self checkValue:P3.value];
                
                
                if (vP3 <= 1 || vP3 == 9) { // P = 0, 1 or 9
                    if (totB <= 3) {
                        Card *B3 = shoe[nCard++];
                        coup.b3 = B3;
                        vB3 = [self checkValue:B3.value];
                    }
                } else if (vP3 <= 3) { // P = 2 or 3
                    if (totB <= 4) {
                        Card *B3 = shoe[nCard++];
                        coup.b3 = B3;
                        vB3 = [self checkValue:B3.value];
                    }
                } else if (vP3 <= 5) { // P = 4 or 5
                    if (totB <= 5) {
                        Card *B3 = shoe[nCard++];
                        coup.b3 = B3;
                        vB3 = [self checkValue:B3.value];
                    }
                } else if (vP3 <= 7) { // P = 6 or 7
                    if (totB <= 6) {
                        Card *B3 = shoe[nCard++];
                        coup.b3 = B3;
                        vB3 = [self checkValue:B3.value];
                    }
                } else { // P = 8
                    if (totB <= 2) {
                        Card *B3 = shoe[nCard++];
                        coup.b3 = B3;
                        vB3 = [self checkValue:B3.value];
                    }
                }
                
                
            } else { // player stood
                if (totB <= 5) {
                    Card *B3 = shoe[nCard++];
                    coup.b3 = B3;
                    vB3 = [self checkValue:B3.value];
                }
            }
            
            totP = (totP + vP3) % 10;
            totB = (totB + vB3) % 10;
            
            if (totP == totB)       coup.coupResult = Tie;
            else if (totP > totB)   coup.coupResult = Player;
            else                    coup.coupResult = Banker;
            
/* Check cutCard
The cut card will be placed 16 cards from the bottom of the shoe.
When the cut card appears, the dealer will finish that hand, play one more hand, and then start a new shoe.
If the cut card comes out instead of the first card, the dealer will finish that hand, and then start a new shoe.
*/
            
            if (oneMoreCoup)
                break;
            
            if (nCard >= nCutCardPosition)
                oneMoreCoup = YES;
            
        }
        [results addACoupToShoe:coup];
    }
    
    return results;
}

-(int)checkValue:(int)value {
    return (value < 10) ? value : 0;
}

@end
