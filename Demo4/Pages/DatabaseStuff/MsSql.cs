using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Pages.DatabaseStuff
{
    public class MsSql : BaseSql<AliGoods>, IDisposable
    {
        #region Queries and Connection strings
        private readonly string localconnection = "Server=(localdb)\\MSSQLLocalDB;Database=AliGoods;Trusted_Connection=True;";
        SqlConnection connection;
        private readonly string amazonconnectionstring = "Server=alitestdb.c0i3it1m9rox.us-east-2.rds.amazonaws.com;Database=AliGoods;User Id=devmaster;pwd=Gavras123321;";
        #region Products table Queries
        private readonly string addproductquery = "Insert into aliGoods(ProductPrice,ProductName) values (@price,@name)";
        private readonly string addtestresultquery = "Insert into TestResults(TestName,TestRunningTime,TestResult,TestErrors) Values(@name,@time,@result,@errors)";
        private readonly string getallaligoods = "select * from AliGoods";
        private readonly string getalltestresults = "select * from Testresults";
        private readonly string clearquery = "Delete AliGoods where id between 1 and 1000";
        #endregion
        #region TestResult table Queries
        private readonly string addfailedtestresultquery = "Insert into TestResults Values (@Testrunnigtime,@IsRunned,@TestName,@TestResult,@ErrorMessage)";
        private readonly string addpassedtestrusultquery = "Insert into TestResults Values ('@Testrunnigtime',@IsRunned,'@TestName',@TestResult)";
        private readonly string addrangetestresultsquery = "";
        private readonly string deletetestresultquery = "";
        #endregion
        #endregion
        #region MsSql methods for communication with database
        public void Add(AliGoods product)
        {
            AliGoods localali = product;
            SqlParameter priceparam = new SqlParameter("@price", localali.Price);
            SqlParameter nameparam = new SqlParameter("@name", localali.Name);
            SqlCommand isertcommand = new SqlCommand(addproductquery, connection);
            isertcommand.Parameters.Add(priceparam);
            isertcommand.Parameters.Add(nameparam);
            isertcommand.ExecuteNonQuery();            
        }
        public void Add(TestResults testresults)
        {
            TestResults localtestresult = testresults;
            SqlParameter resultparam = new SqlParameter("@result", testresults.TestResult);
            SqlParameter nameparam = new SqlParameter("@name", testresults.TestName);
            SqlParameter errormessageparam = new SqlParameter("@errors", testresults.TestErrorMessage);
            SqlParameter testtimeparam = new SqlParameter("@time", testresults.TestRunnigTime);
            SqlCommand isertcommand = new SqlCommand(addtestresultquery, connection);
            isertcommand.Parameters.AddRange(new SqlParameter[] {resultparam,nameparam,errormessageparam,testtimeparam });
            isertcommand.ExecuteNonQuery();
        }

        public void AddRange(AliGoods[] arr)
        {
            AliGoods[] localali = arr;
            for (int i = 0; i < arr.Length; i++)
                Add(arr[i]);
        }
        public void AddRange(TestResults[] arr)
        {
            TestResults[] localali = arr;
            for (int i = 0; i < arr.Length; i++)
                Add(arr[i]);
        }

        public void Delete(int id,string TableName)
        {
            string name = TableName.ToLower();
            if (name == "aligoods") {
                string deletequery = $"Delete AliGoods where id = {id} ";
                SqlCommand deletecommand = new SqlCommand(deletequery, connection);
                deletecommand.ExecuteNonQuery();
            }
            else if(name == "testresults")
            {
                string deletequery = $"Delete testresults where id = {id} ";
                SqlCommand deletecommand = new SqlCommand(deletequery, connection);
                deletecommand.ExecuteNonQuery();
            }
            else
                throw new Exception("There is no such table, friend!!!");
        }

        public ArrayList GetAll(string table)
        {
            string name = table.ToLower();
            if (name == "aligoods")
            {
                ArrayList array = new ArrayList();
                SqlCommand getallcommand = new SqlCommand(getallaligoods, connection);
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
            else if(name == "testresults")
            {
                ArrayList array = new ArrayList();
                SqlCommand getallcommand = new SqlCommand(getalltestresults, connection);
                SqlDataReader reader = getallcommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TestResults local = new TestResults();
                        local.Id = reader.GetInt32(0);
                        local.TestName = reader.GetString(1);
                        local.TestResult = reader.GetString(2);
                        local.TestErrorMessage = reader.GetString(3);
                        local.TestRunnigTime = reader.GetString(4);
                        array.Add(local);
                    }
                    reader.Close();
                }
                return array;
            }
            else
            {
                return new ArrayList() { "Wrong table name" };
            }
        }
        public void ClearTable(string tabletame)
        {

            string name = tabletame.ToLower();
            if (name == "aligoods")
            {
                string query = "Delete aligoods where id between 0 and 1000";
                SqlCommand command = new SqlCommand(query,connection);
                command.ExecuteNonQuery();
            }
            else if (name == "testresults")
            {
                string query = "Delete testresults where id between 0 and 1000";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            else
                throw new Exception("There is no such table, RETARD!!!");
            SqlCommand clearcommand = new SqlCommand(clearquery,connection);
            clearcommand.ExecuteNonQuery();
        }
        public void CloseAllConnections()
        {
            this.Dispose();
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
