using System;
using MySql.Data.MySqlClient;

namespace models
{
    public class UserFinderBD
    {
        private User user;
        private BankAccount bankAccount;
        public UserFinderBD()
        {
            
        }
        

        public User findUser(string email)
        {
            
            string sqlRead = "SELECT password,bankaccount_serial FROM user WHERE e-mail LIKE " + email;
            MySqlDataReader reader;
            MySqlConnection connection = Connection.conexion();
            connection.Open();

            try 
            {
                MySqlCommand command = new MySqlCommand(sqlRead,connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string password = reader.GetString(0);
                       int serial = int.Parse(reader.GetString(1));
                        float money = this.findBankAccount(serial);
                        bankAccount = new BankAccount(serial,money);

                        user = new User(email, password,bankAccount);
                    }
                    return user;
                }
                else
                {
                   return user = null;
                }
      
            }
            catch (MySqlException e)
            {
                return user = null;
            }
            finally
            {
                connection.Close();
            }

        }



        public float findBankAccount(int serial)
        {
            float password;
            string sqlRead = "SELECT money FROM bankaccount Where serial = " + serial;


            MySqlDataReader reader;
            MySqlConnection connection = Connection.conexion();
            connection.Open();

            try
            {
                MySqlCommand command = new MySqlCommand(sqlRead, connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return password = float.Parse(reader.GetString(0));
                    }
                }
                return password=0;
            }
            catch (MySqlException e)
            {

                return password = 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public User findUser(string email,string password)
        {
            string sqlRead = "SELECT bankaccount_serial FROM user WHERE `e-mail` LIKE '" + email+ "'and `password` LIKE '" + password+"'";
            MySqlDataReader reader;
            MySqlConnection connection = Connection.conexion();
            connection.Open();
            try
            {
                MySqlCommand command = new MySqlCommand(sqlRead, connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                    
                        int serial = int.Parse(reader.GetString(0));
                        float money = this.findBankAccount(serial);
                        this.bankAccount = new BankAccount(serial, money);

                        this.user = new User(email, password, this.bankAccount);
                    }
                return user;
                }
                else
                {
                    return user = null;
                }

            }
            catch (MySqlException e)
            {
                return user = null;
            }
            finally
            {
                connection.Close();
            }

        }

        public Boolean createUser(string user,string password,int serial)
        {
            Console.WriteLine("Llegue a 5");
            Boolean state;
            string sqlCreate = "INSERT INTO user (`e-mail`,`password`,`bankaccount_serial`) VALUES('" +user
                +"','"+password+"','"+serial+"') ";
            MySqlConnection connection = Connection.conexion();
            connection.Open();
            Console.WriteLine("Llegue a 4");
            try 
            {
                Boolean stateBankAccount = this.createBankAccount(serial,0.0,user);
                Console.WriteLine("Llegue a 3");
                if (stateBankAccount)
                {
                    MySqlCommand command = new MySqlCommand(sqlCreate, connection);
                    command.ExecuteNonQuery();
                    state = true;
                }
                else
                {
                    state = false;
                }
            }
            catch (MySqlException ex)
            {
                state = false;
            }
            return state;
        }

        private Boolean createBankAccount(int serial, double money,string user_email)
        {
            Boolean state;
            string sqlCreate = "INSERT INTO bankaccount (`serial`,`money`) VALUES('" + serial
                + "','" +money+"')";
            MySqlConnection connection = Connection.conexion();
            connection.Open();

            try
            {
                MySqlCommand command = new MySqlCommand(sqlCreate, connection);
                command.ExecuteNonQuery();
                state = true;
            }
            catch (MySqlException ex)
            {
                state = false;
            }
            return state;
        }

        public Boolean existBankAccount(int serial)
        {
            float password;
            Boolean state;
            string sqlRead = "SELECT money FROM bankaccount Where serial = " + serial;


            MySqlDataReader reader;
            MySqlConnection connection = Connection.conexion();
            connection.Open();

            try
            {
                MySqlCommand command = new MySqlCommand(sqlRead, connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        password = float.Parse(reader.GetString(0));
                    }
                     state = true;
                }
                else
                {
                     state = false;
                }
                return state;
            }
            catch (MySqlException e)
            {

                return state = false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean updateMount(int serial,double money)
        {
            Boolean state;
            string sqlCreate = "UPDATE bankaccount SET money='"+money+"'WHERE id='"+serial+"'";
            MySqlConnection connection = Connection.conexion();
            connection.Open();

            try
            {
                MySqlCommand command = new MySqlCommand(sqlCreate, connection);
                command.ExecuteNonQuery();
                state = true;
            }
            catch (MySqlException ex)
            {
                state = false;
            }
            return state;
        }

        public int getSerial()
        {
            return this.user.getBankAccountSerial();   
        }

        public double addAmount(double monto)
        {
            double finalMount;
            finalMount= this.user.getBankAccount().addMoney(monto);
            return finalMount;
        }

        public double reduceAmount(double monto)
        {
            double finalMount;
            finalMount = this.user.getBankAccount().reduceMoney(monto);
            return finalMount;
        }
    }
}
