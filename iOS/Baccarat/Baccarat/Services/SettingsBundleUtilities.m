//
//  SettingsBundleUtilities.m
//  Baccarat
//
//  Created by Chicago Team on 3/1/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "SettingsBundleUtilities.h"

@implementation SettingsBundleUtilities

+ (void)registerDefaultsFromSettingsBundle {
    // this function writes default settings as settings
    NSString *settingsBundle = [[NSBundle mainBundle] pathForResource:@"Settings" ofType:@"bundle"];
    if(!settingsBundle) {
        NSLog(@"Could not find Settings.bundle");
        return;
    }
    
    NSDictionary *settings = [NSDictionary dictionaryWithContentsOfFile:[settingsBundle stringByAppendingPathComponent:@"Root.plist"]];
    NSArray *preferences = [settings objectForKey:@"PreferenceSpecifiers"];
    
    NSMutableDictionary *defaultsToRegister = [[NSMutableDictionary alloc] initWithCapacity:[preferences count]];
    for(NSDictionary *prefSpecification in preferences) {
        NSString *key = [prefSpecification objectForKey:@"Key"];
        if(key) {
            [defaultsToRegister setObject:[prefSpecification objectForKey:@"DefaultValue"] forKey:key];
            //NSLog(@"writing as default %@ to the key %@",[prefSpecification objectForKey:@"DefaultValue"],key);
        }
    }
    
    [[NSUserDefaults standardUserDefaults] registerDefaults:defaultsToRegister];
    
}

+ (void)resetSettingsToDefaults {
    NSUserDefaults *standardUserDefaults = [NSUserDefaults standardUserDefaults];
    
    //Determine the path to our Settings.bundle.
    NSString *bundlePath = [[NSBundle mainBundle] bundlePath];
    NSString *settingsBundlePath = [bundlePath stringByAppendingPathComponent:@"Settings.bundle"];
    
    // Load paths to all .plist files from our Settings.bundle into an array.
    NSArray *allPlistFiles = [NSBundle pathsForResourcesOfType:@"plist" inDirectory:settingsBundlePath];
    
    // Copy the default values loaded from each plist
    // into the system's sharedUserDefaults database.
    NSString *plistFile;
    for (plistFile in allPlistFiles)
    {
        // Load our plist files to get our preferences.
        NSDictionary *settingsDictionary = [NSDictionary dictionaryWithContentsOfFile:plistFile];
        NSArray *preferencesArray = [settingsDictionary objectForKey:@"PreferenceSpecifiers"];
        
        // Iterate through the specifiers, and copy the default
        // values into the DB.
        NSDictionary *item;
        for(item in preferencesArray)
        {
            // Obtain the specifier's key value.
            NSString *keyValue = [item objectForKey:@"Key"];
            
            // Using the key, return the DefaultValue if specified in the plist.
            // Note: We won't know the object type until after loading it.
            id defaultValue = [item objectForKey:@"DefaultValue"];
            
            // Some of the items, like groups, will not have a Key, let alone
            // a default value.  We want to safely ignore these.
            if (keyValue && defaultValue)
            {
                [standardUserDefaults setObject:defaultValue forKey:keyValue];
            }
        }
    }
    
    [standardUserDefaults synchronize];
}

@end
