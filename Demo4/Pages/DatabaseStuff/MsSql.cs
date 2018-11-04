using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Pages.DatabaseStuff
{
    public class MsSql : BaseSql<AliGoods>, IDisposable
    {
        #region Queries and Connection strings
        private readonly string localconnection = "Server=(localdb)\\MSSQLLocalDB;Database=AliGoods;Trusted_Connection=True;";
        SqlConnection connection;
        private readonly string amazonconnectionstring = "Server=alitestdb.c0i3it1m9rox.us-east-2.rds.amazonaws.com;Database=AliGoods;User Id=devmaster;pwd=Gavras123321";
        #region Products table Queries
        private readonly string addquery = $"Insert into aliGoods(ProductPrice,ProductName) values (@price,@name)";
        private readonly string addrangequery = $"Insert into aliGoods(ProductPrice,ProductName) values (@price,@name)";
        private readonly string getall = "select * from AliGoods";
        private readonly string clearquery = "Delete AliGoods where id between 1 and 1000";
        #endregion
        #region TestResult table Queries
        private readonly string addfailedtestresultquery = "Insert into TestResults Values (@Testrunnigtime,@IsRunned,@TestName,@TestResult,@ErrorMessage)";
        private readonly string addpassedtestrusultquery = "Insert into TestResults Values ('@Testrunnigtime',@IsRunned,'@TestName',@TestResult)";
        private readonly string addrangetestresultsquery = "";
        private readonly string deletetestresultquery = "";
        #endregion
        #endregion
        #region MsSql Products table methods
        public void Add(AliGoods product)
        {
            AliGoods localali = product;
            SqlParameter priceparam = new SqlParameter("@price", localali.Price);
            SqlParameter nameparam = new SqlParameter("@name", localali.Name);
            SqlCommand isertcommand = new SqlCommand(addquery, connection);
            isertcommand.Parameters.Add(priceparam);
            isertcommand.Parameters.Add(nameparam);
            isertcommand.ExecuteNonQuery();            
        }
        public void AddRange(AliGoods[] arr)
        {
            AliGoods[] localali = arr;
            for (int i = 0; i < arr.Length; i++)
                Add(arr[i]);
        }

        public void Delete(int id)
        {
            string deletequery = $"Delete AliGoods where id = {id} ";
            SqlCommand deletecommand = new SqlCommand(deletequery, connection);
            deletecommand.ExecuteNonQuery();
        }

        public List<AliGoods> GetAll()
        {
            List<AliGoods> array = new List<AliGoods>();
            SqlCommand getallcommand = new SqlCommand(getall, connection);
            SqlDataReader reader = getallcommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AliGoods local = new AliGoods();
                    local.Id = reader.GetInt32(0);
                    local.Price = reader.GetDecimal(1);
                    local.Name = reader.GetString(2);
                    array.Add(local);
                }
                reader.Close();
            }
            return array;
        }
        public void ClearTable()
        {
            SqlCommand clearcommand = new SqlCommand(clearquery,connection);
            clearcommand.ExecuteNonQuery();
        }
        public void CloseAllConnections()
        {
            this.Dispose();
        }

        #endregion
        #region MsSql TestResult table methods
        public void AddTestResult(TestResults test)
        {
            SqlCommand command = new SqlCommand(addpassedtestrusultquery, connection);
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@TestName", test.Name), new SqlParameter("@Testrunnigtime", test.Time), new SqlParameter("@TestResult", test.Result), new SqlParameter("@IsRunned", test.IsRunned) };            
            command.Parameters.AddRange(parameters);
            command.ExecuteNonQuery();
        }
        public void DeleteTestResult()
        {

        }
        public void AddRangeTestResult()
        {

        }
        #endregion
        #region Constructor and Destructor
        public void Dispose()
        {
            connection.Close();
        }

        public MsSql()
        {
            connection = new SqlConnection();
            connection.ConnectionString = amazonconnectionstring;
            connection.Open();
        }
        #endregion
    }
}
