using System;

namespace StrategySimulator.Model.Results
{
    public class ResultBaccaratShoe
    {
        public int IndexShoe { get; set; }

        public int NCoups { get; set; }
        public int WinPlayer { get; set; }
        public int WinBanker { get; set; }
        public int WinTie { get; set; }

        public ResultBaccaratShoe()
        {
            IndexShoe = 0;
            WinPlayer = 0;
            WinBanker = 0;
            WinTie = 0;
        }

        public string Description 
        {
            get
            {
                return String.Format("{0,5:D}{1,4:D}{2,4:D}{3,4:D}{4,4:D}",IndexShoe.ToString(),NCoups.ToString(),WinPlayer.ToString(),WinBanker.ToString(),WinTie.ToString());
            }
        }
    }
}
