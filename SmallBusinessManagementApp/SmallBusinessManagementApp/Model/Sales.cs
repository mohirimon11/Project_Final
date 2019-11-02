using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBusinessManagementApp.Model
{
    public class Sales
    {
        public int Customer_Id { get; set; }
        public string Code { get; set; }
        public int Sales_Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date1 { get; set; }
        public double Loyality_Point { get; set; }
        
        public int Category_Id { get; set; }
        public int Product_Id { set; get; }
        public int Quantity { set; get; }
        public double MRP { set; get; }
        public string ProductName { get; set; }
        public double TotalMrp { get; set; }


        public DateTime Date2 { get; set; }
    }
}
