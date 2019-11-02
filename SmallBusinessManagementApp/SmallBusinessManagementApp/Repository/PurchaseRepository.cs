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
    public class PurchaseRepository
    {
        public string connectionString = @"Server=DESKTOP-CR4IGJV; Database=SMS_RAMPAGE; Integrated Security=True";

        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataReader reader;

        public DataTable LoadCatagory()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Category";
            sqlCommand =new SqlCommand(commandString, sqlConnection);

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

        public DataTable LoadProducts()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Product";
            sqlCommand= new SqlCommand(commandString,sqlConnection);

            if (sqlConnection.State== ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
            
        }

        string PurchaseId;
        public string LoadPurchaseId(Purchase purchase)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"select Purchase.Id from Purchase left join Supplier on Purchase.Supplier_Id = Supplier.Id where Name='"+purchase.SupplierName+"'";
            sqlCommand=new SqlCommand(commandString,sqlConnection);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                PurchaseId = (reader["Id"]).ToString();
            }

            sqlConnection.Close();

            return PurchaseId;
        }

        string previousPrice;
        public string LoadPreviousPrice(Purchase purchase)
        {
            sqlConnection= new SqlConnection(connectionString);
            commandString = @"select Purchase_Details.Unit_Price from Purchase_Details left join Product on Purchase_Details.Product_id = Product.Id where Product.Name = '" + purchase.ProductName + "'";
            sqlCommand=new SqlCommand(commandString,sqlConnection);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                previousPrice = (reader["Unit_Price"]).ToString();
            }

            sqlConnection.Close();

            return previousPrice;
        }

        private string previousMrp;

        public string LoadPreviousMrp(Purchase purchase)
        {
            sqlConnection =new SqlConnection(connectionString);
            commandString = @"select Purchase_Details.MRP from Purchase_Details left join Product on Purchase_Details.Product_id = Product.Id where Product.Name = '" + purchase.ProductName + "'";
            sqlCommand =new SqlCommand(commandString,sqlConnection);
            if (sqlConnection.State==ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                previousMrp = (reader["MRP"]).ToString();
            }
            sqlConnection.Close();

            return previousMrp;
        }


        public DataTable LoadSupplier()
        {
            sqlConnection= new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Supplier";
            sqlCommand = new SqlCommand(commandString,sqlConnection);
            if (sqlConnection.State==ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            SqlDataAdapter dataAdapter= new SqlDataAdapter(sqlCommand);
            DataTable dataTable =new DataTable();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }

        string productCode;
        public string LoadProductCode(Product product)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT Code FROM Product WHERE Name='"+product.Name+"' ";
            sqlCommand = new SqlCommand(commandString,sqlConnection);
            if (sqlConnection.State==ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                productCode = (reader[0]).ToString();
            }
            sqlConnection.Close();

            return productCode;
        }

        public DataTable ProductLoad(int Category_Id)
        {
            commandString = @"SELECT Product.Id,Product.Name FROM (Product LEFT JOIN Category ON Product.Category_Id = Category.Id)  WHERE Category.Id = "+Category_Id+" ";
            sqlCommand = new SqlCommand(commandString,sqlConnection);

            if (sqlConnection.State== ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable= new DataTable();
            sqlConnection.Close();
            dataAdapter.Fill(dataTable);
            
            return dataTable;

        }

        public DataTable GetQuantity(Product product)
        {
            commandString = @"SELECT * FROM Items WHERE ID = " + product.Id + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

           SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }
        public int Sell(Purchase purchase)
        {
            int isExecuted = 0;

            commandString = "INSERT INTO Purchase_Details (Purchase_Id,Product_Id,Manufacture_Date,Expired_Date,Quantity,Unit_Price,MRP,Remarks) VALUES ("+purchase.Purchase_Id+","+purchase.Product_id+",'"+purchase.Manufacture_Date+"','"+purchase.Expire_Date+"',"+purchase.Quantity+","+purchase.Unit_Price+","+purchase.MRP+",'"+purchase.Remarks+"')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }
        public int addPurchase(Purchase purchase)
        {
            int isExecuted = 0;

            commandString = "INSERT INTO Purchase (Date1,Invoice_No,Supplier_Id,Code) VALUES ('"+purchase.Date1+"','"+purchase.InvoiceNo+"',"+purchase.Supplier_id+",'"+purchase.Code+"')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }

        public DataTable PurchaseLoad()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT  FROM Purchase";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }


    }
}
