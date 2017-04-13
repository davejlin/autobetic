using StrategySimulator.Model;
using StrategySimulator.Model.Scores;
using StrategySimulator.Model.State;
using StrategySimulator.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Text;

namespace StrategySimulator.ViewModels
{
    public class GameBaccaratSessionViewModel : BaseViewModel
    {
        public ObservableCollection<ItemResultBaccaratShoeViewModel> ItemsShoe { get; private set; }
        public ObservableCollection<ChartDataPoint> ChartShoeScores { get; private set; }

        public Session session { get; private set; }

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

        private GameBaccaratSessionStateModel _gameBaccaratSessionStateModel;
        public GameBaccaratSessionStateModel GameBaccaratSessionStateModel
        {
            get { return _gameBaccaratSessionStateModel; }
            set
            {
                if (_gameBaccaratSessionStateModel != value)
                {
                    _gameBaccaratSessionStateModel = value;
                    NotifyPropertyChanged("GameBaccaratSessionStateModel");
                }
            }
        }

        public GameBaccaratSessionViewModel()
        {
            _gameBaccaratSessionStateModel = new GameBaccaratSessionStateModel();
            _gameBaccaratSessionStateModel.IsResultsVisible = true;
            _gameBaccaratSessionStateModel.IsProgressStatusVisible = false;

            session = new Session();
            ItemsShoe = new ObservableCollection<ItemResultBaccaratShoeViewModel>(); // need this here in order for mock data to show up in xaml
            ChartShoeScores = new ObservableCollection<ChartDataPoint>();
        }

        public void PlaySession()
        {
            session.shoeResults.Clear();
            session.PlaySession();
            ItemsShoe = new ObservableCollection<ItemResultBaccaratShoeViewModel>(session.ItemsShoe);
            LoadStatistics();
            LoadChart();
        }

        public void ShowResults()
        {
            _gameBaccaratSessionStateModel.IsResultsVisible = true;
        }

        public void HideResults()
        {
            _gameBaccaratSessionStateModel.IsResultsVisible = false;
        }

        public void ShowProgressStatus()
        {
            _gameBaccaratSessionStateModel.IsProgressStatusVisible = true;
        }

        public void HideProgressStatus()
        {
            _gameBaccaratSessionStateModel.IsProgressStatusVisible = false;
        }

        public void LoadStatistics()
        {
            ResetStats();

            LoadSessionStatistics();
            LoadWinLossStatistics();
        }

        private void LoadSessionStatistics()
        {
            StatsCoupsValue = session.NCoup.ToString();
            double coupsValue = Math.Round(Convert.ToDouble(StatsCoupsValue), 2);

            if (coupsValue > 0.0)
            {
                double shoesValueInv = 100.0 / coupsValue;

                StatsPlayerValue = session.NPlayer.ToString();
                StatsBankerValue = session.NBanker.ToString();
                StatsTieValue = session.NTie.ToString();

                double percent = Math.Round(shoesValueInv * Convert.ToDouble(session.NPlayer), 2);
                StatsPlayerPercent = new StringBuilder(percent.ToString("f2")).Append("%").ToString();

                percent = Math.Round(shoesValueInv * Convert.ToDouble(session.NBanker), 2);
                StatsBankerPercent = new StringBuilder(percent.ToString("f2")).Append("%").ToString();

                percent = Math.Round(shoesValueInv * Convert.ToDouble(session.NTie), 2);
                StatsTiePercent = new StringBuilder(percent.ToString("f2")).Append("%").ToString();
            }
        }

        private void LoadWinLossStatistics()
        {
            // number:

            ScoreBaccarat scoreSession = session.scoreSession;

            int numberPlayerWin = scoreSession.NumberPlayerWin;
            int numberBankerWin = scoreSession.NumberBankerWin;
            int numberTieWin = scoreSession.NumberTieWin;

            int numberWin = numberPlayerWin + numberBankerWin + numberTieWin;

            int numberPlayerLoss = scoreSession.NumberPlayerLoss;
            int numberBankerLoss = scoreSession.NumberBankerLoss;
            int numberTieLoss = scoreSession.NumberTieLoss;

            int numberLoss = numberPlayerLoss + numberBankerLoss + numberTieLoss;

            StatsWinLossNumberValue = new StringBuilder(numberWin.ToString()).Append(" : ").Append(numberLoss.ToString()).ToString();

            StatsWinLossNumberPlayerValue = new StringBuilder(numberPlayerWin.ToString()).Append(" : ").Append(numberPlayerLoss.ToString()).ToString();
            StatsWinLossNumberBankerValue = new StringBuilder(numberBankerWin.ToString()).Append(" : ").Append(numberBankerLoss.ToString()).ToString();
            StatsWinLossNumberTieValue = new StringBuilder(numberTieWin.ToString()).Append(" : ").Append(numberTieLoss.ToString()).ToString();

            StatsWinLossNumberPercent = Utilities.Utilities.CalculateRatio(numberWin, numberLoss);

            StatsWinLossNumberPlayerPercent = Utilities.Utilities.CalculateRatio(numberPlayerWin, numberPlayerLoss);
            StatsWinLossNumberBankerPercent = Utilities.Utilities.CalculateRatio(numberBankerWin, numberBankerLoss);
            StatsWinLossNumberTiePercent = Utilities.Utilities.CalculateRatio(numberTieWin, numberTieLoss);

            // units:

            int unitPlayerWin = scoreSession.UnitPlayerWin;
            decimal netBankerWin = Math.Round((decimal)Constants.UnitBankerWinPayoff * scoreSession.UnitBankerWin, 2);
            int unitTieWin = scoreSession.UnitTieWin;

            decimal unitWin = unitPlayerWin + netBankerWin + unitTieWin;

            int unitPlayerLoss = scoreSession.UnitPlayerLoss;
            int unitBankerLoss = scoreSession.UnitBankerLoss;
            int unitTieLoss = scoreSession.UnitTieLoss;

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
            StatsMaxValue = new StringBuilder(scoreSession.MaxWin.ToString("f2")).Append(" : ").Append(scoreSession.MaxLoss.ToString("f2")).ToString();

            // ave:
            StatsAveValue = new StringBuilder(Utilities.Utilities.CalculateRatio(unitWin,numberWin)).Append(" : ").Append(Utilities.Utilities.CalculateRatio(unitLoss,numberLoss)).ToString();

            // total score:
            StatsTotalScoreValue = scoreSession.TotalScore.ToString("f2");

            // PA: Player's Advantage = total score / total units bet
            StatsPAValue = new StringBuilder(Utilities.Utilities.CalculateRatio(100 * scoreSession.TotalScore,scoreSession.UnitBet)).Append("%").ToString();
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

        public void LoadChart()
        {
            ChartShoeScores = new ObservableCollection<ChartDataPoint>();
            foreach (ItemResultBaccaratShoeViewModel result in session.ItemsShoe)
            {
                ChartShoeScores.Add(new ChartDataPoint() { x = result.IndexShoe, y = Convert.ToDecimal(result.ScoreTotal) });
            }
        }

    }
}
