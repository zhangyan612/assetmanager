using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal? TotalReturn { get; set; }

        //public virtual ApplicationUser User { get; set; }
        public virtual ICollection<InvestmentAccount> Accounts { get; set; }

        /// <summary>
        /// total value of accounts
        /// </summary>
        public decimal TotalBalance
        {
            get
            {
                return Accounts == null ? 0 : (from i in Accounts select i.Balance).Sum();
            }
        }

        /// <summary>
        /// total value of stock holdings
        /// </summary>
        public decimal Exposure
        {
            get
            {
                return Accounts == null ? 0 : (from i in Accounts select i.Exposure).Sum();
            }
        }

        /// <summary>
        /// total cash that's available
        /// </summary>
        public decimal AvailableCash
        {
            get
            {
                return TotalBalance - Exposure;
            }
        }

        /// <summary>
        /// total return amount 
        /// </summary>
        public decimal ReturnAmount
        {
            get
            {
                return Accounts == null ? 0 : (from i in Accounts select i.ReturnAmount).Sum();
            }
        }

        /// <summary>
        /// Percentage of total return
        /// </summary>
        public decimal ReturnPercent
        {
            get
            {
                return ReturnAmount / TotalBalance;
            }
        }

        /// <summary>
        /// Strategy that an account is allocated to
        /// </summary>
        public decimal TotalAllocated
        {
            get
            {
                return Accounts == null ? 0 : (from i in Accounts select i.TotalAllocated).Sum();
            }
        }

        /// <summary>
        /// percentage of a portfolio that's traded based on strategy
        /// </summary>
        public decimal AllocatedPercent
        {
            get
            {
                return TotalAllocated / TotalBalance;
            }
        }
    }
}