//
//  main.m
//  Baccarat
//
//  Created by Chicago Team on 12/29/14.
//  Copyright (c) 2014 AutoBetic. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "AppDelegate.h"
#import "AppDelegateTest.h"

int main(int argc, char * argv[]) {
    @autoreleasepool {
        if (NSClassFromString(@"XCTest") != nil) {
            return UIApplicationMain(argc, argv, nil, NSStringFromClass([AppDelegateTest class]));
        } else {
            return UIApplicationMain(argc, argv, nil, NSStringFromClass([AppDelegate class]));
        }
    }
}
