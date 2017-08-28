using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAssetManager.Models
{
    public class Allocation
    {
        public int Id { get; set; }
        public int StrategyId { get; set; }
        public int AccountId { get; set; }

        public decimal Amount { get; set; }

        public virtual Strategy Strategy { get; set; }
        public virtual InvestmentAccount Account { get; set; }

    }
}