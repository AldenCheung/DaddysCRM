using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaddysCRM.Model
{
   public class PurchaseRecord
    {
       public int ID { get; set; }
       public string Goods { get; set; }
       public int GoodsID { get; set; }
       public double Count { get; set; }
       public double Price { get; set; }
       public DateTime BuyDate { get; set; }
       public int BuyYear { get; set; }
       public int CustomerID { get; set; }
       public double TotalPrice { get; set; }
       public int PayStatus { get; set; } //1='已结清' 0='赊账'
       public double DisCount { get; set; }
    }
}
