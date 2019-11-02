using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using SmallBusinessManagementApp.Model;

namespace SmallBusinessManagementApp.Repository
{
    public class SalesRepository
    {
        public string connectionString = @"Server=DESKTOP-V33KTP1; Database=SMS_RAMPAGE; Integrated Security=True";

        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataReader reader;
        public string LoadQuantity(Sales sales)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"select Purchase.Quantity from Purchase left join Product on Purchase.Product_id = Product.Id where Product.Name = '" + sales.ProductName + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                availableQuantity = (reader["Quantity"]).ToString();
            }

            sqlConnection.Close();

            return availableQuantity;
        }

        public DataTable LoadCustomerLoad()
        {

            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Customer";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }
        public DataTable LoadCatagory()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Category";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }
        public DataTable LoadProduct(int Category_Id)
        {
            commandString = @"SELECT Product.Id,Product.Name FROM (Product LEFT JOIN Category ON Product.Category_Id = Category.Id)  WHERE Category.Id = " + Category_Id + " ";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlConnection.Close();
            dataAdapter.Fill(dataTable);

            return dataTable;

        }

        private string loyality;
        public string LoyaLityPoint(Customer customer)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"select  Loyality_Point from Customer where Name = '"+customer.Name+"'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                loyality = (reader["Loyality_Point"]).ToString();
            }

            sqlConnection.Close();

            return loyality;
        }
        string availableQuantity;
        public string LoadQuantity(Purchase purchase)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"select Purchase_Details.Quantity from Purchase_Details left join Product on Purchase_Details.Product_id = Product.Id where Product.Name = '" + purchase.ProductName + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                availableQuantity = (reader["Quantity"]).ToString();
            }

            sqlConnection.Close();

            return availableQuantity;
        }
        string MRP;

        public string LoadMRP(Purchase purchase)
        {
            sqlConnection =new SqlConnection(connectionString);
            commandString = @"select Purchase_Details.MRP from Purchase_Details left join Product on Purchase_Details.Product_id = Product.Id where Product.Name = '" + purchase.ProductName + "'";
            sqlCommand = new SqlCommand(commandString,sqlConnection);
            if (sqlConnection.State==ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                MRP = (reader["MRP"]).ToString();
            }
            sqlConnection.Close();
            return MRP;
        }

        public int PurchaseAdd(Sales sales)
        {
            sqlConnection = new SqlConnection(connectionString);
            //commandString =
            //    @"INSERT Purchase ( Date1, InvoiceNo, Supplier_id,category_id,Product_id,Manufacture_Date,Expire_Date,Quantity,Unit_Price,MRP,Remarks) VALUES ( '" +
            //    purchase.Date1 + "' , '" + purchase.InvoiceNo + "' , " + purchase.Supplier_id + " , " +
            //    purchase.category_id + " , " + purchase.Product_id + " , '" + purchase.Manufacture_Date + "'  , '" +
            //    purchase.Expire_Date + "'  ," + purchase.Quantity + ", " + purchase.Unit_Price + " , " + purchase.MRP +
            //    " ,'" + purchase.Remarks + "' )";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            int isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }




    }
}
