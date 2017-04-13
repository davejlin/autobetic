using StrategySimulator.Model.Results;
using StrategySimulator.Utilities;
using System.Collections.Generic;

namespace StrategySimulator.Model.Games
{
    public class GameBaccarat : IGame
    {

        private int _lastCoupIndex = 0;
        private Shoe _shoe;
        public Shoe Shoe 
        {
            get
            {
                return _shoe;
            } 
            set
            {
                if (_shoe != value)
                {
                    _shoe = value;
                    _lastCoupIndex = _shoe.Cards.Length - 6;
                }
            }
        }

        public List<ResultBaccaratCoup> Results { get; set; }
        private ResultBaccaratCoup aResultBaccaratCoup;
        public ResultBaccaratShoe aResultBaccaratShoe { get; private set; }

        public bool IncludeTies { get; set; }

        public GameBaccarat()
        {
            Results = new List<ResultBaccaratCoup>();
            aResultBaccaratCoup = new ResultBaccaratCoup();
            aResultBaccaratShoe = new ResultBaccaratShoe();

            IncludeTies = true;
        }

        public void Play()
        {
            int nDecision = 0;
            OutcomesBaccaratCoup result = OutcomesBaccaratCoup.None;
            aResultBaccaratShoe = new ResultBaccaratShoe();

            while (true)
            {
                result = PlayACoup();
                if (OutcomesBaccaratCoup.End == result)
                    break;

                if (OutcomesBaccaratCoup.None == result)
                    continue;

                aResultBaccaratCoup.IndexDecision = ++nDecision;
                aResultBaccaratCoup.OutcomeCoup = result;

                Results.Add(aResultBaccaratCoup);
                aResultBaccaratCoup = new ResultBaccaratCoup();
            }
        }

        public OutcomesBaccaratCoup PlayACoup()
        {
            if (_shoe.PointerIndex > _lastCoupIndex)
                return OutcomesBaccaratCoup.End;

            aResultBaccaratCoup.CardPlayer1 = NextCard();
            int card1 = DrawCard();

            aResultBaccaratCoup.CardBanker1 = NextCard();
            int card2 = DrawCard();

            aResultBaccaratCoup.CardPlayer2 = NextCard();
            int card3 = DrawCard();

            aResultBaccaratCoup.CardBanker2 = NextCard();
            int card4 = DrawCard();

            int player = (card1 + card3) % 10;
            int banker = (card2 + card4) % 10;

            if (player > 7 || banker > 7)
            {
                return ResultCoreLogic(player, banker);
            }
            else if (player > 5)
            {
                if (banker > 5)
                {
                    return ResultCoreLogic(player, banker);
                }
                else
                {
                    aResultBaccaratCoup.CardBanker3 = NextCard();
                    int card5 = DrawCard();

                    banker = (banker + card5) % 10;

                    return ResultCoreLogic(player, banker);
                }
            }
            else
            {
                aResultBaccaratCoup.CardPlayer3 = NextCard();
                int card6 = DrawCard();

                player = (player + card6) % 10;

                int card7 = 0;

                //if (BankerDrawRules(card6, banker))
                if (Constants.BankerDrawingRules[banker,card6])
                {
                    aResultBaccaratCoup.CardBanker3 = NextCard();
                    card7 = DrawCard();
                }

                banker = (banker + card7) % 10;

                return ResultCoreLogic(player, banker);

            }

            return OutcomesBaccaratCoup.None;

        }

        public void ClearResults()
        {
            Results.Clear();
        }

        private Card NextCard()
        {
            return _shoe.Cards[_shoe.PointerIndex];
        }

        private bool BankerDrawRules(int playerCard, int bankerTotal)
        {
            if (bankerTotal < 3)
                return true;
            else if (bankerTotal == 3)
            {
                if (playerCard != 8)
                    return true;
                else
                    return false;
            }
            else if (bankerTotal == 4)
            {
                if (playerCard > 1 && playerCard < 8)
                    return true;
                else
                    return false;
            }
            else if (bankerTotal == 5)
            {
                if (playerCard > 3 && playerCard < 8)
                    return true;
                else
                    return false;
            }
            else if (bankerTotal == 6)
            {
                if (playerCard == 6 || playerCard == 7)
                    return true;
                else
                    return false;
            }

            return false;
        }

        private OutcomesBaccaratCoup ResultCoreLogic(int player, int banker)
        {
            if (player > banker)
            {
                aResultBaccaratShoe.WinPlayer++;
                aResultBaccaratShoe.NCoups++;
                return OutcomesBaccaratCoup.P;
            }
            
            if (banker > player)
            {
                aResultBaccaratShoe.WinBanker++;
                aResultBaccaratShoe.NCoups++;
                return OutcomesBaccaratCoup.B;
            }

            if (IncludeTies) //if (player == banker)
            {
                aResultBaccaratShoe.WinTie++;
                aResultBaccaratShoe.NCoups++;
                return OutcomesBaccaratCoup.T;
            }

            return OutcomesBaccaratCoup.None;
        }

        private int DrawCard()
        {
            int value = (int)_shoe.Cards[_shoe.PointerIndex].Value;

            if (value > 9)
                value = 0;

            _shoe.PointerIndex++;

            return value;
        }
    }
}
