//
//  SettingsBundleUtilities.h
//  Baccarat
//
//  Created by Chicago Team on 3/1/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface SettingsBundleUtilities : NSObject
+ (void)registerDefaultsFromSettingsBundle;
+ (void)resetSettingsToDefaults;
@end
