using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Pages.DatabaseStuff
{
    public class MsSql<T> : BaseSql<AliGoods>, IDisposable
        where T : class
    {
        #region Query and Connection strings
        private readonly string localconnection = "Server=(localdb)\\MSSQLLocalDB;Database=AliGoods;Trusted_Connection=True;";
        private readonly string evgenserverconnection = "Server=KAMPLIPUTER\\MSSQLSERVEREVGEN;Database=AliGoods;Trusted_Connection=True;";
        string addquery = $"Insert into aliGoods(Price,Name) values (@price,@name)";
        string addrangequery = $"Insert into aliGoods(Price,Name) values (@price,@name)";
        string getall = "select * from AliGoods";
        string clearquery = "Delete AliGoods where id between 1 and 1000";
        SqlConnection connection;
        #endregion
        #region MsSql Methods
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
        #region Constructor and Destructor
        public void Dispose()
        {
            connection.Close();
        }

        public MsSql()
        {
            connection = new SqlConnection();
            connection.ConnectionString = evgenserverconnection;
            connection.Open();
        }
        #endregion
        #endregion

    }
}
