//
//  SessionTests.m
//  Baccarat
//
//  Created by Lin David, US-205 on 4/29/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <XCTest/XCTest.h>
#import "TestUtilities.h"

@interface SessionTests : XCTestCase

@end

@implementation SessionTests

Baccarat *aBaccarat;
NSMutableArray *testResultsData;
SessionResults *testDecisionsData;

+ (void)setUp { // invoked only once for all tests
    [XCTestCase setUp];
    
    NSArray *testShoesData = [TestUtilities readTestShoeData];
    testResultsData = [TestUtilities getTestResultsData:testShoesData];  // array of 10 Wizard of Odds shoes' card results
    testDecisionsData = [TestUtilities getTestSessionsData:testShoesData]; // array of 10 Wizard of Odds shoes' baccarat coup decision outcomes
}

- (void)setUp {
    [super setUp];
    // Put setup code here. This method is called before the invocation of each test method in the class.
}

- (void)tearDown {
    // Put teardown code here. This method is called after the invocation of each test method in the class.
    [super tearDown];
}

- (void)testWizardOfOddsDataBankerOnlyStrategy {
    SessionStatistics *sessionStatistics = [[SessionStatistics alloc] init];
    
    [Strategy executeStrategy:[Utilities getBetPlacement]
             withBetFrequency:[Utilities getBetFrequency]
           withBetProgression:[Utilities getBetProgression]
                  withBaseBet:1.0
                  withBankroll:1.0
                  withResults:testDecisionsData
                    withStats:sessionStatistics];
    [sessionStatistics calcTotals];
    
    XCTAssertEqual(sessionStatistics.nWinB, 405);
    XCTAssertEqual(sessionStatistics.nWinP,   0);
    XCTAssertEqual(sessionStatistics.nWinT,   0);
    XCTAssertEqual(sessionStatistics.nWinTotal, 405);
    XCTAssertLessThan(sessionStatistics.nWinUnits, 384.75);
    XCTAssertGreaterThan(sessionStatistics.nWinUnits, 384.74);
    
    XCTAssertEqual(sessionStatistics.nLossB, 345);
    XCTAssertEqual(sessionStatistics.nLossP,   0);
    XCTAssertEqual(sessionStatistics.nLossT,   0);
    XCTAssertEqual(sessionStatistics.nLossTotal, 345);
    XCTAssertEqual(sessionStatistics.nLossUnits, 345.00);
    
    XCTAssertEqual(sessionStatistics.nNetB, 60);
    XCTAssertEqual(sessionStatistics.nNetP,  0);
    XCTAssertEqual(sessionStatistics.nNetT,  0);
    XCTAssertEqual(sessionStatistics.nNetTotal, 60);
    XCTAssertLessThan(sessionStatistics.nNetUnits, 39.75);
    XCTAssertGreaterThan(sessionStatistics.nNetUnits, 39.74);
}


- (void)testPerformanceExample {
    // This is an example of a performance test case.
    [self measureBlock:^{
        // Put the code you want to measure the time of here.
    }];
}

@end
