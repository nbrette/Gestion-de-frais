using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_SQL
{
    class Demande
    {
        private List<FraisForfaitaire> fraisForfaitaire;
        private List<HorsForfait> fraisHorsForfait;
        private DateTime date;
        private int nbrJustificatif;
        private string etat;
        private int code;

        public List<FraisForfaitaire> fraisF
        {
            get { return fraisForfaitaire; }
            set { fraisForfaitaire = value; }
        }

        public List<HorsForfait> fraisHF
        {
            get { return fraisHorsForfait; }
            set { fraisHorsForfait = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Etat
        {
            get { return etat; }
            set { etat = value; }
        }

        public int Code
        {
            get { return code; }
            set { code = value; }
        }
    }
}
