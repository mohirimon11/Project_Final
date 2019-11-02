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
        public DataTable Search(Sales sales)
        {

            //Connection
            string connectionString = @"Server=DESKTOP-CR4IGJV; Database=SMS_RAMPAGE; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

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

            //With DataAdapter
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //List<Customer> customers = new List<Customer>();

            //while (sqlDataReader.Read())
            //{
            //    Customer customer = new Customer();
            //    //District district = new District();
            //    customer.Id = Convert.ToInt32(sqlDataReader["Id"]);
            //    customer.Code = sqlDataReader["Code"].ToString();
            //    customer.Name = sqlDataReader["Name"].ToString();
            //    customer.Address = sqlDataReader["Address"].ToString();
            //    customer.Contact = sqlDataReader["Contact"].ToString();
            //    customer.District_Id =Convert.ToInt32(sqlDataReader["District_Id"]);
            //    // district.Name = sqlDataReader["District_Name"].ToString();

            //    customers.Add(customer);
            //}
            //if (sqlDataReader.NextResult())
            //{
            //    while (sqlDataReader.Read())
            //    {
            //        District district = new District();
            //        district.Name = sqlDataReader["District_Name"].ToString();
            //        //customers.Add(district);       
            //    }
            //}

            //if (dataTable.Rows.Count > 0)
            //{

            //    //showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //    //MessageBox.Show("No Data Found");
            //}

            //Close
            sqlConnection.Close();
            //return dataTable;
            return dataTable;

        }
    }
}
