//
//  BaccaratTests.m
//  BaccaratTests
//
//  Created by Chicago Team on 12/29/14.
//  Copyright (c) 2014 AutoBetic. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <XCTest/XCTest.h>
#import "TestUtilities.h"

@interface BaccaratTests : XCTestCase
@end

@implementation BaccaratTests

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
    aBaccarat = [[Baccarat alloc] init];
    // Put setup code here. This method is called before the invocation of each test method in the class.
}

- (void)tearDown {
    // Put teardown code here. This method is called after the invocation of each test method in the class.
    [super tearDown];
}

- (void)test10AndFaceCardsReducedToZero {
    NSMutableArray *testData = [[NSMutableArray alloc] init];
    
    Card *aCard = [TestUtilities createACardWithValue:Nine];
    [testData addObject:aCard];
    
    aCard = [TestUtilities createACardWithValue:Jack];
    [testData addObject:aCard];
    
    aCard = [TestUtilities createACardWithValue:Queen];
    [testData addObject:aCard];
    
    aCard = [TestUtilities createACardWithValue:King];
    [testData addObject:aCard];
    
    aCard = [TestUtilities createACardWithValue:Ten];
    [testData addObject:aCard];
    
    aCard = [TestUtilities createACardWithValue:Eight];
    [testData addObject:aCard];
    
    aCard = [TestUtilities createACardWithValue:Seven];
    [testData addObject:aCard];
    
    aCard = [TestUtilities createACardWithValue:Jack];
    [testData addObject:aCard];
    
    aCard = [TestUtilities createACardWithValue:Ten];
    [testData addObject:aCard];
    
    aCard = [TestUtilities createACardWithValue:Eight];
    [testData addObject:aCard];
    
    aCard = [TestUtilities createACardWithValue:Eight];
    [testData addObject:aCard];
    
    aCard = [TestUtilities createACardWithValue:Jack];
    [testData addObject:aCard];
    
    // buffer cards below:
    aCard = [TestUtilities createACardWithValue:Ten];
    [testData addObject:aCard];

    aCard = [TestUtilities createACardWithValue:Ten];
    [testData addObject:aCard];
    
    aCard = [TestUtilities createACardWithValue:Ten];
    [testData addObject:aCard];
    
    aCard = [TestUtilities createACardWithValue:Ten];
    [testData addObject:aCard];
    
    aCard = [TestUtilities createACardWithValue:Ten];
    [testData addObject:aCard];
    
    aCard = [TestUtilities createACardWithValue:Ten];
    [testData addObject:aCard];
    
    ShoeResults *shoeResults = [aBaccarat getShoeResults:testData cutCardPosition:0];
    
    XCTAssertEqual([shoeResults.shoe[0] coupResult],Player);
    XCTAssertEqual([shoeResults.shoe[1] coupResult],Banker);
    XCTAssertEqual([shoeResults.shoe[2] coupResult],Tie);
}

- (void)testBaccDrawingRules {
    
    int index = 0;
    
    for (NSMutableArray *aShoeResultsData in testResultsData ) {
        
        ShoeResults *aShoeOutcomeCalculated = [aBaccarat getShoeResults:aShoeResultsData cutCardPosition:0];
        ShoeResults *aShoeOutcomeTestData = testDecisionsData.session[index++];
        
        for (int i=0; i<[aShoeOutcomeCalculated.shoe count]; i++) {
            Coup *coupCalculated = aShoeOutcomeCalculated.shoe[i];
            Coup *coupData = aShoeOutcomeTestData.shoe[i];
            XCTAssertTrue([coupCalculated coupResult] == [coupData coupResult]);
        }
    }
}

- (void)testCutCard {
    // when cut card is used (cutCardPosition = 16 from end):
    // expect the number of calculated outcomes to be less than what is in the test data outcomes
    // (except for test shoes 2, 4, 5, 9, which happen to be the same for this cutCardPosition):
    
    int index = 0;
    
    for (NSMutableArray *aShoeResultsData in testResultsData ) {
        
        ShoeResults *aShoeOutcomeCalculated = [aBaccarat getShoeResults:aShoeResultsData cutCardPosition:16];
        ShoeResults *aShoeOutcomeTestData = testDecisionsData.session[index++];
        
        if (index == 2 || index == 4 || index == 5 || index == 9)
            continue;
        
        XCTAssertLessThan([aShoeOutcomeCalculated.shoe count], [aShoeOutcomeTestData.shoe count]);
    }
}

- (void)testPerformanceExample {
    // This is an example of a performance test case.
    [self measureBlock:^{
        // Put the code you want to measure the time of here.
    }];
}

@end
