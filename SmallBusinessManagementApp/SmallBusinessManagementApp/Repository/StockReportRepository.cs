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
    public class StockReportRepository
    {
        public DataTable Search(Purchase purchase,Product product,Category category)
        {

            //Connection
            string connectionString = @"Server=DESKTOP-CR4IGJV; Database=SMS_RAMPAGE; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT Product.Name,Product.Code,Category.Name As Category,Product.Reorder_Level,Purchase_Details.Expired_Date,ISNULL((SELECT SUM(Purchase_Details.Quantity) FROM Purchase_Details LEFT JOIN Purchase ON Purchase.Id=Purchase_Details.Id WHERE Purchase.Date1<'"+purchase.Date1+"')-(SELECT SUM(Quantity) FROM Sales_Details LEFT JOIN Sales ON Sales_Details.Sales_Id=Sales.Id WHERE Sales_Details.Product_Id=Purchase_Details.Product_Id AND Sales.Date1<'"+purchase.Date1+" ' GROUP BY Sales_Details.Product_Id ), 0) AS Opening_Balance,ISNULL(SUM(Purchase_Details.Quantity ),0)AS InQty,ISNULL((SELECT SUM(Quantity) FROM Sales_Details LEFT JOIN Sales ON Sales_Details.Sales_Id=Sales.Id WHERE Sales_Details.Product_Id=Purchase_Details.Product_Id AND Sales.Date1>='"+purchase.Date1+"' and Sales.Date1<='"+purchase.Date2+"' GROUP BY Sales_Details.Product_Id ),0) AS OUtQty, ISNULL(ISNULL((SELECT SUM(Purchase_Details.Quantity) FROM Purchase_Details LEFT JOIN Purchase ON Purchase.Id=Purchase_Details.Id WHERE Purchase.Date1<'"+purchase.Date1+"')-(SELECT SUM(Quantity) FROM Sales_Details LEFT JOIN Sales ON Sales_Details.Sales_Id=Sales.Id WHERE Sales_Details.Product_Id=Purchase_Details.Product_Id AND Sales.Date1<'"+purchase.Date1+"' GROUP BY Sales_Details.Product_Id ), 0)+ISNULL(SUM(Purchase_Details.Quantity ),0)-ISNULL((SELECT SUM(Quantity) FROM Sales_Details LEFT JOIN Sales ON Sales_Details.Sales_Id=Sales.Id WHERE Sales_Details.Product_Id=Purchase_Details.Product_Id AND Sales.Date1>='"+purchase.Date1+"' and Sales.Date1<='"+purchase.Date2+"' GROUP BY Sales_Details.Product_Id ),0),0) AS Closing_Balance FROM Purchase_Details LEFT JOIN Product ON Purchase_Details.Product_Id=Product.Id LEFT JOIN Category ON Product.Category_Id=Category.Id LEFT JOIN Purchase ON Purchase_Details.Purchase_Id=Purchase.Id WHERE Purchase.Date1 >='"+purchase.Date1+"' and Purchase.Date1<='"+purchase.Date2+"' And Category.Name='"+category.Name+"' OR Product.Name='"+product.Name+"' GROUP BY Purchase_Details.Product_Id,Product.Code, Category.Name,Product.Name,Product.Reorder_Level,Purchase_Details.Expired_Date";
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
