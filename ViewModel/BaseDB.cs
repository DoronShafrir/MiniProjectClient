using Model;
using System.Data.Sql;
using Model;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System;
using System.CodeDom.Compiler;

namespace ViewModel
{
    public abstract class BaseDB
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\OneDrive\DSH\Doron\sources\repos\MiniProject\ViewModel\MiniProj.mdf;Integrated Security=True";
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataReader reader;

        public abstract BaseEntity newEntity();
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
                    CreateModel(entity);
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
        public int SaveChanges(string sqlStr)
        {
           
            int Id_Executed =0 ;
            SqlCommand cmd =new SqlCommand();
            try
            {                
                cmd.Connection = this.connection;
                this.connection.Open();    
                cmd.CommandText = sqlStr;
                
                var temp1 = cmd.ExecuteScalar();
                if (temp1 != "" && temp1 != null) Id_Executed = (int)temp1;

                command.CommandText = "Select @@Identity";
                var temp = command.ExecuteScalar().ToString();
                if (temp != "" && temp != null) Id_Executed = int.Parse(temp);
                
                
            }
            catch(Exception e)
            {

            }
            finally
            {

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return Id_Executed;
        }

        
    }
}