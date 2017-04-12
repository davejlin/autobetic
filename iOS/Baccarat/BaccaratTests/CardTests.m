//
//  Card.m
//  Baccarat
//
//  Created by Chicago Team on 1/1/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <XCTest/XCTest.h>
#import "Constants.h"

@interface CardTests : XCTestCase

@end

@implementation CardTests

- (void)setUp {
    [super setUp];
    // Put setup code here. This method is called before the invocation of each test method in the class.
}

- (void)tearDown {
    // Put teardown code here. This method is called after the invocation of each test method in the class.
    [super tearDown];
}

-(void)testCardsHaveCorrectValues {
    XCTAssertEqual(0, Zero);
    XCTAssertEqual(1, Ace);
    XCTAssertEqual(2, Two);
    XCTAssertEqual(3, Three);
    XCTAssertEqual(4, Four);
    XCTAssertEqual(5, Five);
    XCTAssertEqual(6, Six);
    XCTAssertEqual(7, Seven);
    XCTAssertEqual(8, Eight);
    XCTAssertEqual(9, Nine);
    XCTAssertEqual(10, Ten);
    XCTAssertEqual(11, Jack);
    XCTAssertEqual(12, Queen);
    XCTAssertEqual(13, King);
}

@end
