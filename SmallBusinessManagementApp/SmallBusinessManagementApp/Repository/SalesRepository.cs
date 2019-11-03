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

        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataReader reader;
        //public string LoadQuantity(Sales sales)
        //{
        //    sqlConnection = new SqlConnection(connectionString);
        //    commandString = @"select Purchase.Quantity from Purchase left join Product on Purchase.Product_id = Product.Id where Product.Name = '" + sales.ProductName + "'";
        //    sqlCommand = new SqlCommand(commandString, sqlConnection);
        //    if (sqlConnection.State == ConnectionState.Closed)
        //    {
        //        sqlConnection.Open();
        //    }

        //    reader = sqlCommand.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        availableQuantity = (reader["Quantity"]).ToString();
        //    }

        //    sqlConnection.Close();

        //    return availableQuantity;
        //}

        public DataTable LoadCustomerLoad()
        {

            sqlConnection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
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
            sqlConnection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
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
            sqlConnection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
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
       
        string saleTotalQuantity;

        public string saleQuantity(Sales sales)
        {
            sqlConnection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
           // SELECT SUM(Quantity) AS TotalQuanity FROM Sales_Details where Product_Id = 5
            commandString = @"select sum(Sales_Details.Quantity) as saleTotal from Sales_Details left join Product on sales_Details.Product_Id = Product.Id where Name='"+sales.ProductName+"' ";
            sqlCommand = new SqlCommand(commandString,sqlConnection);
            if (sqlConnection.State==ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                saleTotalQuantity = (reader["saleTotal"].ToString());
            }
            sqlConnection.Close();
            return saleTotalQuantity;
        }

        public string purchaseTotalQuantity;
        public string PurchaseQuantity(Sales sales)
        {
            sqlConnection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
            // SELECT SUM(Quantity) AS TotalQuanity FROM Sales_Details where Product_Id = 5
            commandString = @"select sum(Purchase_Details.Quantity) as purchaseTotal from Purchase_Details left join Product on Purchase_Details.Product_Id = Product.Id where Name='" + sales.ProductName + "' ";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                purchaseTotalQuantity = (reader["purchaseTotal"].ToString());
            }
            sqlConnection.Close();
            return purchaseTotalQuantity;
        }
        string MRP;

        public string LoadMRP(Sales sales)
        {
            sqlConnection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
            commandString = @"select Purchase_Details.MRP from Purchase_Details left join Product on Purchase_Details.Product_id = Product.Id where Product.Name = '" + sales.ProductName + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            if (sqlConnection.State == ConnectionState.Closed)
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

       
        public int addSale(Sales sales)
        {
            int isExecuted = 0;

            commandString = "INSERT INTO Sales (Date1,Code,Customer_Id) VALUES ('"+sales.Date1+"','"+sales.Code+"',"+sales.Customer_Id+")";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }

        string SaleId;

        public string LoadSalesId(Sales sales)
        {
            sqlConnection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
            commandString = @"select Sales.Id from Sales left join Customer on Sales.Customer_Id = Customer.Id where Name='" + sales.CustomerName + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                SaleId = (reader["Id"]).ToString();
            }

            sqlConnection.Close();

            return SaleId;
        }
        public int Sell(Sales sales)
        {
            int isExecuted = 0;

            commandString = @"INSERT INTO Sales_Details (Sales_Id,Product_Id,Quantity,MRP) VALUES (" + sales.Sales_Id +"," +sales.Product_Id+ ","+sales.Quantity+","+sales.MRP+")";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }

        public int loyalityUpdate(Sales sales)
        {
            int isExecuted = 0;

            commandString = @"update Customer set Loyality_Point="+sales.Loyality_Point+" where Name = '"+sales.CustomerName+"' ";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }

        string SalesCode;

        public string salesCode(Sales sales)
        {
            sqlConnection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
            commandString = @"select Code from sales";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                SalesCode = (reader["Code"]).ToString();
            }
            sqlConnection.Close();
            return SalesCode;
        }
    }
}
