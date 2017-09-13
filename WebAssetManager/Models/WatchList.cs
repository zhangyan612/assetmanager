using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAssetManager.Models
{
    public class WatchList
    {
        public int Id { get; set; }
        public string StockName { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
                 
        public int AccountId { get; set; }


        public DateTime CreatedDate { get; set; }

        //private DateTime? dateCreated;
        //{
        //    get { return dateCreated ?? DateTime.Now; }
        //    set { dateCreated = value; }
        //}

        public string UserId { get; set; }

        public virtual InvestmentAccount Account { get; set; }

        public WatchList()
        {
            CreatedDate = DateTime.Now;
        }

    }
}