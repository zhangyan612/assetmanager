using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAssetManager.Models
{
    public class InvestmentAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string AccountName { get; set; }
        public AccountType Type { get; set; }

        public virtual ICollection<Position> Positions { get; set; }


        /// <summary>
        /// if necessary for login
        /// </summary>
        public string UserName { get; set; }
        public string Password { get; set; }

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
}