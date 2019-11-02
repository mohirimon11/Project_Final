    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBusinessManagementApp.Model
{
    public class Product
    {
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public int Reorder_Level { set; get; }
        public string Descriptions { set; get; }
        public int Category_Id { set; get; }
    }
}
