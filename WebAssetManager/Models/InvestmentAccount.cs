using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAssetManager.Models
{
    public class InvestmentAccount
    {
        public int Id { get; set; }
        public string AccountName { get; set; }

        public string PortfolioId { get; set; }
        public AccountType Type { get; set; }
        public decimal Balance { get; set; }
        public CurrencySymbols Currency { get; set; }
        public string WebUrl { get; set; }

        // nullable check
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<Allocation> Allocations { get; set; }

        /// <summary>
        /// stock holdings which means risk exposure level
        /// </summary>
        public decimal Exposure
        {
            get
            {
                return Positions == null? 0 : (from i in Positions select i.TotalValue).Sum();
            }
        }

        /// <summary>
        /// account cash portion
        /// </summary>
        public decimal AvailableCash
        {
            get
            {
                return Balance - Exposure;
            }
        }

        /// <summary>
        /// money made in the account
        /// </summary>
        public decimal ReturnAmount
        {
            get
            {
                return Positions == null ? 0 : (from i in Positions select i.CurrentGain).Sum();
            }
        }
        /// <summary>
        /// percentage of return
        /// </summary>
        public decimal ReturnPercent
        {
            get
            {
                return ReturnAmount / Balance;
            }
        }

        public decimal TotalAllocated
        {
            get
            {
                return Allocations == null ? 0 : (from i in Allocations select i.Amount).Sum();
            }
        }

        public decimal AllocatedPercent
        {
            get
            {
                return TotalAllocated / Balance;
            }
        }


        /// <summary>
        /// if necessary for login
        /// </summary>
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual Portfolio Portfolio { get; set; }

        public string UserId { get; set; }
    }

    public enum AccountType
    {
        /// <summary>
        /// broker account with ability to invest
        /// </summary>
        Broker,
        /// <summary>
        /// Cash saved in bank
        /// </summary>
        Bank,
        /// <summary>
        /// holdings in specific mutual fund or ETF
        /// </summary>
        Fund,
        /// <summary>
        /// holding in IRA Account
        /// </summary>
        IRA,
        /// <summary>
        /// other cash/liqudity asset
        /// </summary>
        Cash,
    }

    public enum CurrencySymbols
    {
        [Display(Name = "US Dollar")]
        USDollar,
        [Display(Name = "Euro")]
        EUR,
        [Display(Name = "Chinese Yuan")]
        CNY
    }
}