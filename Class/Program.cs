using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace GSB_SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            DAOFrais.ValiderFraiHorsForfait(16);
            Console.ReadLine();




        }
    }
}
