using System;
using System.Collections.Generic;
using System.Data.SqlClient;


class DBContent : IDisposable
{

   private string connectionString = "Server = localhost; DataBase = CustomerDB; Integrated Security=true;";
   
   private string commandString;
   private SqlConnection connection = null;
   private SqlCommand command = null;

   public DBContent(){
      connectSqlServer(connectionString);
   }
   private void connectSqlServer(string _connectionString){
       try{
       connection = new SqlConnection(_connectionString);
       connection.Open();
       }
       catch{
           connection = null;
       }
   }

   
   public List<Customer> GetCustomerList(){
    List<Customer> CustomerList = new List<Customer>();
    if(connection==null) return new List<Customer>();
     
    commandString = "Select * from Customer";

     using(command = new SqlCommand(commandString,connection))
     {
            
            using(SqlDataReader dataReader  = command.ExecuteReader())
            {
                Customer customer;
                while(dataReader.Read())
                {
                    customer = new Customer();
                    customer.ID = (int)dataReader[0];
                    customer.Name = (string)dataReader[1];
                    customer.SurName = (string)dataReader[2];
                    customer.Age = (int)dataReader[3];
                    customer.Payment = (decimal)dataReader[4];
                    customer.Adress = (string)dataReader[5];
                    CustomerList.Add(customer);
                  
                }
            }
 
       return CustomerList;

     }
     


   } 

   public Customer GetCustomer(int id){

      Customer customer = new Customer();
      if(connection==null) return customer;

      commandString = "select * from Customer where id = " +id;
        using(command = new SqlCommand(commandString,connection))
        {
          using(SqlDataReader dataReader = command.ExecuteReader())
          {
             if(dataReader.Read())
             {
                 customer.ID = (int)dataReader[0];
                 customer.Name = (string)dataReader[1];
                 customer.SurName  = (string)dataReader[2];
                 customer.Age = (int)dataReader[3];
                 customer.Payment = (decimal)dataReader[4];
                 customer.Adress = (string)dataReader[5];
             }

          }
        }

     return customer; 
   }
   
   public void UpdateCustomer(int ID,string Name,string SurName,int Age,decimal Payment,string Adress){
    if(connection == null) return;
        commandString = "Update Customer " + 
        "set Name = '" + Name + "', Surname = '"+ SurName+"',Age = "+ Age +" ,Payment = "+ Payment +" ,Adress = '"+ Adress +"' " +
        "where Id = "+ID; 

        using(command = new SqlCommand(commandString,connection))
        {
            command.ExecuteNonQuery();
        }

   }

   public void Dispose(){
       if(connection != null) connection.Dispose();
       if(command != null) command.Dispose();

       connection = null;
       command = null;
   }


}
