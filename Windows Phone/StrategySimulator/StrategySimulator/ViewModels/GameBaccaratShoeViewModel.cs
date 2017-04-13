using StrategySimulator.Model;
using StrategySimulator.Model.Results;
using StrategySimulator.Model.Scores;
using StrategySimulator.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Text;

namespace StrategySimulator.ViewModels
{
    public class GameBaccaratShoeViewModel : BaseViewModel
    {
        public ObservableCollection<ItemResultBaccaratCoupViewModel> ItemsCoup { get; private set; }
        public ObservableCollection<ChartDataPoint> ChartCoupScores { get; private set; }

        public string StatsCoupsValue { get; set; }
        public string StatsPlayerValue { get; set; }
        public string StatsPlayerPercent { get; set; }
        public string StatsBankerValue { get; set; }
        public string StatsBankerPercent { get; set; }
        public string StatsTieValue { get; set; }
        public string StatsTiePercent { get; set; }

        public string StatsWinLossNumberValue { get; set; }
        public string StatsWinLossNumberPercent { get; set; }
        public string StatsWinLossNumberPlayerValue { get; set; }
        public string StatsWinLossNumberPlayerPercent { get; set; }
        public string StatsWinLossNumberBankerValue { get; set; }
        public string StatsWinLossNumberBankerPercent { get; set; }
        public string StatsWinLossNumberTieValue { get; set; }
        public string StatsWinLossNumberTiePercent { get; set; }

        public string StatsWinLossUnitValue { get; set; }
        public string StatsWinLossUnitPercent { get; set; }
        public string StatsWinLossUnitPlayerValue { get; set; }
        public string StatsWinLossUnitPlayerPercent { get; set; }
        public string StatsWinLossUnitBankerValue { get; set; }
        public string StatsWinLossUnitBankerPercent { get; set; }
        public string StatsWinLossUnitTieValue { get; set; }
        public string StatsWinLossUnitTiePercent { get; set; }

        public string StatsMaxValue { get; set; }
        public string StatsAveValue { get; set; }
        public string StatsTotalScoreValue { get; set; }
        public string StatsPAValue { get; set; }

        public GameBaccaratShoeViewModel()
        {
            ItemsCoup = new ObservableCollection<ItemResultBaccaratCoupViewModel>();
            ChartCoupScores = new ObservableCollection<ChartDataPoint>();
        }

        public void LoadShoeResults(int index)
        {
            ItemsCoup.Clear();
            ChartCoupScores = new ObservableCollection<ChartDataPoint>();

            foreach (ResultBaccaratCoup result in App.GameBaccaratSessionViewModel.session.shoeResults[index])
            {
                string indexDecision = result.IndexDecision.ToString();
                decimal totalDollarScore = result.TotalDollarScore;

                ItemsCoup.Add(new ItemResultBaccaratCoupViewModel()
                {
                    IndexDecision = indexDecision,
                    Winner = Utilities.Utilities.ImageURIFromResultArray((int)result.OutcomeCoup),
                    CardPlayer1 = Utilities.Utilities.ImageURIFromCardNameArray((int)result.CardPlayer1.Suit, (int)result.CardPlayer1.Value),
                    CardPlayer2 = Utilities.Utilities.ImageURIFromCardNameArray((int)result.CardPlayer2.Suit, (int)result.CardPlayer2.Value),
                    CardPlayer3 = Utilities.Utilities.ImageURIFromCardNameArray((int)result.CardPlayer3.Suit, (int)result.CardPlayer3.Value),
                    CardBanker1 = Utilities.Utilities.ImageURIFromCardNameArray((int)result.CardBanker1.Suit, (int)result.CardBanker1.Value),
                    CardBanker2 = Utilities.Utilities.ImageURIFromCardNameArray((int)result.CardBanker2.Suit, (int)result.CardBanker2.Value),
                    CardBanker3 = Utilities.Utilities.ImageURIFromCardNameArray((int)result.CardBanker3.Suit, (int)result.CardBanker3.Value),
                    IsBetBanker = result.CoupBet.BetPlacement == OutcomesBaccaratCoup.B ? true : false,
                    IsBetPlayer = result.CoupBet.BetPlacement == OutcomesBaccaratCoup.P ? true : false,
                    IsBetTie    = result.CoupBet.BetPlacement == OutcomesBaccaratCoup.T ? true : false,
                    UnitBet     = result.CoupBet.UnitBet.ToString(),
                    TotalScore = totalDollarScore.ToString()
                });

                // for coup vs. score chart:
                ChartCoupScores.Add(new ChartDataPoint() { x = indexDecision, y = totalDollarScore });
            }

            LoadShoeStatistics(index);
        }

        private void LoadShoeStatistics(int index)
        {
            ResetStats();

            LoadCoupStatistics(App.GameBaccaratSessionViewModel.session.ItemsShoe[index]);
            LoadWinLossStatistics(App.GameBaccaratSessionViewModel.session.shoeScores[index]);
        }

        private void LoadCoupStatistics(ItemResultBaccaratShoeViewModel results)
        {
            StatsCoupsValue = results.NCoup;
            double coupsValue = Math.Round(Convert.ToDouble(StatsCoupsValue), 2);

            if (coupsValue > 0.0)
            {
                double coupsValueInv = 100.0 / coupsValue;

                StatsPlayerValue = results.NPlayer;
                StatsBankerValue = results.NBanker;
                StatsTieValue = results.NTie;

                double percent = Math.Round(coupsValueInv * Convert.ToDouble(StatsPlayerValue), 2);
                StatsPlayerPercent = new StringBuilder(percent.ToString("f2")).Append("%").ToString();

                percent = Math.Round(coupsValueInv * Convert.ToDouble(StatsBankerValue), 2);
                StatsBankerPercent = new StringBuilder(percent.ToString("f2")).Append("%").ToString();

                percent = Math.Round(coupsValueInv * Convert.ToDouble(StatsTieValue), 2);
                StatsTiePercent = new StringBuilder(percent.ToString("f2")).Append("%").ToString();
            }
        }

        private void LoadWinLossStatistics(ScoreBaccarat score)
        {
            // number:

            int numberPlayerWin = score.NumberPlayerWin;
            int numberBankerWin = score.NumberBankerWin;
            int numberTieWin = score.NumberTieWin;

            int numberWin = numberPlayerWin + numberBankerWin + numberTieWin;

            int numberPlayerLoss = score.NumberPlayerLoss;
            int numberBankerLoss = score.NumberBankerLoss;
            int numberTieLoss = score.NumberTieLoss;

            int numberLoss = numberPlayerLoss + numberBankerLoss + numberTieLoss;

            StatsWinLossNumberValue = new StringBuilder(numberWin.ToString()).Append(" : ").Append(numberLoss.ToString()).ToString();

            StatsWinLossNumberPlayerValue = new StringBuilder(numberPlayerWin.ToString()).Append(" : ").Append(numberPlayerLoss.ToString()).ToString();
            StatsWinLossNumberBankerValue = new StringBuilder(numberBankerWin.ToString()).Append(" : ").Append(numberBankerLoss.ToString()).ToString();
            StatsWinLossNumberTieValue = new StringBuilder(numberTieWin.ToString()).Append(" : ").Append(numberTieLoss.ToString()).ToString();

            StatsWinLossNumberPercent = Utilities.Utilities.CalculateRatio(numberWin, numberLoss);

            StatsWinLossNumberPlayerPercent = Utilities.Utilities.CalculateRatio(numberPlayerWin,numberPlayerLoss);
            StatsWinLossNumberBankerPercent = Utilities.Utilities.CalculateRatio(numberBankerWin, numberBankerLoss);
            StatsWinLossNumberTiePercent = Utilities.Utilities.CalculateRatio(numberTieWin, numberTieLoss);

            // units:

            int unitPlayerWin = score.UnitPlayerWin;
            decimal netBankerWin = Math.Round((decimal)Constants.UnitBankerWinPayoff * score.UnitBankerWin, 2);
            int unitTieWin = score.UnitTieWin;

            decimal unitWin = unitPlayerWin + netBankerWin + unitTieWin;

            int unitPlayerLoss = score.UnitPlayerLoss;
            int unitBankerLoss = score.UnitBankerLoss;
            int unitTieLoss = score.UnitTieLoss;

            int unitLoss = unitPlayerLoss + unitBankerLoss + unitTieLoss;

            StatsWinLossUnitValue = new StringBuilder(unitWin.ToString()).Append(" : ").Append(unitLoss.ToString()).ToString();

            StatsWinLossUnitPlayerValue = new StringBuilder(unitPlayerWin.ToString()).Append(" : ").Append(unitPlayerLoss.ToString()).ToString();
            StatsWinLossUnitBankerValue = new StringBuilder(netBankerWin.ToString("f2")).Append(" : ").Append(unitBankerLoss.ToString()).ToString();
            StatsWinLossUnitTieValue = new StringBuilder(unitTieWin.ToString()).Append(" : ").Append(unitTieLoss.ToString()).ToString();

            StatsWinLossUnitPercent = Utilities.Utilities.CalculateRatio(unitWin, unitLoss);

            StatsWinLossUnitPlayerPercent = Utilities.Utilities.CalculateRatio(unitPlayerWin, unitPlayerLoss);
            StatsWinLossUnitBankerPercent = Utilities.Utilities.CalculateRatio(netBankerWin, unitBankerLoss);
            StatsWinLossUnitTiePercent = Utilities.Utilities.CalculateRatio(unitTieWin, unitTieLoss);

            // max:
            StatsMaxValue = new StringBuilder(score.MaxWin.ToString("f2")).Append(" : ").Append(score.MaxLoss.ToString("f2")).ToString();

            // ave:
            StatsAveValue = new StringBuilder(Utilities.Utilities.CalculateRatio(unitWin, numberWin)).Append(" : ").Append(Utilities.Utilities.CalculateRatio(unitLoss, numberLoss)).ToString();

            // total score:
            StatsTotalScoreValue = score.TotalScore.ToString("f2");

            // PA: Player's Advantage = total score / total units bet
            StatsPAValue = new StringBuilder(Utilities.Utilities.CalculateRatio(100 * score.TotalScore, score.UnitBet)).Append("%").ToString();
        }

        private void ResetStats()
        {
            StatsCoupsValue = "0";
            StatsPlayerValue = "0";
            StatsBankerValue = "0";
            StatsTieValue = "0";
            StatsPlayerPercent = "0";
            StatsBankerPercent = "0";
            StatsTiePercent = "0";
            StatsMaxValue = "0";
            StatsAveValue = "0";
            StatsTotalScoreValue = "0";
            StatsPAValue = "0";
        }

        private string _header;
        public string Header
        {
            get
            {
                return _header;
            }

            set
            {
                if (value != _header)
                {
                    _header = value;
                    NotifyPropertyChanged("Header");
                }
            }
        }

        internal void ClearItems()
        {
            ItemsCoup.Clear();
            ChartCoupScores.Clear();
        }
    }
}
