﻿using System;
using System.Collections.Generic;
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