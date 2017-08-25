using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAssetManager.Models
{
    /// <summary>
    /// Existing asset in user's current portfolio
    /// summary>
    public class Portfolio
    {
        public string PortfolioId { get; set; }

        public string UserId { get; set; }
        public decimal TotalReturn { get; set; }

        public virtual ICollection<InvestmentAccount> Accounts { get; set; }

    }
}