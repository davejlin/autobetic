//
//  TestUtilities.m
//  Baccarat
//
//  Created by Lin David, US-205 on 4/29/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "TestUtilities.h"

@implementation TestUtilities

+ (NSMutableArray *)getTestResultsData:(NSArray *)shoesData {
    
    /*
     In Wizard of Odds Shoes Data file:
     Field 1:  Winning outcome (P = Player win, B = Banker win, T = Tie win)
     Field 2:  Point value of banker hand
     Field 3:  Point value of player hand
     Field 4:  Point value of banker's first card
     Field 5:  Point value of banker's second card
     Field 6:  Point value of banker's third card if taken, x otherwise
     Field 7:  Point value of player's first card
     Field 8:  Point value of player's second card
     Field 9:  Point value of player's third card if taken, x otherwise
     */
    
    // array of all shoes' results in test data set:
    NSMutableArray *resultsData = [[NSMutableArray alloc] init];
    // array of one shoe's results in test data set:
    NSMutableArray *aShoeResultsData = [[NSMutableArray alloc] init];
    
    for (NSString *strsInOneLine in shoesData) {
        
        NSArray* singleStrs = [strsInOneLine componentsSeparatedByCharactersInSet:[NSCharacterSet characterSetWithCharactersInString:@","]];
        
        if ([singleStrs[0] isEqualToString:@""]) { // Shoe break
            [resultsData addObject:aShoeResultsData];
            aShoeResultsData = [[NSMutableArray alloc] init];
            continue;
        }
        
        [aShoeResultsData addObject:[self createACardWithValue:(int)[singleStrs[6] integerValue]]];
        [aShoeResultsData addObject:[self createACardWithValue:(int)[singleStrs[3] integerValue]]];
        [aShoeResultsData addObject:[self createACardWithValue:(int)[singleStrs[7] integerValue]]];
        [aShoeResultsData addObject:[self createACardWithValue:(int)[singleStrs[4] integerValue]]];
        
        if (![singleStrs[8] isEqualToString:@"x"])
            [aShoeResultsData addObject:[self createACardWithValue:(int)[singleStrs[8] integerValue]]];
        
        if (![singleStrs[5] isEqualToString:@"x"])
            [aShoeResultsData addObject:[self createACardWithValue:(int)[singleStrs[5] integerValue]]];
        
    }
    
    return resultsData;
}


+ (SessionResults *)getTestSessionsData:(NSArray *)shoesData {
    
    // array of all shoes' outcomes in test data set:
    SessionResults *sessionData = [[SessionResults alloc] init];
    // array of one shoe's outcomes in test data set:
    ShoeResults *aShoeOutcomeData = [[ShoeResults alloc] init];
    
    for (NSString *strsInOneLine in shoesData) {
        
        NSArray* singleStrs = [strsInOneLine componentsSeparatedByCharactersInSet:[NSCharacterSet characterSetWithCharactersInString:@","]];
        
        if ([singleStrs[0] isEqualToString:@""]) { // Shoe break
            [sessionData addAShoeToSession:aShoeOutcomeData];
            aShoeOutcomeData = [[ShoeResults alloc] init];
            continue;
        }
        
        Coup *aCoup = [[Coup alloc] init];
        aCoup.coupResult = [self getCoupResult:singleStrs[0]];
        [aShoeOutcomeData addACoupToShoe:aCoup];
    }
    
    return sessionData;
}

+ (NSArray *)readTestShoeData {
    
    //NSBundle *bundle = [NSBundle mainBundle];
    NSBundle *bundle = [NSBundle bundleForClass:[self class]];
    NSString *filePath = @"10x8DeckShoesData"; // 10 Wizard of Odds shoe data
    NSString *fileRoot = [bundle pathForResource:filePath ofType:@"txt"];
    
    // read everything from text
    NSString* fileContents = [NSString stringWithContentsOfFile:fileRoot encoding:NSUTF8StringEncoding error:nil];
    
    // first, separate by new line
    NSArray* allLinedStrings =[fileContents componentsSeparatedByCharactersInSet:[NSCharacterSet newlineCharacterSet]];
    
    /*
     int count=0;
     
     // then break down even further
     // NSString* strsInOneLine = [allLinedStrings objectAtIndex:0];
     for (NSString *strsInOneLine in allLinedStrings) {
     
     // choose whatever input identity you have decided. in this case ,
     NSArray* singleStrs = [strsInOneLine componentsSeparatedByCharactersInSet:[NSCharacterSet characterSetWithCharactersInString:@","]];
     
     NSLog (@"%i %@",count++, singleStrs[0]);
     }
     */
    
    return allLinedStrings;
}

+ (CoupResult) getCoupResult:(NSString*) resultString {
    if ([resultString isEqualToString:@"B"]) {
        return Banker;
    } else if ([resultString isEqualToString:@"P"]) {
        return Player;
    } else if ([resultString isEqualToString:@"T"]) {
        return Tie;
    } else return Unknown;
}

+ (Card *)createACardWithValue:(int)aValue {
    return [[Card alloc] initWithName:aValue withSuite:Diamonds];
}
@end
