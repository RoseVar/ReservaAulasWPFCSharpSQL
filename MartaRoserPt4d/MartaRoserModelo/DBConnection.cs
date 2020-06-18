using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartaRoserModelo
{
    class DBConnection
    {
        //cal ficar com a Uid i Pwd un usuari donat d'alta a la base de dades amb permissos restringits
        private static string connectionString = "Server=localhost;Database=reserva_aulas;Uid=root;Pwd=;";

        private static DBConnection instance;
        private static MySqlConnection con = null;


        private DBConnection()
        {

        }
        public static DBConnection getInstance()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }
            return instance;
        }


        public MySqlConnection getConnection()
        {
            try
            {
                using (con = new MySqlConnection(connectionString)) ;


            }
            catch (MySqlException e)
            {

                Console.WriteLine("Error en la getConnection" + e.Message);
            }

            return con;

        }
    }
}
