using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Pages.DatabaseStuff
{
    public class MsSql : BaseSql<AliGoods>, IDisposable
    {
        #region Queries and Connection string
        SqlConnection connection;
        private readonly string amazonconnectionstring = "Server=alitestdb.c0i3it1m9rox.us-east-2.rds.amazonaws.com;Database=AliGoods;User Id=devmaster;pwd=Gavras123321;";
        #region Products table Queries
        private readonly string addproductquery = "Insert into aliGoods(ProductPrice,ProductName,Orders) values (@price,@name,@orders)";
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
        /// <summary>
        /// <para>This method returns a single object from any table (valid)</para>
        /// <para>as an ArrayList collection where it is contained</para>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public ArrayList GetOne(int id, string tablename)
        {
            string name = tablename.ToLower();
            if (id > 0 && name == "aligoods")
            {
                ArrayList array = new ArrayList();
                AliGoods local = new AliGoods();
                SqlCommand command = new SqlCommand($"Select * from AliGoods where id = {id}", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        local.Id = reader.GetInt32(0);
                        local.Name = reader.GetString(1);
                        local.Price = reader.GetDecimal(2);
                        local.Orders = reader.GetInt32(3);
                    }
                }
                array.Add(local);
                return array;
            }
            else if (id > 0 && name == "testresults")
            {
                ArrayList array = new ArrayList();
                TestResults local = new TestResults();
                SqlCommand command = new SqlCommand($"Select * from TestResults where id = {id}", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        local.Id = reader.GetInt32(0);
                        local.TestName = reader.GetString(1);
                        local.TestResult = reader.GetString(2);
                        local.TestErrorMessage = reader.GetString(3);
                        local.TestRunnigTime = reader.GetString(4);
                    }
                }
                array.Add(local);
                return array;
            }
            else
                throw new Exception("Wrong id or table name!");
        }
        /// <summary>
        /// <para>This method adds the object (AliGoods) passed as parameters to the valid table (AliGoods)</para>
        /// </summary>
        /// <param name="product"></param>
        public void Add(AliGoods product)
        {
            AliGoods localali = product;
            SqlParameter priceparam = new SqlParameter("@price", localali.Price);
            SqlParameter nameparam = new SqlParameter("@name", localali.Name);
            SqlParameter ordersparameter = new SqlParameter("@orders", localali.Orders);
            SqlCommand isertcommand = new SqlCommand(addproductquery, connection);
            isertcommand.Parameters.Add(priceparam);
            isertcommand.Parameters.Add(nameparam);
            isertcommand.Parameters.Add(ordersparameter);
            isertcommand.ExecuteNonQuery();            
        }
        /// <summary>
        /// <para>This method adds the object (TestResult) passed as parameters to the valid table (TestResults)</para>
        /// </summary>
        /// <param name="product"></param>
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
        /// <summary>
        /// Using this method, you can add an array of objects (AliGoods) to an existing table.
        /// </summary>
        /// <param name="arr"></param>
        public void AddRange(AliGoods[] arr)
        {
            AliGoods[] localali = arr;
            for (int i = 0; i < arr.Length; i++)
                Add(arr[i]);
        }
        /// <summary>
        /// Using this method, you can add an array of objects (TestResults) to an existing table.
        /// </summary>
        /// <param name="arr"></param>
        public void AddRange(TestResults[] arr)
        {
            TestResults[] localali = arr;
            for (int i = 0; i < arr.Length; i++)
                Add(arr[i]);
        }
        /// <summary>
        /// This method deletes an object in any table (VALID) using ID and name of the table (where u want to delete)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="TableName"></param>
        public void Delete(int id,string TableName)
        {
            string name = TableName.ToLower();
            if (id > 0 && name == "aligoods") {
                string deletequery = $"Delete AliGoods where id = {id} ";
                SqlCommand deletecommand = new SqlCommand(deletequery, connection);
                deletecommand.ExecuteNonQuery();
            }
            else if(id > 0 && name == "testresults")
            {
                string deletequery = $"Delete testresults where id = {id} ";
                SqlCommand deletecommand = new SqlCommand(deletequery, connection);
                deletecommand.ExecuteNonQuery();
            }
            else
                throw new Exception("There is no such table, friend!!!");
        }
        /// <summary>
        /// This method returns u an array with needed data, according to the param (NAME OF THE TABLE)
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
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
                        local.Orders = reader.GetInt32(3);
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
                throw new Exception("Wrong id or table name!");
        }
        /// <summary>
        /// <para>Using this method u can clear the table (Needed when you created a lot of trash there )</para>
        /// <para>Just send in param Name of the table, where u want to make clear</para>
        /// </summary>
        /// <param name="tabletame"></param>
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
            
        }
        public void CloseAllConnections()
        {
            this.Dispose();
        }

        #endregion
        #region Constructor and Disponse
        /// <summary>
        /// Closes all connections to database
        /// </summary>
        public void Dispose()
        {
            connection.Close();
        }
        /// <summary>
        /// Just call me. No extra actions!!!
        /// </summary>
        public MsSql()
        {
            connection = new SqlConnection();
            connection.ConnectionString = amazonconnectionstring;
            connection.Open();
        }
        #endregion
    }
}
