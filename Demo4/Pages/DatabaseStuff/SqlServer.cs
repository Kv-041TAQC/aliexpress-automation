using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Pages.DatabaseStuff
{
    public class SqlServer<T> : BaseSql<AliGoods>
        where T : class
    {
        private readonly string localconnection = "Server=(localdb)\\MSSQLLocalDB;Database=AliGoods;Trusted_Connection=True;";
        private readonly string evgenserverconnection = "Server=KAMPLIPUTER\\MSSQLSERVEREVGEN;Database=AliGoods;Trusted_Connection=True;";
        public void Add(AliGoods x)
        {
         //addTest , addrangeTest, Delete test   
            AliGoods localali = x;
            string query = $"Insert into aliGoods(Price,Name) values (@price,@name)";
            using (SqlConnection connection = new SqlConnection(evgenserverconnection))
            {
                connection.Open();
                //SqlParameter idparam = new SqlParameter("@id", localali.Id);
                SqlParameter priceparam = new SqlParameter("@price", localali.Price);
                 SqlParameter nameparam = new SqlParameter("@name", localali.Name);
                SqlCommand isertcommand = new SqlCommand(query, connection);
                //isertcommand.Parameters.Add(idparam);
                isertcommand.Parameters.Add(priceparam);
                isertcommand.Parameters.Add(nameparam); 
                isertcommand.ExecuteNonQuery();

            }
        }

        public void AddRange(AliGoods[] arr)
        {
            AliGoods[] localali = arr;
            for (int i = 0; i < arr.Length; i++)
            {
                string query = $"Insert into aliGoods(Price,Name) values (@price,@name)";
                using (SqlConnection connection = new SqlConnection(evgenserverconnection))
                {
                    connection.Open();
                    //SqlParameter idparam = new SqlParameter("@id", localali[i].Id);
                    SqlParameter priceparam = new SqlParameter("@price", localali[i].Price);
                    SqlParameter nameparam = new SqlParameter("@name", localali[i].Name);
                    SqlCommand isertcommand = new SqlCommand(query, connection);
                   // isertcommand.Parameters.Add(idparam);
                    isertcommand.Parameters.Add(priceparam);
                    isertcommand.Parameters.Add(nameparam);
                    isertcommand.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            string deletequery = $"Delete aliGoods where id = {id} ";
            using (SqlConnection connection = new SqlConnection(evgenserverconnection))
            {
                connection.Open();
                SqlCommand deletecommand = new SqlCommand(deletequery,connection);
                deletecommand.ExecuteNonQuery();
            }
        }

        public List<AliGoods> GetAll()
        {
            string getall = "select * from AliGoods";
            List<AliGoods> array = new List<AliGoods>();
            using (SqlConnection connection = new SqlConnection(evgenserverconnection))
            {
                connection.Open();
                SqlCommand getallcommand = new SqlCommand(getall, connection);
                SqlDataReader reader = getallcommand.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        AliGoods local = new AliGoods();
                        local.Id = reader.GetInt32(0);
                        local.Price = reader.GetDecimal(1);
                        local.Name = reader.GetString(2);
                        array.Add(local);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return array;
        }

    }
}
