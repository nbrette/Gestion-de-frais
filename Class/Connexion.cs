using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GSB_SQL
{
    class Connexion
    {

        /// <summary>
        /// Méthode qui établit une connexion à la base de données MySQL BDD_RH
        /// </summary>
        /// <returns>Un objet MySQLConnexion fermé</returns>
        public  static MySqlConnection connexion()
        {

            MySqlConnection connex = null;
            string chaineConnex = "server=localhost; user id=login; password=password; database=gsb; Convert Zero Datetime = True";
            try
            {
                connex = new MySqlConnection(chaineConnex);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la connexion à la base de données." + e.Message);
            }
            return connex;
        }
    }
}
