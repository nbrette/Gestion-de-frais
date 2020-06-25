using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_SQL
{
    class TypeFraisForfaitaire
    {
        private int codeTypeFraisForfaitaire;
        private string libelle;
        private double montant;

        public int CodeTypeFrais
        {
            get { return codeTypeFraisForfaitaire; }
            set { codeTypeFraisForfaitaire = value; }
        }

        public string Libelle
        {
            get { return libelle; }
            set { libelle = value; }
        }

        public double Montant
        {
            get { return montant; }
            set { montant = value; }
        }
    }
}
