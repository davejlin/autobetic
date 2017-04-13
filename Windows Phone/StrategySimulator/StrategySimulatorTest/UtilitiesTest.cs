using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrategySimulator.Model;
using StrategySimulator.Model.Results;
using StrategySimulator.Utilities;
using System;
using System.Collections.Generic;

namespace StrategySimulatorTest
{
    [TestClass]
    public class UtilitiesTest
    {

        [TestMethod]
        public void UtilitiesTest_ExchangeTwoCards_Test()
        {
            Card[] cards = new Card[4];

            Card card0 = new Card(Suits.Clubs,   Values.Ace);
            Card card1 = new Card(Suits.Diamonds,Values.Jack);
            Card card2 = new Card(Suits.Hearts,  Values.Ten);
            Card card3 = new Card(Suits.Spades,  Values.Five);

            cards[0] = card0;
            cards[1] = card1;
            cards[2] = card2;
            cards[3] = card3;

            Utilities.ExchangeTwoCards(cards, 0, 1);

            Assert.AreSame(card0, cards[1]);
            Assert.AreSame(card1, cards[0]);

            Utilities.ExchangeTwoCards(cards, 0, 3);

            Assert.AreSame(card1, cards[3]);
            Assert.AreSame(card3, cards[0]);

            Utilities.ExchangeTwoCards(cards, 0, -1);

            Assert.AreSame(card1, cards[3]);
            Assert.AreSame(card3, cards[0]);

            Utilities.ExchangeTwoCards(cards, 0, 4);

            Assert.AreSame(card1, cards[3]);
            Assert.AreSame(card3, cards[0]);
        }

        [TestMethod]
        public void UtilitiesTest_Shuffle_Test()
        {
            int nDecks = 8;
            Shoe shoe = new Shoe(nDecks);

            Card[] cards = shoe.Cards;

            DeckTest.CheckPresenceOfAllCardsInOrder(cards, nDecks);
            string originalAllCardNames = shoe.DisplayAllCardsNames();

            Utilities.Shuffle(cards);

            string afterShuffleAllCardNames = shoe.DisplayAllCardsNames();

            Assert.AreEqual(52 * nDecks, cards.Length);
            Assert.AreNotEqual(originalAllCardNames, afterShuffleAllCardNames);
        }

        [TestMethod]
        public void UtilitiesTest_BurnCards_Test()
        {
            int nDecks = 8;
            Shoe shoe = new Shoe(nDecks);

            Card[] cards = shoe.Cards;

            int nBurnFront = 7;
            Utilities.BurnCards(shoe.PointerIndex, nBurnFront);
            Assert.AreEqual((52 * nDecks) - nBurnFront, cards.Length - nBurnFront);
        }

        [TestMethod]
        public void UtilitiesTest_GetImageURIFromCardName_Test()
        {
            string cardName = "ClubsAce";
            string imageURI = Utilities.ImageURIFromCardName(cardName);
            Assert.AreEqual("/Assets/Cards/ClubsAce.png", imageURI);
        }

        [TestMethod]
        public void UtilitiesTest_GetImageURIFromResult_Test()
        {
            string result = "P";
            string imageURI = Utilities.ImageURIFromResult(result);
            Assert.AreEqual("/Assets/Cards/ScorecardP.png", imageURI);
        }

        //[TestMethod]
        //public void UtilitiesTest_GetImageURIFromCardNameDictionary_Test()
        //{
        //    string cardName = "ClubsAce";
        //    string imageURI = Utilities.ImageURIFromCardNameDictionary(cardName);
        //    Assert.AreEqual("/Assets/Cards/ClubsAce.png", imageURI);
        //}

        //[TestMethod]
        //public void UtilitiesTest_GetImageURIFromResultDictionary_Test()
        //{
        //    string result = "P";
        //    string imageURI = Utilities.ImageURIFromResultDictionary(result);
        //    Assert.AreEqual("/Assets/Cards/ScorecardP.png", imageURI);
        //}

        [TestMethod]
        public void UtilitiesTest_GetImageURIFromCardNameArray_Test()
        {
            //string cardName = "ClubsAce";
            int suite = 2;
            int value = 1;
            string imageURI = Utilities.ImageURIFromCardNameArray(suite,value);
            Assert.AreEqual("/Assets/Cards/ClubsAce.png", imageURI);
        }

        [TestMethod]
        public void UtilitiesTest_GetImageURIFromResultArray_Test()
        {
            //string result = "P";
            int result = 1;
            string imageURI = Utilities.ImageURIFromResultArray(result);
            Assert.AreEqual("/Assets/Cards/ScorecardP.png", imageURI);
        }

        [TestMethod]
        public void UtilitiesTest_ParseBetProgressionString_Test()
        {
            string inputString = "1.1.2.3.5.8.13";
            List<int> expected = new List<int> {1,1,2,3,5,8,13};
            List<int> actual = Utilities.ParseBetProgressionString(inputString);

            CollectionAssert.AreEqual(expected, actual);

            inputString = "1.-1.1.2.3.5.8.13";
            actual = Utilities.ParseBetProgressionString(inputString);

            CollectionAssert.AreEqual(expected, actual);

            inputString = "1.-1.1.2.3.-11,5..8.13";
            expected = new List<int> { 1, 1, 2, 3, 5, 0, 8, 13 };
            actual = Utilities.ParseBetProgressionString(inputString);

            CollectionAssert.AreEqual(expected, actual);

            inputString = "..........";
            expected = new List<int> { 0,0,0,0,0,0,0,0,0,0,0 };
            actual = Utilities.ParseBetProgressionString(inputString);

            CollectionAssert.AreEqual(expected, actual);

            inputString = "";
            expected = new List<int> { 0 };
            actual = Utilities.ParseBetProgressionString(inputString);

            CollectionAssert.AreEqual(expected, actual);

            inputString = "   ";
            expected = new List<int> { 0 };
            actual = Utilities.ParseBetProgressionString(inputString);

            CollectionAssert.AreEqual(expected, actual);

            inputString = "1,10000000,2";
            expected = new List<int> { 1, Constants.BetMaxUnitMax, 2};
            actual = Utilities.ParseBetProgressionString(inputString);

            CollectionAssert.AreEqual(expected, actual);

            inputString = "1,10000000000000000,2";
            expected = new List<int> { 1, 0, 2 };
            actual = Utilities.ParseBetProgressionString(inputString);

            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void UtilitiesTest_ParseBetPlacementString_Test()
        {
            string inputString = "pbbttppp";
            OutcomesBaccaratCoup[] expected = new OutcomesBaccaratCoup[] {  OutcomesBaccaratCoup.P,
                                                                            OutcomesBaccaratCoup.B,
                                                                            OutcomesBaccaratCoup.B,
                                                                            OutcomesBaccaratCoup.T,
                                                                            OutcomesBaccaratCoup.T,
                                                                            OutcomesBaccaratCoup.P,
                                                                            OutcomesBaccaratCoup.P,
                                                                            OutcomesBaccaratCoup.P,
                                                                        };

            OutcomesBaccaratCoup[] actual = Utilities.ParseBetPlacementString(inputString);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UtilitiesTest_CheckFibonacciValues_Test()
        {
            int value1 = 1;
            int value2 = 1;

            Assert.AreEqual(value1, Constants.FibonacciSequence[0]);
            Assert.AreEqual(value2, Constants.FibonacciSequence[1]);

            for (int i = 2; i < Constants.FibonacciSequence.Length; i++)
            {
                int value3 = value1 + value2;
                Assert.AreEqual(value3, Constants.FibonacciSequence[i]);

                value1 = value2;
                value2 = value3;
            }
        }

        [TestMethod]
        public void UtilitiesTest_CheckAndConvertValueToInt_Test()
        {
            string value = "10";
            int max = 100;
            string property = "test";

            Assert.AreEqual(10, Utilities.CheckAndConvertValueToInt(value, max, property));

            value = "110";

            Assert.AreEqual(max, Utilities.CheckAndConvertValueToInt(value, max, property));
        }

        [TestMethod]
        public void UtilitiesTest_CheckAndConvertValueToIntExceptionThrown_Test()
        {
            string value = "some non-number";
            int max = 100;
            string property = "test";

            Assert.AreEqual(max, Utilities.CheckAndConvertValueToInt(value, max, property));

        }

        [TestMethod]
        public void UtilitiesTest_CalculateRatio_Test()
        {
            Assert.AreEqual("-", Utilities.CalculateRatio(0, 0));
            Assert.AreEqual("0", Utilities.CalculateRatio(0, 1));
            Assert.AreEqual(Math.Round(5.0/3.0, 2).ToString(), Utilities.CalculateRatio(5,3));
        }
    }
}