using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_SQL
{
    public class User
    {
        private int matricule;
        protected string nom;
        private string prenom;
        private string email;
        private string mdp;

        protected User(int matricule, string nom, string prenom, string email, string mdp)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.mdp = mdp;

        }

        protected User(int matricule, string nom, string prenom)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
        }

        public int Matricule
        {
            get { return matricule; }
        }

        public string Nom
        {
            get { return nom; }
        }
    }
}
