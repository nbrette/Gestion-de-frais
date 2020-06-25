using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_SQL
{
    class FraisForfaitaire
    {
        private int quantite;
        private bool accepte;
        private TypeFraisForfaitaire typeFrais;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">numero de ligne dans la bdd</param>
        /// <param name="quantite">quantité de frais</param>
        /// <param name="accepte">si le remboursement a été accepté ou non</param>
        /// <param name="libelle">libelle de la dépense</param>
        /// <param name="montantUnitaire">montant unitaire du forfait lié à ce type de frais</param>
        public FraisForfaitaire(int quantite, bool accepte, TypeFraisForfaitaire typeFrais)
        {
            this.quantite = quantite;
            this.accepte = accepte;
            this.typeFrais = typeFrais;
        }

        public int Quantite
        {
            get { return quantite; }
        }

        public bool Accepte
        {
            get { return accepte; }
        }

        public TypeFraisForfaitaire TypeFrais
        {
            get { return typeFrais; }
        }

    }
}
