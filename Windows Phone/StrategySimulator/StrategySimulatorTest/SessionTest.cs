using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrategySimulator.Model;
using StrategySimulator.Model.BetProgressions;
using StrategySimulator.Model.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategySimulatorTest
{
    [TestClass]
    public class SessionTest
    {
        Session session;
        Shoe shoe;

        [TestInitialize]
        public void init()
        {
            session = new Session();
            StrategySimulator.App.StrategizeSetNumber = 0;
        }

        [TestMethod]
        public void SessionTest_ProgressionIsResetOnNewShoe_Test()
        {
            Setup2ShoesBetPAlwaysMartingale();

            StrategySimulator.App.StrategizeBaccaratViewModel.IsResetProgressionAfterShoe = true;

            shoe = new Shoe(GameBaccaratTest.Prepare1DeckShoe_AllB());
            session.SetShoe(shoe);
            session.PlaySession();

            Assert.AreEqual(2,session.shoeResults.Count);
            Assert.AreEqual(2048, session.shoeResults[0][11].CoupBet.UnitBet);
            Assert.AreEqual(2048, session.shoeResults[1][11].CoupBet.UnitBet);

            Assert.AreEqual(-4095M, Convert.ToDecimal(session.ItemsShoe[0].ScoreTotal));
            Assert.AreEqual(-8190M, Convert.ToDecimal(session.ItemsShoe[1].ScoreTotal));
        }

        [TestMethod]
        public void SessionTest_ProgressionIsNotResetOnNewShoe_Test()
        {
            Setup2ShoesBetPAlwaysMartingale();

            StrategySimulator.App.StrategizeBaccaratViewModel.IsResetProgressionAfterShoe = false;

            shoe = new Shoe(GameBaccaratTest.Prepare1DeckShoe_AllB());
            session.SetShoe(shoe);
            session.PlaySession();

            Assert.AreEqual(2, session.shoeResults.Count);
            Assert.AreEqual(2048, session.shoeResults[0][11].CoupBet.UnitBet);
            Assert.AreEqual(8388608, session.shoeResults[1][11].CoupBet.UnitBet);

            Assert.AreEqual(-4095M, Convert.ToDecimal(session.ItemsShoe[0].ScoreTotal));
            Assert.AreEqual(-16777215, Convert.ToDecimal(session.ItemsShoe[1].ScoreTotal));
        }

        private void Setup2ShoesBetPAlwaysMartingale()
        {
            StrategySimulator.App.GameBaccaratViewModel.NShoesInt = 2;

            StrategySimulator.App.StrategizeBaccaratViewModel.BetPlacementStrategyOptionPickedIndex = (int)StrategiesBaccaratTypes.PlayerAlways;
            StrategySimulator.App.StrategizeBaccaratViewModel.BetProgressionOptionPickedIndex = (int)BetProgressionTypes.Martingale;

            StrategySimulator.App.GameBaccaratViewModel.IsShuffle = false;
            StrategySimulator.App.GameBaccaratViewModel.IsBurn = false;

            StrategySimulator.App.GameBaccaratViewModel.BetMaxUnitInt = 10000000;
        }

        [TestMethod]
        public void SessionTest_NewCardOrderOnNewShoe_Test()
        {
            StrategySimulator.App.GameBaccaratViewModel.NShoesInt = 2;

            StrategySimulator.App.StrategizeBaccaratViewModel.BetPlacementStrategyOptionPickedIndex = (int)StrategiesBaccaratTypes.BankerAlways;
            StrategySimulator.App.StrategizeBaccaratViewModel.BetProgressionOptionPickedIndex = (int)BetProgressionTypes.Martingale;

            StrategySimulator.App.StrategizeBaccaratViewModel.IsResetProgressionAfterShoe = false;
            StrategySimulator.App.GameBaccaratViewModel.IsBurn = true;

            StrategySimulator.App.GameBaccaratViewModel.IsShuffle = true;

            session.PlaySession(); // should be shuffled now

            session.shoeResults.Clear();

            StrategySimulator.App.StrategizeSetNumber = 0; // reset to set 0, because Play cycles through the set numbers and ends on the fourth one
            StrategySimulator.App.GameBaccaratViewModel.IsNewCards = true;
            StrategySimulator.App.GameBaccaratViewModel.IsShuffle = false;

            session.PlaySession(); // should play in new card order with resulting special pattern

            Assert.AreEqual(2, session.shoeResults.Count);

            Assert.AreEqual(43.10M, Convert.ToDecimal(session.ItemsShoe[0].ScoreTotal));
            Assert.AreEqual(87.15M, Convert.ToDecimal(session.ItemsShoe[1].ScoreTotal));

            // play again but reset progression after each shoe:

            session.shoeResults.Clear();

            StrategySimulator.App.StrategizeSetNumber = 0; // reset to set 0, because Play cycles through the set numbers and ends on the fourth one
            StrategySimulator.App.StrategizeBaccaratViewModel.IsResetProgressionAfterShoe = true;

            session.PlaySession(); // should again play in new card order with special pattern

            Assert.AreEqual(2, session.shoeResults.Count);

            Assert.AreEqual(43.10M, Convert.ToDecimal(session.ItemsShoe[0].ScoreTotal));
            Assert.AreEqual(86.20M, Convert.ToDecimal(session.ItemsShoe[1].ScoreTotal));
        }

        [TestMethod]
        public void SessionTest_BurnCardsOnNewShoe_Test()
        {
            StrategySimulator.App.GameBaccaratViewModel.NShoesInt = 2;
            StrategySimulator.App.GameBaccaratViewModel.IsShuffle = false;

            // don't burn 
            StrategySimulator.App.GameBaccaratViewModel.IsBurn = false;

            session.PlaySession();

            Assert.AreEqual("SpadesAce", session.shoeResults[1][0].CardPlayer1.ToString());
            Assert.AreEqual("SpadesThree", session.shoeResults[1][0].CardPlayer2.ToString());
            Assert.AreEqual("SpadesFive", session.shoeResults[1][0].CardPlayer3.ToString());
            Assert.AreEqual("SpadesTwo", session.shoeResults[1][0].CardBanker1.ToString());
            Assert.AreEqual("SpadesFour", session.shoeResults[1][0].CardBanker2.ToString());
            Assert.AreEqual("NoneNone", session.shoeResults[1][0].CardBanker3.ToString());

            // burn 
            session.shoeResults.Clear();

            StrategySimulator.App.GameBaccaratViewModel.IsBurn = true;

            session.PlaySession();

            Assert.AreEqual("SpadesTwo", session.shoeResults[1][0].CardPlayer1.ToString());
            Assert.AreEqual("SpadesFour", session.shoeResults[1][0].CardPlayer2.ToString());
            Assert.AreEqual("NoneNone", session.shoeResults[1][0].CardPlayer3.ToString());
            Assert.AreEqual("SpadesThree", session.shoeResults[1][0].CardBanker1.ToString());
            Assert.AreEqual("SpadesFive", session.shoeResults[1][0].CardBanker2.ToString());
            Assert.AreEqual("NoneNone", session.shoeResults[1][0].CardBanker3.ToString());
        }

        [TestMethod]
        public void SessionTest_FollowBetPlacementIsResetOnNewShoe_Test()
        {
            StrategySimulator.App.GameBaccaratViewModel.NShoesInt = 2;

            StrategySimulator.App.StrategizeBaccaratViewModel.FollowLengthInt = 2;
            StrategySimulator.App.StrategizeBaccaratViewModel.BetPlacementStrategyOptionPickedIndex = (int)StrategiesBaccaratTypes.Follow;

            StrategySimulator.App.StrategizeBaccaratViewModel.BetProgressionOptionPickedIndex = (int)BetProgressionTypes.Martingale;
            StrategySimulator.App.StrategizeBaccaratViewModel.IsResetProgressionAfterShoe = true;

            StrategySimulator.App.GameBaccaratViewModel.IsShuffle = false;
            StrategySimulator.App.GameBaccaratViewModel.IsBurn = false;
            StrategySimulator.App.GameBaccaratViewModel.IsNewCards = false;

            shoe = new Shoe(GameBaccaratTest.Prepare1DeckShoe5());
            session.SetShoe(shoe);
            session.PlaySession();

            Assert.AreEqual(2, session.shoeResults.Count);

            Assert.AreEqual(4, session.shoeResults[0][11].CoupBet.UnitBet);
            Assert.AreEqual(4, session.shoeResults[1][11].CoupBet.UnitBet);

            Assert.AreEqual(-5M, Convert.ToDecimal(session.ItemsShoe[0].ScoreTotal));
            Assert.AreEqual(-10M, Convert.ToDecimal(session.ItemsShoe[1].ScoreTotal)); // note that this would be -8 if Follow_BetPlacement were not reset to none at top of new shoe
        }

        [TestMethod]
        public void SessionTest_CustomRepeatLengthsAreSetCorrectly_Test()
        {
            shoe = new Shoe(GameBaccaratTest.Prepare1DeckShoe_AllB());
            session.SetShoe(shoe);

            StrategySimulator.App.StrategizeSetNumber = 0;
            StrategySimulator.App.StrategizeBaccaratViewModel.BetPlacementStrategyOptionPickedIndex = (int)StrategiesBaccaratTypes.Repeat;
            session.PlaySession();

            Assert.AreEqual(1, session.GetCustomRepeatLength(0));

            StrategySimulator.App.StrategizeSetNumber = 0;
            StrategySimulator.App.StrategizeBaccaratViewModel.BetPlacementStrategyOptionPickedIndex = (int)StrategiesBaccaratTypes.TB4L;
            session.PlaySession();

            Assert.AreEqual(2, session.GetCustomRepeatLength(0));

            StrategySimulator.App.StrategizeSetNumber = 0;
            StrategySimulator.App.StrategizeBaccaratViewModel.CustomRepeatLength = "5";
            StrategySimulator.App.StrategizeBaccaratViewModel.BetPlacementStrategyOptionPickedIndex = (int)StrategiesBaccaratTypes.CustomRepeat;
            session.PlaySession();

            Assert.AreEqual(5, session.GetCustomRepeatLength(0));
        }

        [TestMethod]
        public void SessionTest_CustomOppositeLengthsAreSetCorrectly_Test()
        {
            shoe = new Shoe(GameBaccaratTest.Prepare1DeckShoe_AllB());
            session.SetShoe(shoe);

            StrategySimulator.App.StrategizeSetNumber = 0;
            StrategySimulator.App.StrategizeBaccaratViewModel.BetPlacementStrategyOptionPickedIndex = (int)StrategiesBaccaratTypes.Opposite;
            session.PlaySession();

            Assert.AreEqual(1, session.GetCustomOppositeLength(0));

            StrategySimulator.App.StrategizeSetNumber = 0;
            StrategySimulator.App.StrategizeBaccaratViewModel.BetPlacementStrategyOptionPickedIndex = (int)StrategiesBaccaratTypes.OTB4L;
            session.PlaySession();

            Assert.AreEqual(2, session.GetCustomOppositeLength(0));

            StrategySimulator.App.StrategizeSetNumber = 0;
            StrategySimulator.App.StrategizeBaccaratViewModel.CustomOppositeLength = "5";
            StrategySimulator.App.StrategizeBaccaratViewModel.BetPlacementStrategyOptionPickedIndex = (int)StrategiesBaccaratTypes.CustomOpposite;
            session.PlaySession();

            Assert.AreEqual(5, session.GetCustomOppositeLength(0));
        }
    }
}
