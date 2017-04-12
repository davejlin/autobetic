//
//  VC_Help.m
//  Baccarat
//
//  Created by Chicago Team on 1/10/15.
//  Copyright (c) 2015 AutoBetic. All rights reserved.
//

#import "VC_Help.h"

@implementation VC_Help
- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view, typically from a nib.
    self.textView.editable = NO;
    [self loadTextViewContent];
    _scrollView.indicatorStyle = UIScrollViewIndicatorStyleWhite;
}

- (void)dealloc {
    //NSLog(@"*** HELP DEALLOC ***");
}

- (void)loadTextViewContent {
    self.textView.text = @" Baccarat Simulator\n\n The Autobetic baccarat simulator is a powerful way to play hundreds or even thousands of baccarat games in seconds, allowing you to quickly test your favorite bet placement and progression strategies, as well as money management methods.\n\n Unlike static probability tables which are calculated using mathematical equations, our simulator engine actually uses realistic shoe creation, randomizing shuffles, and deals the cards according to the standard baccaract drawing rules, just like a live dealer would in an actual casino.  The result is accurate game statistics which are generated completely live.\n\n The Simulator\n\n Designed for beginners, the Autobetic baccarat simulation mode walks you through selecting key simulation parameters.  Simply enter your desired values through a couple short pages of setup, and you're ready to go!\n\n Step 1: Bankroll & Table Settings\n\n Enter your gambling bankroll:\n\n Your gambling bankroll is the total number of units you have to bet for a session.  For instance, if you have total of $1000 with which to play a session, and your smallest bet per decision is $10, then enter 100 for your bankroll, since your bankroll consists of 100 units ($1000 divided by $10 is 100).\n\n Enter your base unit bet:\n\n The base bet is the smallest bet you will make in a decision in terms of units.  For example, if your base bet is $10, and you want to use that as your base unit bet, enter 1.\n\n Enter your maximum unit bet:\n\n The maximum unit bet is the most you want to bet in a single decision in terms of units.  For example, if your base bet is $10 and the most you want to bet in a single decision is $100, then enter 10, since $100 dvided by $10 is 10, and 10 units is your maximum bet amount.\n\n Enter the house table limits:\n\n The house table limits are the smallest and largest amounts which the casino requires you to bet per decision.  For example, if the smallest bet the house requires you to bet per decision is $10 and the largest is $5000, then enter 1 for MIN LIMIT BET and 500 for MAX LIMIT BET.  This ratio of minimum to maximum bet (in our example, 1:500) is also known as the table betting spread.\n\n Step 2: Bet Strategy Settings\n\n Select what to bet on:\n\n Select your bet placement:  Banker, Player, or Tie.\n\nChoose when to bet:\n\n Select your bet frequency: Always or Custom Trigger.\n\n Betting Always will place a bet for every decision.\n\n Alternatively, betting on a Custom Trigger makes a bet only after the specified trigger occurs.  For example, if you want to bet after the sequence Player, Player, and Banker occurs, then enter PPB as the Custom Trigger.  Use P for Player, B for Banker, and T for Tie.  Any character entered other than P, B, and T is ignored.  Capitalization is ignored, so you can also enter p, b, and t, if desired.\n\n Choose your bet progression:\n\n Select your desired bet progression: Always base bet, Double on loss, or Custom Progression.\n\n Always base bet: Every bet will be the base unit bet which you had specified.\n\n Double on loss: Starting with the base unit bet, double the bet amount if you lose a decision, or return to the base bet amount if you lose a decision.  So, in a long losing streak, the betting progression will be 1, 2, 4, 8, 16, 32 units ... alll the way up to the maximum bet or maximum table limit.  This bet progression is commonly known as the Martingale progression.\n\n Custom Progression: Enter your desired betting progression.  For example, enter 1.2.3.5.8.13.21 if you want to start with a 1 unit bet, then 2 units upon a loss, 3 units on another loss, etc., until you bet 21 units, after which keep betting 21 units.  On any win, return to the first bet amount in the sequence, in the above example, 1 unit.  Separate the amount of each unit bet amount at a progression level with a period (.).\n\n After entering your desired  settings, press Run Autobet Sim to start the simulation.\n\n Other Settings:\n\n You can conveniently access all the simulator settings on the Settings page by clicking on the wheel-shaped icon on the bottom menu bar.  Two other settings in addition to those described above can be specified on the Settings Page:\n\n Shoes per Session:\n\n This is the number of shoes to run in the simulation.  Note that the greater number of shoes to run in a simulation, the more time the simulation will require to complete.\n\n Decks per Shoe:\n\n This is the number of 52 card decks to use per shoe.  Most casinos use 8 decks per shoe, but some use 6 decks.  You can specifiy however many decks to use in a shoe.\n\n Reset All Default Settings:\n\n Click this toggle to conveniently reset all of the settings to their original, default values.\n\n Your latest settings will be stored, even if you exit or close the app.\n\nSimulation Results:\n\n When the app finishes calculating the results of the simulation, key statistics and graphs are displayed in two tabs.\n\n Stats tab:\n\n The Stats tab view displays the percentage of decisions won and lost, net units gained or lost, and the Player's Advantage, which is the net units won divided by the total units bet, expressed as a percentage.  Clearly, negative values signify net loss, while positive values, net gain.\n\n Graph tab:\n\n On the Graph tab is plotted the Shoe vs Score results, that is, the running total of units won or lost as each shoe progresses.  Touching the graph at any point will show the exact numerical score up to the point of the corresponding shoe simulated.\n\n Re-Run Simulation:\n\n By simply clicking on the refresh icon on the upper right-hand corner of the Results view, you can re-run the simulation again with the current settings but a freshly dealt session of decisions.\n\n To enter different settings, either click back to the setup pages, click on the Settings icon to go to the Settings view, or click on the Home icon to start over at the main menu again. \n\n Game Punto Banco\n\n Have fun playing a realistic game of baccarat.  It's like actually playing a real game at the table.";
}

- (UIStatusBarStyle)preferredStatusBarStyle
{
    return UIStatusBarStyleLightContent;
}

- (IBAction)abcLink:(id)sender {
    [[UIApplication sharedApplication] openURL:[NSURL URLWithString:@"http://www.autobetic.com"]];
}
@end
