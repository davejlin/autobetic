using StrategySimulator.Model;
using StrategySimulator.Model.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategySimulator.Utilities
{
    public static class Utilities
    {
        //private static Dictionary<string, string> cardNameImageURIDictionary = LoadCardNameImageURIDictionary();
        //public static Dictionary<string, string> CardNameImageURIDictionary
        //{
        //    get
        //    {
        //        return cardNameImageURIDictionary;
        //    }
        //}

        //private static Dictionary<string, string> LoadCardNameImageURIDictionary()
        //{
        //    Dictionary<string, string> dictionary = new Dictionary<string, string>();
        //    for (int suite = 0; suite < 4; suite++)
        //    {
        //        for (int value = 1; value < 14; value++)
        //        {
        //            string cardName = ((Suits)suite).ToString() + ((Values)value).ToString();
        //            dictionary.Add(cardName, ImageURIFromCardName(cardName));
        //        }
        //    }

        //    dictionary.Add("NoneNone", "no image");

        //    return dictionary;
        //}

        //private static Dictionary<string, string> resultImageURIDictionary = LoadResultImageURIDictionary();
        //public static Dictionary<string, string> ResultImageURIDictionary
        //{
        //    get
        //    {
        //        return resultImageURIDictionary;
        //    }
        //}

        //private static Dictionary<string, string> LoadResultImageURIDictionary()
        //{
        //    Dictionary<string, string> dictionary = new Dictionary<string, string>();
        //    for (int outcome = 0; outcome < 3; outcome++)
        //    {
        //        string outcomeName = ((GameBaccarat.OutcomesBaccarat)outcome).ToString();
        //        dictionary.Add(outcomeName, ImageURIFromResult(outcomeName));
        //    }
        //    return dictionary;
        //}

        private static string[,] cardNameImageURIArray = LoadCardNameImageURIArray();
        public static string[,] CardNameImageURLArray
        {
            get
            {
                return cardNameImageURIArray;
            }
        }

        private static string[,] LoadCardNameImageURIArray()
        {
            string[,] array = new string[5,14];
            for (int suite = 0; suite < 5; suite++)
            {
                for (int value = 0; value < 14; value++)
                {
                    string cardName = ((Suits)suite).ToString() + ((Values)value).ToString();
                    array[suite,value]=ImageURIFromCardName(cardName);
                }
            }

            return array;
        }

        private static string[] resultImageURIArray = LoadResultImageURIArray();
        public static string[] ResultImageURIArray
        {
            get
            {
                return resultImageURIArray;
            }
        }

        private static string[] LoadResultImageURIArray()
        {
            string[] array = new string[3];
            for (int outcome = 0; outcome < 3; outcome++)
            {
                string outcomeName = ((OutcomesBaccaratCoup)outcome).ToString();
                array[outcome] = ImageURIFromResult(outcomeName);
            }
            return array;
        }

        public static void Shuffle(Card[] cards)
        {
            int nCards = cards.Length;


            for (int i = 0; i < nCards; i++)
            {
                int pos1 = Constants.Random.Next(nCards);
                int pos2 = Constants.Random.Next(nCards);

                ExchangeTwoCards(cards, pos1, pos2);
            }

        }

        public static void ExchangeTwoCards(Card[] cards, int pos1, int pos2)
        {
            if (pos1 < 0 || pos2 < 0)
                return;

            int cardCount = cards.Length;
            if (pos1 >= cardCount || pos2 >= cardCount)
                return;

            Card tempCard1 = cards[pos1];
            cards[pos1] = cards[pos2];
            cards[pos2] = tempCard1;
        }

        internal static string DisplayAllCardNames(Card[] Cards)
        {
            StringBuilder allCardNames = new StringBuilder();

            foreach(Card card in Cards)
            {
                allCardNames.Append(card.ToString());
                allCardNames.Append("\r\n");
            }

            return allCardNames.ToString();
        }

        public static int BurnCards(int pointerIndex, int nBurn)
        {
            return pointerIndex + nBurn;
        }

        public static string ImageURIFromCardName(string cardName)
        {
            StringBuilder builder = new StringBuilder("/Assets/Cards/");
            builder.Append(cardName);
            builder.Append(".png");
            return builder.ToString();
        }

        public static string ImageURIFromResult(string result)
        {
            StringBuilder builder = new StringBuilder("/Assets/Cards/Scorecard");
            builder.Append(result);
            builder.Append(".png");
            return builder.ToString();
        }

        //public static string ImageURIFromCardNameDictionary(string cardName)
        //{
        //    return cardNameImageURIDictionary[cardName];
        //}

        //public static string ImageURIFromResultDictionary(string result)
        //{
        //    return resultImageURIDictionary[result];
        //}

        public static string ImageURIFromCardNameArray(int suite, int value)
        {
            return cardNameImageURIArray[suite,value];
        }

        public static string ImageURIFromResultArray(int result)
        {
            return resultImageURIArray[result];
        }

        private static char[] delimiters = { '.', ',' };
        public static List<int> ParseBetProgressionString(string betString)
        {
            string[] betStringParsed = betString.Split(delimiters);
            List<int> betValues = new List<int>();

            if (betStringParsed.Length == 0)
            {
                betValues.Add(0);
            }
            else
            {
                foreach (string bet in betStringParsed)
                {
                    int betInt = 0;
                    try
                    {
                        betInt = Convert.ToInt32(bet);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("EXCEPTION: Utilities/ParseBetString: " + e.ToString());
                    }

                    if (betInt >= 0)
                    {
                        betValues.Add(Math.Min(betInt,Constants.BetMaxUnitMax));
                    }

                }
            }

            return betValues;
        }

        public static OutcomesBaccaratCoup[] ParseBetPlacementString(string inputString)
        {
            int stringLength = inputString.Length;
            OutcomesBaccaratCoup[] betPlacements = new OutcomesBaccaratCoup[stringLength];

            char[] placements = inputString.ToUpper().ToCharArray();

            int i=0;
            foreach (char placement in placements)
            {
                Constants.BetPlacementDictionary.TryGetValue(placement, out betPlacements[i++]);
            }

            return betPlacements;
        }

        public static int CheckAndConvertValueToInt(string value, int max, string property)
        {
            int betInt = max;

            try
            {
                betInt = Convert.ToInt32(value);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(property + ": " + e.ToString());
            }

            if (betInt > max)
                betInt = max;

            return betInt;
        }


        public static string CalculateRatio(decimal numator, decimal denominator)
        {
            if (denominator == 0)
                return "-";

            if (numator == 0)
                return "0";

            return Math.Round((double)numator / (double)denominator, 2).ToString("f2");
        }
    }
}
