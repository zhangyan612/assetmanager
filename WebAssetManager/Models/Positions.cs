using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAssetManager.Models
{
    /// <summary>
    /// "证券代码",
    //"证券名称",
    //"证券数量",
    //"可卖数量",
    //"成本价",
    //"浮动盈亏",
    //"盈亏比例(%)",
    //"总库存（含超限库存）",
    //"总市值（含超限库存）",
    //"最新市值",
    //"当前价",
    //"股东代码"
    /// </summary>
    public class Position
    {
        public int AccountNumber { get; set; }
        public string StockName { get; set; }
        public string Symbol { get; set; }
        public int HoldingAmount { get; set; }
        public int SellableAmount { get; set; }
        public decimal CostPrice { get; set; }
        public decimal CurrentGain { get; set; }
        public decimal GainPercent { get; set; }
        public int TotalValue { get; set; }
        public decimal CurrentPrice { get; set; }

        public string FundNumber { get; set; }

    }
}