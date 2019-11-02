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
    public class ReportOnPurchaseRepository
    {
        public DataTable Search(Purchase purchase)
        {

            //Connection
            string connectionString = @"Server=DESKTOP-CR4IGJV; Database=SMS_RAMPAGE; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT Product.Code,Product.Name,Category.Name As Category, SUM(Purchase_Details.Quantity)-(SELECT SUM(Quantity) FROM Sales_Details WHERE Purchase_Details.Product_Id=Sales_Details.Product_Id GROUP BY Sales_Details.Product_Id) AS Available_Qty,
(SUM(Purchase_Details.Quantity)-(SELECT SUM(Quantity) FROM Sales_Details WHERE Purchase_Details.Product_Id=Sales_Details.Product_Id GROUP BY Sales_Details.Product_Id))* SUM(Purchase_Details.Unit_Price)/COUNT(*)  AS CP,
(SUM(Purchase_Details.Quantity)-(SELECT SUM(Quantity) FROM Sales_Details WHERE Purchase_Details.Product_Id=Sales_Details.Product_Id GROUP BY Sales_Details.Product_Id))* SUM(Purchase_Details.MRP)/COUNT(*)  AS MRP,
(SUM(Purchase_Details.Quantity)-(SELECT SUM(Quantity) FROM Sales_Details WHERE Purchase_Details.Product_Id=Sales_Details.Product_Id GROUP BY Sales_Details.Product_Id))* SUM(Purchase_Details.MRP)/COUNT(*)-(SUM(Purchase_Details.Quantity)-(SELECT SUM(Quantity) FROM Sales_Details WHERE Purchase_Details.Product_Id=Sales_Details.Product_Id GROUP BY Sales_Details.Product_Id))* SUM(Purchase_Details.Unit_Price)/COUNT(*) AS Profit
FROM Purchase_Details
LEFT JOIN Product ON Purchase_Details.Product_Id=Product.Id
LEFT JOIN Category ON Product.Category_Id=Category.Id
LEFT JOIN Purchase ON Purchase_Details.Purchase_Id=Purchase.Id 
WHERE Purchase.Date1 >='"+purchase.Date1+"' and Purchase.Date1<='"+purchase.Date2+"' GROUP BY Purchase_Details.Product_Id,Product.Name,Product.Code, Category.Name";
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
