using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_SQL
{
    public class Visiteur : User
    {
        private string adresse;
        private string cp;
        private string ville;
        private string dateEmbauche;


        public Visiteur(int matricule, string nom, string prenom, string adresse, string cp, string ville, string dateEmbauche, string email, string mdp) 
            : base(matricule, nom, prenom, email, mdp)
        {
            this.adresse = adresse;
            this.cp = cp;
            this.ville = ville;
            this.dateEmbauche = dateEmbauche;
        }

        public Visiteur(int matricule, string nom, string prenom):base(matricule, nom, prenom)
        {

        }

        #region get/set



        public string Adresse
        {
            get { return adresse; }
        }

        public string Cp
        {
            get { return cp; }
        }
        public string Ville
        {
            get { return ville; }
        }
        public string DateEmbauche
        {
            get { return dateEmbauche; }
        }


        #endregion






    }
}
