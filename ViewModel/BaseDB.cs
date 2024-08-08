using Model;
using System.Data.Sql;
using Model;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System;

namespace ViewModel
{
    public abstract class BaseDB
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\OneDrive\DSH\Doron\sources\repos\MiniProject\ViewModel\MiniProj.mdf;Integrated Security=True";
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataReader reader;

        protected abstract BaseEntity newEntity();
        public  abstract void CreateModel(BaseEntity entity);

        

        public BaseDB()
        {            
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = this.connection;

        }
        protected List <BaseEntity> Select()
        {
            List<BaseEntity> list = new List<BaseEntity>(); 
            try
            {
                command.Connection = connection;
                // command.CommandText = SqlStr;
                connection.Open();
                reader = command.ExecuteReader();
                BaseEntity entity = new BaseEntity();

                while(reader.Read())
                {
                    entity = newEntity();
                    this.CreateModel(entity);
                    list.Add(entity);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL" + command.CommandText);
            }
            finally 
            { 
                if (reader != null) reader.Close();
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
            return list;
        }

        
    }
}