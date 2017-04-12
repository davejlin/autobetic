//
//  DealerTests.m
//  Baccarat
//
//  Created by Chicago Team on 12/30/14.
//  Copyright (c) 2014 AutoBetic. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <XCTest/XCTest.h>
#import "Dealer.h"
#import "Constants.h"

@interface DealerTests : XCTestCase

@end

Dealer *dealer;

@implementation DealerTests

- (void)setUp {
    [super setUp];
    dealer = [[Dealer alloc] init];
    // Put setup code here. This method is called before the invocation of each test method in the class.
}

- (void)tearDown {
    // Put teardown code here. This method is called after the invocation of each test method in the class.
    [super tearDown];
}

- (void)testCreateShoeOfCards_NumberOfCardsInShoe {

    NSMutableArray *shoe = [dealer createShoeOfCards:1];
    XCTAssertEqual([shoe count], 52);
    
    shoe = [dealer createShoeOfCards:8];
    XCTAssertEqual([shoe count], 8*52);
}

- (void)testCreateShoeOfCards_AllCardsPresent {
    
    NSMutableArray *shoe = [dealer createShoeOfCards:1];
    Card *aCard = [shoe objectAtIndex:0];
    bool result = (aCard.value == Ace && aCard.suite == Hearts);
    XCTAssertTrue(result);
    
    aCard = [shoe objectAtIndex:14];
    result = (aCard.value == Two && aCard.suite == Diamonds);
    XCTAssertTrue(result);
    
    aCard = [shoe objectAtIndex:28];
    result = (aCard.value == Three && aCard.suite == Spades);
    XCTAssertTrue(result);
    
    aCard = [shoe objectAtIndex:51];
    result = (aCard.value == King && aCard.suite == Clubs);
    XCTAssertTrue(result);
    
    [self checkAllValuesPresent:shoe];
    [self checkAllSuitesPresent:shoe];
}

- (void)testShuffleShoeOfCards {
    NSMutableArray *shoe = [dealer createShoeOfCards:1];
    shoe = [dealer shuffleShoeOfCards:shoe];
    
    Card *card0 = [shoe objectAtIndex:0];
    Card *card1 = [shoe objectAtIndex:1];
    Card *card2 = [shoe objectAtIndex:2];
    Card *card3 = [shoe objectAtIndex:3];
    
    bool result0 = (card0.value == Ace && card0.suite == Hearts);
    bool result1 = (card1.value == Two && card1.suite == Hearts);
    bool result2 = (card2.value == Three && card2.suite == Hearts);
    bool result3 = (card3.value == Four && card3.suite == Hearts);
    
    // after shuffle, it is unlikely the first 4 cards will all remain in place
    bool result = (result0 && result1 && result2 && result3);
    XCTAssertFalse(result);
    
    card0 = [shoe objectAtIndex:48];
    card1 = [shoe objectAtIndex:49];
    card2 = [shoe objectAtIndex:50];
    card3 = [shoe objectAtIndex:51];
    
    result0 = (card0.value == Ten && card0.suite == Clubs);
    result1 = (card1.value == Jack && card1.suite == Clubs);
    result2 = (card2.value == Queen && card2.suite == Clubs);
    result3 = (card3.value == King && card3.suite == Clubs);
    
    // after shuffle, it is unlikely the last 4 cards will all remain in place
    result = (result0 && result1 && result2 && result3);
    XCTAssertFalse(result);
    
    // check all values and suites present
    [self checkAllValuesPresent:shoe];
    [self checkAllSuitesPresent:shoe];
    
    /*
    for (Card *aCard in shoe) {
        NSLog(@"%i %i",aCard.value,aCard.suite);
    }
    */
}

- (void)testBurnCards {
    
    for (int i=0; i<50; i++) {
        NSMutableArray *shoe = [dealer createShoeOfCards:1];
        shoe = [dealer shuffleShoeOfCards:shoe];
        
        int firstCardValue = ((Card *)shoe[0]).value;
        firstCardValue = (firstCardValue < 11) ? firstCardValue : 10;
        
        int nCardsAfterBurnExpected = (int)[shoe count] - firstCardValue - 1; // -1 for first card
        
        shoe = [dealer burnShoeOfCards:shoe];
        
        XCTAssertEqual([shoe count], nCardsAfterBurnExpected);
    }
}

- (void)checkAllValuesPresent:(NSMutableArray *)shoe {
    int n = [self countNumberOfValue:Ace inShoe:shoe];
    XCTAssertEqual(n,4);
    
    n = [self countNumberOfValue:Two inShoe:shoe];
    XCTAssertEqual(n,4);
    
    n = [self countNumberOfValue:Three inShoe:shoe];
    XCTAssertEqual(n,4);
    
    n = [self countNumberOfValue:Four inShoe:shoe];
    XCTAssertEqual(n,4);
    
    n = [self countNumberOfValue:Five inShoe:shoe];
    XCTAssertEqual(n,4);
    
    n = [self countNumberOfValue:Six inShoe:shoe];
    XCTAssertEqual(n,4);
    
    n = [self countNumberOfValue:Seven inShoe:shoe];
    XCTAssertEqual(n,4);
    
    n = [self countNumberOfValue:Eight inShoe:shoe];
    XCTAssertEqual(n,4);
    
    n = [self countNumberOfValue:Nine inShoe:shoe];
    XCTAssertEqual(n,4);
    
    n = [self countNumberOfValue:Ten inShoe:shoe];
    XCTAssertEqual(n,4);
    
    n = [self countNumberOfValue:Jack inShoe:shoe];
    XCTAssertEqual(n,4);
    
    n = [self countNumberOfValue:Queen inShoe:shoe];
    XCTAssertEqual(n,4);
    
    n = [self countNumberOfValue:King inShoe:shoe];
    XCTAssertEqual(n,4);
}

- (void)checkAllSuitesPresent:(NSMutableArray *)shoe {
    int n = [self countNumberOfSuites:Hearts inShoe:shoe];
    XCTAssertEqual(n,13);
    
    n = [self countNumberOfSuites:Diamonds inShoe:shoe];
    XCTAssertEqual(n,13);
    
    n = [self countNumberOfSuites:Spades inShoe:shoe];
    XCTAssertEqual(n,13);
    
    n = [self countNumberOfSuites:Clubs inShoe:shoe];
    XCTAssertEqual(n,13);
}

- (int)countNumberOfValue:(CardValue)value inShoe:(NSMutableArray *)shoe {
    int count = 0;
    for (Card *aCard in shoe) {
        if (aCard.value == value)
            count++;
    }
    return count;
}

- (int)countNumberOfSuites:(CardSuite)suite inShoe:(NSMutableArray *)shoe {
    int count = 0;
    for (Card *aCard in shoe) {
        if (aCard.suite == suite)
            count++;
    }
    return count;
}

- (void)testPerformanceExample {
    // This is an example of a performance test case.
    [self measureBlock:^{
        // Put the code you want to measure the time of here.
    }];
}

@end
