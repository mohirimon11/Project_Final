using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SmallBusinessManagementApp.Model;

namespace SmallBusinessManagementApp.Repository
{
    public class ReportOnSalesRepository
    {
        private SqlConnection sqlConnection;
        public DataTable Search(Sales sales)
        {

            //Connection
            sqlConnection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);

            //Command 
            string commandString = @"SELECT Category.Name AS Category, Product.Code ,Product.Name As Product, SUM(Sales_Details.Quantity) AS Sold_Qty,
SUM(Sales_Details.Quantity)*(SELECT SUM(Unit_Price) FROM Purchase_Details WHERE Purchase_Details.Product_Id=Sales_Details.Product_Id GROUP BY Purchase_Details.Product_Id)/COUNT(*) AS CP,
SUM(Sales_Details.Quantity)*(SELECT SUM(MRP) FROM Purchase_Details WHERE Purchase_Details.Product_Id=Sales_Details.Product_Id GROUP BY Purchase_Details.Product_Id)/COUNT(*) AS Sales_Price,
SUM(Sales_Details.Quantity)*(SELECT SUM(MRP) FROM Purchase_Details WHERE Purchase_Details.Product_Id=Sales_Details.Product_Id GROUP BY Purchase_Details.Product_Id)/COUNT(*)-SUM(Sales_Details.Quantity)*(SELECT SUM(Unit_Price) FROM Purchase_Details WHERE Purchase_Details.Product_Id=Sales_Details.Product_Id GROUP BY Purchase_Details.Product_Id)/COUNT(*) AS Profit
FROM Sales_Details LEFT JOIN Product ON Sales_Details.Product_Id=Product.Id
LEFT JOIN Category ON Product.Category_Id=Category.Id
LEFT JOIN Sales ON Sales_Details.Sales_Id=Sales.Id WHERE Sales.Date1>='"+sales.Date1+"' and Sales.Date1<='"+sales.Date2+"' Group by Sales_Details.Product_Id,Product.Name,Product.Code, Category.Name";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            //With DataAdapter
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();
            //return dataTable;
            return dataTable;

        }
    }
}
