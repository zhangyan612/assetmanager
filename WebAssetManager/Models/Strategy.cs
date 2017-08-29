using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAssetManager.Models
{
    public class Strategy
    {
        public int StrategyId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public StrategySource Source { get; set; }
        public bool? RequireLogin { get; set; }
        public string LoginUserName { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<Trade> HistoryTrades { get; set; }

        //In case needed by strategy
        public decimal InitialBalance { get; set; }
        //public decimal CurrentBalance { get; set; }
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        public decimal TotalReturn { get; set; }

        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        public decimal ExpectedAnnualReturn { get; set; }
        public int RebalancePeriod { get; set; }

        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        public decimal MaxDrawDown { get; set; }
        public int StockHolding { get; set; }
        public DateTime BacktestStart { get; set; }
        public DateTime BacktestEnd { get; set; }
        public string Type { get; set; }
        //public bool Owner { get; set; }
        //public bool Tracking { get; set; }
    }


    public enum StrategySource
    {
        GuoRen,
        JoinQuant,
        RiceQuant,
        Quantopian,
        iwencai,
        XueQiu,
    }
}