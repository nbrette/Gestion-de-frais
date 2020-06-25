using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_SQL
{
    class HorsForfait
    {
        private int num;
        private string libelle;
        private DateTime date;
        private bool accepte;
        private double montant;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">numero de ligne dans la bdd</param>
        /// <param name="libelle">nom de la dépense</param>
        /// <param name="date">date de ma dépense</param>
        /// <param name="accepte">si le remboursement a été accepté ou non</param>
        /// <param name="montant">montant des frais</param>
        public HorsForfait(int num, string libelle, DateTime date, bool accepte, double montant)
        {
            this.num = num;
            this.libelle = libelle;
            this.date = date;
            this.accepte = accepte;
            this.montant = montant;
        }

        #region get/set

        public int Code
        {
            get { return num; }
        }

        public string Libelle
        {
            get { return libelle; }
        }

        public DateTime Date
        {
            get { return date; }
        }

        public bool Accepte
        {
            get { return accepte; }
        }

        public double Montant
        {
            get { return montant; }
        }
        #endregion
    }
}
