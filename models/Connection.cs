using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace models
{
    class Connection
    {
        public static MySqlConnection conexion()
        {
            string servidor = "localhost";
            string bd = "proyecto";
            string usuario = "root";
            string password = "748596alex";

            string cadenaSQL = "Server=" + servidor + "; Database=" + bd + "; User Id= " + usuario + "; Password=" + password + "";


            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaSQL);
                return conexionBD;
            }
            catch(MySqlException ex){
                Console.WriteLine("Error"+ex.Message);
                return null;
            }
        }
    }
}
