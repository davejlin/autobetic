using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrategySimulator.Model;
using StrategySimulator.Model.Games;
using StrategySimulator.Model.Results;

namespace StrategySimulatorTest
{
    [TestClass]
    public class GameBaccaratTest
    {
        GameBaccarat game;
        Shoe shoe;
        Card[] cards;

        [TestInitialize]
        public void init()
        {
        }

        [TestMethod]
        public void GameBaccaratTest_Score_Test()
        {
            // todo
        }

        [TestMethod]
        public void GameBaccaratTest_Naturals_Test()
        {
            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Eight),
                new Card(Suits.Clubs,Values.Six),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Clubs,Values.Three),
            };
            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe };
            OutcomesBaccaratCoup result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(2, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Eight),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(2, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(2, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Clubs,Values.Queen),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(2, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Ten),
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Clubs,Values.Eight),
                new Card(Suits.Clubs,Values.Jack),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(2, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Six),
                new Card(Suits.Clubs,Values.Jack),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(2, game.Shoe.Cards.Length-game.Shoe.PointerIndex);
        }

        [TestMethod]
        public void GameBaccaratTest_PlayerAndBankerStand_Test()
        {
            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Clubs,Values.Four),
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            OutcomesBaccaratCoup result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(2, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Four),
                new Card(Suits.Clubs,Values.Four),
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(2, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Clubs,Values.Ten),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Clubs,Values.Six),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(2, game.Shoe.Cards.Length-game.Shoe.PointerIndex);
        }

        [TestMethod]
        public void GameBaccaratTest_BankerDraws_Test()
        {
            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Clubs,Values.Four),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            OutcomesBaccaratCoup result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(1, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Clubs,Values.Four),
                new Card(Suits.Clubs,Values.Ten),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(1, game.Shoe.Cards.Length-game.Shoe.PointerIndex);
        }

        [TestMethod]
        public void GameBaccaratTest_PlayerDrawsBankerTotalTwoOrLess_Test()
        {
            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.Ten),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            OutcomesBaccaratCoup result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(0, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Queen),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.Queen),
                new Card(Suits.Clubs,Values.Six),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(0, game.Shoe.Cards.Length-game.Shoe.PointerIndex);
        }

        [TestMethod]
        public void GameBaccaratTest_PlayerDrawsBankerTotalThree_Test()
        {
            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.Eight),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            OutcomesBaccaratCoup result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(1, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Clubs,Values.Queen),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Clubs,Values.Six),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(0, game.Shoe.Cards.Length-game.Shoe.PointerIndex);
        }

        [TestMethod]
        public void GameBaccaratTest_PlayerDrawsBankerTotalFour_Test()
        {
            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Clubs,Values.Jack),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            OutcomesBaccaratCoup result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(1, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Clubs,Values.Five),
                new Card(Suits.Clubs,Values.Five),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(0, game.Shoe.Cards.Length-game.Shoe.PointerIndex);
        }

        [TestMethod]
        public void GameBaccaratTest_PlayerDrawsBankerTotalFive_Test()
        {
            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Clubs,Values.Queen),
                new Card(Suits.Clubs,Values.Eight),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            OutcomesBaccaratCoup result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(1, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Eight),
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Clubs,Values.Five),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(0, game.Shoe.Cards.Length-game.Shoe.PointerIndex);
        }

        [TestMethod]
        public void GameBaccaratTest_PlayerDrawsBankerTotalSix_Test()
        {
            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Clubs,Values.Four),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Clubs,Values.Five),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            OutcomesBaccaratCoup result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(1, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.Queen),
                new Card(Suits.Clubs,Values.Five),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Clubs,Values.Five),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(0, game.Shoe.Cards.Length-game.Shoe.PointerIndex);
        }

        [TestMethod]
        public void GameBaccaratTest_PlayerDrawsBankerTotalSeven_Test()
        {
            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.Ten),
                new Card(Suits.Clubs,Values.Four),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Clubs,Values.Four),
                new Card(Suits.Clubs,Values.Three),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            OutcomesBaccaratCoup result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(1, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            cards = new Card[6]
            {
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Clubs,Values.Five),
                new Card(Suits.Clubs,Values.Eight),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Clubs,Values.Five),
            };

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(1, game.Shoe.Cards.Length-game.Shoe.PointerIndex);
        }

        [TestMethod]
        public void GameBaccaratTest_OneDeckGame_1_Test()
        {
            cards = Prepare1DeckShoe1();

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            OutcomesBaccaratCoup result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(48, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(44, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(38, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(33, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(27, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(22, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(16, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(10, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(4, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.End, result);
            Assert.AreEqual(4, game.Shoe.Cards.Length-game.Shoe.PointerIndex);
        }

        [TestMethod]
        public void GameBaccaratTest_OneDeckGame_2_Test()
        {
            cards = Prepare1DeckShoe2();

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            OutcomesBaccaratCoup result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(48, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(42, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(38, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(34, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(29, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(25, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(20, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(15, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(9, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(5, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.End, result);
            Assert.AreEqual(5, game.Shoe.Cards.Length-game.Shoe.PointerIndex);

        }

        [TestMethod]
        public void GameBaccaratTest_OneDeckGame_2_NoTies_Test()
        {
            cards = Prepare1DeckShoe2();

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            game.IncludeTies = false;
            OutcomesBaccaratCoup result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.None, result);
            Assert.AreEqual(48, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(42, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(38, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(34, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(29, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(25, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(20, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(15, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(9, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(5, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.End, result);
            Assert.AreEqual(5, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

        }

        [TestMethod]
        public void GameBaccaratTest_OneDeckGame_3_Test()
        {
            cards = Prepare1DeckShoe3();

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            OutcomesBaccaratCoup result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(48, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(44, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(40, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(36, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(32, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(28, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(24, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(20, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(16, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(12, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(8, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(4, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.End, result);
            Assert.AreEqual(4, game.Shoe.Cards.Length - game.Shoe.PointerIndex);
        }

        [TestMethod]
        public void GameBaccaratTest_OneDeckGame_3_NoTies_Test()
        {
            cards = Prepare1DeckShoe3();

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            game.IncludeTies = false;
            OutcomesBaccaratCoup result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(48, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(44, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.None, result);
            Assert.AreEqual(40, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.None, result);
            Assert.AreEqual(36, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.None, result);
            Assert.AreEqual(32, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(28, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(24, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(20, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(16, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(12, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(8, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.None, result);
            Assert.AreEqual(4, game.Shoe.Cards.Length - game.Shoe.PointerIndex);

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.End, result);
            Assert.AreEqual(4, game.Shoe.Cards.Length - game.Shoe.PointerIndex);
        }

        [TestMethod]
        public void GameBaccaratTest_SessionStatistics_1_Test()
        {
            cards = Prepare1DeckShoe1();

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            game.Play();

            int winsPlayer = game.aResultBaccaratShoe.WinPlayer;
            int winsBanker = game.aResultBaccaratShoe.WinBanker;
            int winsTie = game.aResultBaccaratShoe.WinTie;
            int totalCoups = game.aResultBaccaratShoe.NCoups;

            Assert.AreEqual(5,winsPlayer);
            Assert.AreEqual(4,winsBanker);
            Assert.AreEqual(0,winsTie);
            Assert.AreEqual(9,totalCoups);

        }

        [TestMethod]
        public void GameBaccaratTest_SessionStatistics_2_Test()
        {
            cards = Prepare1DeckShoe2();

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            game.Play();

            int winsPlayer = game.aResultBaccaratShoe.WinPlayer;
            int winsBanker = game.aResultBaccaratShoe.WinBanker;
            int winsTie = game.aResultBaccaratShoe.WinTie;
            int totalCoups = game.aResultBaccaratShoe.NCoups;

            Assert.AreEqual(5, winsPlayer);
            Assert.AreEqual(4, winsBanker);
            Assert.AreEqual(1, winsTie);
            Assert.AreEqual(10, totalCoups);

        }

        [TestMethod]
        public void GameBaccaratTest_SessionStatistics_3_Test()
        {
            cards = Prepare1DeckShoe3();

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            game.Play();

            int winsPlayer = game.aResultBaccaratShoe.WinPlayer;
            int winsBanker = game.aResultBaccaratShoe.WinBanker;
            int winsTie = game.aResultBaccaratShoe.WinTie;
            int totalCoups = game.aResultBaccaratShoe.NCoups;

            Assert.AreEqual(3, winsPlayer);
            Assert.AreEqual(5, winsBanker);
            Assert.AreEqual(4, winsTie);
            Assert.AreEqual(12, totalCoups);

        }

        [TestMethod]
        public void GameBaccaratTest_SessionStatistics_1_NoTies_Test()
        {
            cards = Prepare1DeckShoe1();

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            game.IncludeTies = false;
            game.Play();

            int winsPlayer = game.aResultBaccaratShoe.WinPlayer;
            int winsBanker = game.aResultBaccaratShoe.WinBanker;
            int winsTie = game.aResultBaccaratShoe.WinTie;
            int totalCoups = game.aResultBaccaratShoe.NCoups;

            Assert.AreEqual(5, winsPlayer);
            Assert.AreEqual(4, winsBanker);
            Assert.AreEqual(0, winsTie);
            Assert.AreEqual(9, totalCoups);

        }

        [TestMethod]
        public void GameBaccaratTest_SessionStatistics_2_NoTies_Test()
        {
            cards = Prepare1DeckShoe2();

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            game.IncludeTies = false;
            game.Play();

            int winsPlayer = game.aResultBaccaratShoe.WinPlayer;
            int winsBanker = game.aResultBaccaratShoe.WinBanker;
            int winsTie = game.aResultBaccaratShoe.WinTie;
            int totalCoups = game.aResultBaccaratShoe.NCoups;

            Assert.AreEqual(5, winsPlayer);
            Assert.AreEqual(4, winsBanker);
            Assert.AreEqual(0, winsTie);
            Assert.AreEqual(9, totalCoups);

        }

        [TestMethod]
        public void GameBaccaratTest_SessionStatistics_3_NoTies_Test()
        {
            cards = Prepare1DeckShoe3();

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            game.IncludeTies = false;
            game.Play();

            int winsPlayer = game.aResultBaccaratShoe.WinPlayer;
            int winsBanker = game.aResultBaccaratShoe.WinBanker;
            int winsTie = game.aResultBaccaratShoe.WinTie;
            int totalCoups = game.aResultBaccaratShoe.NCoups;

            Assert.AreEqual(3, winsPlayer);
            Assert.AreEqual(5, winsBanker);
            Assert.AreEqual(0, winsTie);
            Assert.AreEqual(8, totalCoups);

        }

        [TestMethod]
        public void GameBaccaratTest_EightDeckGame_1_Test()
        {
            cards = Prepare8DeckShoe();

            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            OutcomesBaccaratCoup result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(410, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 1

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(406, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 2

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(401, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 3

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(396, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 4

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(392, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 5

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(387, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 6

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(381, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 7

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(377, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 8

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(371, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 9

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(367, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 10

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(363, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 11

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(359, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 12

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(354, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 13

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(350, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 14

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(346, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 15

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(342, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 16

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(336, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 17

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(330, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 18

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(326, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 19

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(321, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 20

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(317, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 21

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(311, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 22

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(305, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 23

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(300, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 24

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(294, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 25

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(289, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 26

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(283, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 27

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(278, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 28

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(272, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 29

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(268, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 30

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(263, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 31

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(258, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 32

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(254, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 33

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(248, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 34

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(242, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 35

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(237, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 36

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(233, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 37

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(229, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 38

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(224, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 39

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(218, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 40

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(214, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 41

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(210, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 42

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(204, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 43

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(199, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 44

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(194, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 45

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(189, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 46

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(185, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 47

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(181, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 48

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(175, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 49

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(171, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 50

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(167, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 51

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(161, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 52

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(157, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 53

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(152, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 54

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(146, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 55

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(140, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 56

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(134, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 57

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(129, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 58

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(125, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 59

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(121, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 60

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(116, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 61

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(112, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 62

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(108, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 63

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(102, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 64

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(96, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 65

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(92, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 66

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(86, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 67

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(81, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 68

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(77, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 69

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(72, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 70

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(66, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 71

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(60, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 72

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(54, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 73

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(50, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 74

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(45, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 75

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(41, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 76

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(35, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 77

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(31, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 78

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(26, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 79

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(21, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 80

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(17, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 81

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.T, result);
            Assert.AreEqual(13, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 82

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.P, result);
            Assert.AreEqual(8, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 83

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.B, result);
            Assert.AreEqual(3, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // 84

            result = game.PlayACoup();
            Assert.AreEqual(OutcomesBaccaratCoup.End, result);
            Assert.AreEqual(3, game.Shoe.Cards.Length - game.Shoe.PointerIndex); // End

            int winsPlayer = game.aResultBaccaratShoe.WinPlayer;
            int winsBanker = game.aResultBaccaratShoe.WinBanker;
            int winsTie = game.aResultBaccaratShoe.WinTie;
            int totalCoups = game.aResultBaccaratShoe.NCoups;

            Assert.AreEqual(31, winsPlayer);
            Assert.AreEqual(44, winsBanker);
            Assert.AreEqual(9, winsTie);
            Assert.AreEqual(84, totalCoups);
        }

        public static Card[] Prepare8DeckShoe()
        {
            return new Card[416]
            {
                new Card(Suits.Hearts,Values.Jack),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Spades,Values.Three),
                new Card(Suits.Spades,Values.Queen),
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Diamonds,Values.Jack), // 1
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.Eight),
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Clubs,Values.Ace), // 2
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Hearts,Values.Eight),
                new Card(Suits.Hearts,Values.Jack),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Diamonds,Values.Ten), // 3
                new Card(Suits.Clubs,Values.Queen),
                new Card(Suits.Hearts,Values.Jack),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Hearts,Values.Ace),
                new Card(Suits.Spades,Values.Two), // 4 
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Diamonds,Values.Four),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Spades,Values.Four), // 5
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Clubs,Values.Six),
                new Card(Suits.Spades,Values.Jack),
                new Card(Suits.Hearts,Values.Ten), // 6
                new Card(Suits.Diamonds,Values.Eight),
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Spades,Values.Five),
                new Card(Suits.Spades,Values.Jack),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Diamonds,Values.Six), // 7
                new Card(Suits.Spades,Values.Seven),
                new Card(Suits.Diamonds,Values.Six),
                new Card(Suits.Hearts,Values.Three),
                new Card(Suits.Clubs,Values.Three), // 8
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Spades,Values.Ace),
                new Card(Suits.Spades,Values.Seven),
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Hearts,Values.Jack), // 9
                new Card(Suits.Clubs,Values.Queen),
                new Card(Suits.Hearts,Values.Five),
                new Card(Suits.Hearts,Values.Seven),
                new Card(Suits.Diamonds,Values.Four), // 10
                new Card(Suits.Diamonds,Values.Eight),
                new Card(Suits.Spades,Values.Eight),
                new Card(Suits.Spades,Values.Three),
                new Card(Suits.Diamonds,Values.Ace), // 11
                new Card(Suits.Spades,Values.Ten),
                new Card(Suits.Spades,Values.Two),
                new Card(Suits.Clubs,Values.Six),
                new Card(Suits.Clubs,Values.Four), // 12
                new Card(Suits.Clubs,Values.Five),
                new Card(Suits.Spades,Values.Five),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Spades,Values.Five),
                new Card(Suits.Clubs,Values.Nine), // 13
                new Card(Suits.Spades,Values.Seven),
                new Card(Suits.Hearts,Values.Five),
                new Card(Suits.Clubs,Values.Ten),
                new Card(Suits.Hearts,Values.Three), // 14
                new Card(Suits.Hearts,Values.Eight),
                new Card(Suits.Spades,Values.Jack),
                new Card(Suits.Diamonds,Values.Queen),
                new Card(Suits.Clubs,Values.Four), // 15
                new Card(Suits.Hearts,Values.Ten),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Clubs,Values.Eight), // 16
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Jack),
                new Card(Suits.Hearts,Values.Ten),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Hearts,Values.Queen),
                new Card(Suits.Spades,Values.Five), // 17
                new Card(Suits.Spades,Values.Queen),
                new Card(Suits.Spades,Values.Three),
                new Card(Suits.Spades,Values.Queen),
                new Card(Suits.Clubs,Values.Ten),
                new Card(Suits.Diamonds,Values.Four),
                new Card(Suits.Diamonds,Values.Eight), // 18
                new Card(Suits.Clubs,Values.Jack),
                new Card(Suits.Diamonds,Values.Three),
                new Card(Suits.Diamonds,Values.Three),
                new Card(Suits.Diamonds,Values.Five), // 19
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Hearts,Values.Ace),
                new Card(Suits.Diamonds,Values.Queen),
                new Card(Suits.Clubs,Values.Four),
                new Card(Suits.Spades,Values.Jack), // 20
                new Card(Suits.Hearts,Values.Ten),
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Hearts,Values.Two),
                new Card(Suits.Spades,Values.King), // 21
                new Card(Suits.Clubs,Values.Five),
                new Card(Suits.Spades,Values.Ace),
                new Card(Suits.Clubs,Values.Eight),
                new Card(Suits.Spades,Values.Ten),
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Spades,Values.Six), // 22
                new Card(Suits.Hearts,Values.Six),
                new Card(Suits.Clubs,Values.Four),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Clubs,Values.Jack),
                new Card(Suits.Diamonds,Values.Five),
                new Card(Suits.Diamonds,Values.Nine), // 23
                new Card(Suits.Diamonds,Values.Ten),
                new Card(Suits.Diamonds,Values.Two),
                new Card(Suits.Diamonds,Values.Seven),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Clubs,Values.Queen), // 24
                new Card(Suits.Clubs,Values.Jack),
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Diamonds,Values.Five),
                new Card(Suits.Hearts,Values.Queen),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Clubs,Values.Three), // 25
                new Card(Suits.Spades,Values.Eight),
                new Card(Suits.Hearts,Values.Six),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Clubs,Values.Four),
                new Card(Suits.Spades,Values.Seven), // 26
                new Card(Suits.Diamonds,Values.Three),
                new Card(Suits.Spades,Values.Queen),
                new Card(Suits.Spades,Values.Queen),
                new Card(Suits.Clubs,Values.Ten),
                new Card(Suits.Hearts,Values.Two),
                new Card(Suits.Hearts,Values.Five), // 27
                new Card(Suits.Spades,Values.Four),
                new Card(Suits.Hearts,Values.Four),
                new Card(Suits.Diamonds,Values.Ten),
                new Card(Suits.Diamonds,Values.Ace),
                new Card(Suits.Spades,Values.Ten), // 28
                new Card(Suits.Hearts,Values.Ace),
                new Card(Suits.Hearts,Values.Two),
                new Card(Suits.Clubs,Values.Queen),
                new Card(Suits.Diamonds,Values.Three),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Spades,Values.Jack), // 29
                new Card(Suits.Diamonds,Values.Eight),
                new Card(Suits.Diamonds,Values.Five),
                new Card(Suits.Clubs,Values.Ten),
                new Card(Suits.Diamonds,Values.Four), // 30
                new Card(Suits.Spades,Values.Ten),
                new Card(Suits.Hearts,Values.Eight),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Hearts,Values.Four), // 31
                new Card(Suits.Diamonds,Values.Two),
                new Card(Suits.Diamonds,Values.Three),
                new Card(Suits.Hearts,Values.Ace),
                new Card(Suits.Hearts,Values.Four),
                new Card(Suits.Clubs,Values.Nine), // 32
                new Card(Suits.Hearts,Values.Queen),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.Eight),
                new Card(Suits.Hearts,Values.Queen), // 33
                new Card(Suits.Spades,Values.Three),
                new Card(Suits.Hearts,Values.Five),
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Spades,Values.Eight),
                new Card(Suits.Spades,Values.Jack),
                new Card(Suits.Diamonds,Values.Nine), // 34
                new Card(Suits.Spades,Values.Queen),
                new Card(Suits.Hearts,Values.Eight),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Spades,Values.Two),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Spades,Values.Nine), // 35
                new Card(Suits.Clubs,Values.Five),
                new Card(Suits.Hearts,Values.Three),
                new Card(Suits.Spades,Values.Ace),
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Hearts,Values.Queen), // 36
                new Card(Suits.Diamonds,Values.Seven),
                new Card(Suits.Spades,Values.Eight),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Diamonds,Values.Jack), // 37
                new Card(Suits.Spades,Values.Four),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Spades,Values.Three),
                new Card(Suits.Spades,Values.Seven), // 38
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Clubs,Values.Two), 
                new Card(Suits.Diamonds,Values.Ace), 
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Ten), // 39
                new Card(Suits.Diamonds,Values.Queen),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Diamonds,Values.Three),
                new Card(Suits.Diamonds,Values.Seven),
                new Card(Suits.Diamonds,Values.Six),
                new Card(Suits.Hearts,Values.Nine), // 40
                new Card(Suits.Clubs,Values.Queen),
                new Card(Suits.Hearts,Values.Two),
                new Card(Suits.Clubs,Values.Six),
                new Card(Suits.Hearts,Values.Four), // 41
                new Card(Suits.Spades,Values.Five),
                new Card(Suits.Diamonds,Values.Four),
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Hearts,Values.Two), // 42
                new Card(Suits.Hearts,Values.Ten),
                new Card(Suits.Clubs,Values.Jack),
                new Card(Suits.Hearts,Values.Queen),
                new Card(Suits.Diamonds,Values.Two),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Diamonds,Values.Five), // 43
                new Card(Suits.Hearts,Values.Seven),
                new Card(Suits.Diamonds,Values.Ten),
                new Card(Suits.Clubs,Values.Five),
                new Card(Suits.Spades,Values.Six),
                new Card(Suits.Diamonds,Values.Two), // 44
                new Card(Suits.Diamonds,Values.Queen),
                new Card(Suits.Hearts,Values.Queen),
                new Card(Suits.Spades,Values.Five),
                new Card(Suits.Diamonds,Values.Six),
                new Card(Suits.Hearts,Values.Ten), // 45
                new Card(Suits.Diamonds,Values.Jack),
                new Card(Suits.Hearts,Values.Ace),
                new Card(Suits.Clubs,Values.Four),
                new Card(Suits.Diamonds,Values.Six),
                new Card(Suits.Spades,Values.Ace), // 46
                new Card(Suits.Clubs,Values.Six),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.Six),
                new Card(Suits.Diamonds,Values.Ten), // 47
                new Card(Suits.Hearts,Values.Ace),
                new Card(Suits.Diamonds,Values.Three),
                new Card(Suits.Clubs,Values.Five),
                new Card(Suits.Spades,Values.Six), // 48
                new Card(Suits.Hearts,Values.Six),
                new Card(Suits.Diamonds,Values.Two),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Diamonds,Values.Ace),
                new Card(Suits.Diamonds,Values.Jack),
                new Card(Suits.Spades,Values.King), // 49
                new Card(Suits.Diamonds,Values.Two),
                new Card(Suits.Hearts,Values.Six),
                new Card(Suits.Hearts,Values.Six),
                new Card(Suits.Diamonds,Values.King), // 50
                new Card(Suits.Diamonds,Values.Ten),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Diamonds,Values.Eight),
                new Card(Suits.Clubs,Values.Ten), // 51
                new Card(Suits.Clubs,Values.Ten),
                new Card(Suits.Hearts,Values.Five),
                new Card(Suits.Hearts,Values.Jack),
                new Card(Suits.Hearts,Values.Six),
                new Card(Suits.Hearts,Values.Jack),
                new Card(Suits.Clubs,Values.Queen), // 52
                new Card(Suits.Clubs,Values.Eight),
                new Card(Suits.Diamonds,Values.Queen),
                new Card(Suits.Spades,Values.Queen),
                new Card(Suits.Spades,Values.Two), // 53
                new Card(Suits.Diamonds,Values.Eight),
                new Card(Suits.Diamonds,Values.Eight),
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Diamonds,Values.Six),
                new Card(Suits.Diamonds,Values.King), // 54
                new Card(Suits.Spades,Values.Seven),
                new Card(Suits.Hearts,Values.Eight),
                new Card(Suits.Clubs,Values.Five),
                new Card(Suits.Hearts,Values.Three),
                new Card(Suits.Hearts,Values.Five),
                new Card(Suits.Clubs,Values.Eight), // 55
                new Card(Suits.Spades,Values.Six),
                new Card(Suits.Diamonds,Values.Jack),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Diamonds,Values.Ace),
                new Card(Suits.Spades,Values.Three),
                new Card(Suits.Spades,Values.Seven), // 56
                new Card(Suits.Diamonds,Values.Three),
                new Card(Suits.Hearts,Values.Ten),
                new Card(Suits.Clubs,Values.Jack),
                new Card(Suits.Spades,Values.Jack),
                new Card(Suits.Hearts,Values.Ace),
                new Card(Suits.Clubs,Values.Five), // 57
                new Card(Suits.Hearts,Values.Four),
                new Card(Suits.Diamonds,Values.Jack),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Hearts,Values.Five),
                new Card(Suits.Spades,Values.Ace), // 58
                new Card(Suits.Spades,Values.Six),
                new Card(Suits.Diamonds,Values.Jack),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.Seven), // 59
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Diamonds,Values.Queen),
                new Card(Suits.Clubs,Values.Six),
                new Card(Suits.Hearts,Values.Nine), // 60
                new Card(Suits.Hearts,Values.Seven),
                new Card(Suits.Clubs,Values.Eight),
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Spades,Values.Six),
                new Card(Suits.Spades,Values.Six), // 61
                new Card(Suits.Hearts,Values.Three),
                new Card(Suits.Spades,Values.Eight),
                new Card(Suits.Clubs,Values.Ten),
                new Card(Suits.Clubs,Values.Queen), // 62
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Clubs,Values.Six),
                new Card(Suits.Clubs,Values.Five),
                new Card(Suits.Diamonds,Values.Seven), // 63
                new Card(Suits.Hearts,Values.Ace),
                new Card(Suits.Clubs,Values.Four),
                new Card(Suits.Spades,Values.Four),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Spades,Values.Four),
                new Card(Suits.Spades,Values.Two), // 64
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Spades,Values.Ace),
                new Card(Suits.Hearts,Values.Three),
                new Card(Suits.Diamonds,Values.Ace),
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Hearts,Values.Five), // 65
                new Card(Suits.Spades,Values.Eight),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Spades,Values.Ten),
                new Card(Suits.Diamonds,Values.Ten), // 66
                new Card(Suits.Clubs,Values.Queen),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Hearts,Values.Six),
                new Card(Suits.Diamonds,Values.Four),
                new Card(Suits.Clubs,Values.King), // 67
                new Card(Suits.Spades,Values.Six),
                new Card(Suits.Diamonds,Values.Six),
                new Card(Suits.Clubs,Values.Eight),
                new Card(Suits.Diamonds,Values.Ace),
                new Card(Suits.Clubs,Values.Nine), // 68
                new Card(Suits.Hearts,Values.Seven),
                new Card(Suits.Spades,Values.Two),
                new Card(Suits.Hearts,Values.Queen),
                new Card(Suits.Spades,Values.Four), // 69
                new Card(Suits.Spades,Values.Five),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Ace),
                new Card(Suits.Spades,Values.Queen),
                new Card(Suits.Diamonds,Values.Seven), // 70
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Hearts,Values.Two),
                new Card(Suits.Spades,Values.Two),
                new Card(Suits.Hearts,Values.Seven),
                new Card(Suits.Clubs,Values.Jack), // 71
                new Card(Suits.Diamonds,Values.Queen),
                new Card(Suits.Spades,Values.Three),
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Diamonds,Values.Jack),
                new Card(Suits.Diamonds,Values.Two),
                new Card(Suits.Hearts,Values.Two), // 72
                new Card(Suits.Diamonds,Values.Five),
                new Card(Suits.Diamonds,Values.Queen),
                new Card(Suits.Spades,Values.Eight),
                new Card(Suits.Spades,Values.Two),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // 73
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Ace),
                new Card(Suits.Spades,Values.Four),
                new Card(Suits.Spades,Values.Seven), // 74
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Spades,Values.Ten),
                new Card(Suits.Hearts,Values.Four),
                new Card(Suits.Diamonds,Values.Seven),
                new Card(Suits.Clubs,Values.Jack), // 75
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Hearts,Values.Eight),
                new Card(Suits.Hearts,Values.Three),
                new Card(Suits.Diamonds,Values.King), // 76
                new Card(Suits.Diamonds,Values.Five),
                new Card(Suits.Hearts,Values.Six),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.Five),
                new Card(Suits.Diamonds,Values.Ten),
                new Card(Suits.Hearts,Values.Jack), // 77
                new Card(Suits.Hearts,Values.Two),
                new Card(Suits.Clubs,Values.Four),
                new Card(Suits.Hearts,Values.Seven),
                new Card(Suits.Hearts,Values.Four), // 78
                new Card(Suits.Diamonds,Values.Six),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Spades,Values.Three),
                new Card(Suits.Spades,Values.Four), // 79
                new Card(Suits.Diamonds,Values.Two),
                new Card(Suits.Hearts,Values.Four),
                new Card(Suits.Hearts,Values.Three),
                new Card(Suits.Hearts,Values.Ten),
                new Card(Suits.Spades,Values.King), // 80
                new Card(Suits.Hearts,Values.Jack),
                new Card(Suits.Hearts,Values.Eight),
                new Card(Suits.Diamonds,Values.Five),
                new Card(Suits.Spades,Values.Ten), // 81
                new Card(Suits.Hearts,Values.Eight),
                new Card(Suits.Clubs,Values.Six),
                new Card(Suits.Clubs,Values.Eight),
                new Card(Suits.Clubs,Values.King), // 82
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Hearts,Values.Seven),
                new Card(Suits.Diamonds,Values.Seven),
                new Card(Suits.Diamonds,Values.Four),
                new Card(Suits.Spades,Values.Jack), // 83
                new Card(Suits.Hearts,Values.Seven),
                new Card(Suits.Spades,Values.Ace),
                new Card(Suits.Spades,Values.Ten),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Spades,Values.Eight), // 84
                new Card(Suits.Diamonds,Values.Four),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Clubs,Values.Seven)
            };
        }


        public static Card[] Prepare1DeckShoe1()
        {
            return new Card[52]
            {
                new Card(Suits.Clubs,Values.Three),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.Seven),
                new Card(Suits.Diamonds,Values.Queen),
                new Card(Suits.Clubs,Values.Eight),
                new Card(Suits.Spades,Values.Four),
                new Card(Suits.Clubs,Values.Ten),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Hearts,Values.Ten),
                new Card(Suits.Hearts,Values.Ace),
                new Card(Suits.Spades,Values.Jack),
                new Card(Suits.Hearts,Values.Two),
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Hearts,Values.Eight),
                new Card(Suits.Hearts,Values.Seven),
                new Card(Suits.Spades,Values.Ten),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Diamonds,Values.Four),
                new Card(Suits.Spades,Values.Eight),
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Clubs,Values.Six),
                new Card(Suits.Diamonds,Values.Jack),
                new Card(Suits.Diamonds,Values.Six),
                new Card(Suits.Spades,Values.Six),
                new Card(Suits.Clubs,Values.Jack),
                new Card(Suits.Diamonds,Values.Three),
                new Card(Suits.Diamonds,Values.Five),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Clubs,Values.Queen),
                new Card(Suits.Diamonds,Values.Ten),
                new Card(Suits.Hearts,Values.Four),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Spades,Values.Ace),
                new Card(Suits.Hearts,Values.Six),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.Jack),
                new Card(Suits.Clubs,Values.Four),
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Spades,Values.Queen),
                new Card(Suits.Diamonds,Values.Two),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Clubs,Values.Five),
                new Card(Suits.Hearts,Values.Three),
                new Card(Suits.Spades,Values.Five),
                new Card(Suits.Hearts,Values.Queen),
                new Card(Suits.Spades,Values.Two),
                new Card(Suits.Diamonds,Values.Eight),
                new Card(Suits.Spades,Values.Three),
                new Card(Suits.Diamonds,Values.Seven),
                new Card(Suits.Diamonds,Values.Ace),
                new Card(Suits.Hearts,Values.Five),
            };
        }

        public static Card[] Prepare1DeckShoe2()
        {
            return new Card[52]
            {
                new Card(Suits.Clubs,Values.Six),
                new Card(Suits.Diamonds,Values.Six),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.Ten),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Spades,Values.Ten),
                new Card(Suits.Clubs,Values.Jack),
                new Card(Suits.Spades,Values.Five),
                new Card(Suits.Hearts,Values.Five),
                new Card(Suits.Hearts,Values.Two),
                new Card(Suits.Spades,Values.Eight),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Clubs,Values.Ace),
                new Card(Suits.Hearts,Values.Seven),
                new Card(Suits.Hearts,Values.Six),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Clubs,Values.Two),
                new Card(Suits.Diamonds,Values.Three),
                new Card(Suits.Spades,Values.Three),
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.Five),
                new Card(Suits.Diamonds,Values.Eight),
                new Card(Suits.Spades,Values.Queen),
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.Jack),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Clubs,Values.Queen),
                new Card(Suits.Diamonds,Values.Four),
                new Card(Suits.Hearts,Values.Five),
                new Card(Suits.Hearts,Values.Two),
                new Card(Suits.Spades,Values.Jack),
                new Card(Suits.Hearts,Values.Queen),
                new Card(Suits.Spades,Values.Ace),
                new Card(Suits.Hearts,Values.Seven),
                new Card(Suits.Clubs,Values.Seven),
                new Card(Suits.Hearts,Values.Ten),
                new Card(Suits.Spades,Values.Three),
                new Card(Suits.Diamonds,Values.Ace),
                new Card(Suits.Clubs,Values.Jack),
                new Card(Suits.Clubs,Values.Four),
                new Card(Suits.Hearts,Values.Eight),
                new Card(Suits.Spades,Values.Four),
                new Card(Suits.Hearts,Values.Queen),
                new Card(Suits.Spades,Values.Ten),
                new Card(Suits.Diamonds,Values.Eight),
                new Card(Suits.Spades,Values.Three),
                new Card(Suits.Diamonds,Values.Two),
                new Card(Suits.Diamonds,Values.Four),
                new Card(Suits.Hearts,Values.Six),
                new Card(Suits.Clubs,Values.Seven),
            };
        }

        public static Card[] Prepare1DeckShoe3()
        {
            return new Card[52]
            {
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // B
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // T
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // T
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // T
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // B
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // B
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // T
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King),
            };
        }

        public static Card[] Prepare1DeckShoe4()
        {
            return new Card[52]
            {
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // T
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // T
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // P
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // T
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // T
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // B
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // B
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // T
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King),
            };
        }

        public static Card[] Prepare1DeckShoe5()
        {
            return new Card[52]
            {
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // T
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // B
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // P
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // P
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // B
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // P
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // P
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // T
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // B
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King),
            };
        }

        public static Card[] Prepare1DeckShoe_AllP()
        {
            return new Card[52]
            {
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // P
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // P
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // P
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // P
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // P
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // P
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King), // P
                new Card(Suits.Hearts,Values.Nine),
                new Card(Suits.Hearts,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Hearts,Values.King), // P
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King),
            };
        }

        public static Card[] Prepare1DeckShoe_AllB()
        {
            return new Card[52]
            {
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King),
            };
        }

        public static Card[] Prepare1DeckShoe_Chop()
        {
            return new Card[52]
            {
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.Nine),
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Spades,Values.King),
            };
        }

        public static Card[] Prepare1DeckShoe_TerribleTwos()
        {
            return new Card[52]
            {
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.Nine),
                new Card(Suits.Diamonds,Values.King),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // P
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King), // B
                new Card(Suits.Clubs,Values.King),
                new Card(Suits.Diamonds,Values.Nine),
                new Card(Suits.Spades,Values.King),
                new Card(Suits.Diamonds,Values.King),
            };
        }
    }
}
