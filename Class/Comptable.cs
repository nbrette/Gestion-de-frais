using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_SQL
{
    class Comptable : User
    {
        public Comptable(int matricule, string nom, string prenom, string email, string mdp) : base(matricule,nom,prenom,email,mdp)
        {
            
        }
    }
}
