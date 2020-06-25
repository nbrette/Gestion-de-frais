using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GSB_SQL
{
    class DAOFrais
    {
        /// <summary>
        ///Execute la requete permettant de recupérer tous les champs de la table visiteur
        /// </summary>
        /// <param name="email">email du visiteur recherché</param>
        /// <returns>objet de type visiteur</returns>
        public static Visiteur GetVisiteurByEmail(string email)
        {
            Visiteur visiteur = null;
            try
            {
                MySqlConnection connexion = Connexion.connexion();
                connexion.Open();
                MySqlCommand cmdSelect = new MySqlCommand();
                cmdSelect.Connection = connexion;
                cmdSelect.CommandText = "SELECT * FROM visiteur WHERE VISITEUREmail =@email";
                cmdSelect.Parameters.AddWithValue("@email", email);
                MySqlDataReader drVisiteur = cmdSelect.ExecuteReader();
                if (drVisiteur.Read())
                {
                    int matricule = Convert.ToInt32(drVisiteur.GetValue(0));
                    
                    string nom = drVisiteur.GetValue(1).ToString();
                    string prenom = drVisiteur.GetValue(2).ToString();
                    string adresse = drVisiteur.GetValue(3).ToString();
                    string cp = drVisiteur.GetValue(4).ToString();
                    string ville = drVisiteur.GetValue(5).ToString();
                    string dateEmbauche = drVisiteur.GetValue(6).ToString();
                    string mail = drVisiteur.GetValue(7).ToString();
                    string mdp = drVisiteur.GetValue(8).ToString();

                    Visiteur visiteurReq = new Visiteur(matricule,nom,prenom,adresse,cp,ville,dateEmbauche,mail,mdp);
                    visiteur = visiteurReq;

                }
                drVisiteur.Close();
                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la recherche du visiteur dans la BD\n" + e.Message);
            }
            return visiteur;
        }

        /// <summary>
        /// Execute la requete permettant d'obtenir un comptable par son email
        /// </summary>
        /// <param name="email">email du comptable recherché</param>
        /// <returns>objet de type comptable vide si aucune correspondance</returns>
        public static Comptable GetComptableByEmail(string email)
        {
            Comptable compta = null;
            try
            {
                MySqlConnection connexion = Connexion.connexion();
                connexion.Open();
                MySqlCommand cmdSelect = new MySqlCommand();
                cmdSelect.Connection = connexion;
                cmdSelect.CommandText = "SELECT * FROM comptabilite WHERE COMPTAEmail =@email";
                cmdSelect.Parameters.AddWithValue("@email", email);
                MySqlDataReader drVisiteur = cmdSelect.ExecuteReader();
                if (drVisiteur.Read())
                {
                    int matricule = Convert.ToInt32(drVisiteur.GetValue(0));
                    string nom = drVisiteur.GetValue(1).ToString();
                    string prenom = drVisiteur.GetValue(2).ToString();
                    string mail = drVisiteur.GetValue(3).ToString();
                    string mdp = drVisiteur.GetValue(4).ToString();

                    Comptable comptaReq = new Comptable(matricule, nom, prenom, mail, mdp);
                    compta = comptaReq;

                }
                drVisiteur.Close();
                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la recherche du comptable dans la BD\n" + e.Message);
            }
            return compta;
        }

        /// <summary>
        /// Execute la requete permettant d'ajouter une déclaration
        /// </summary>
        /// <param name="matricule">matricule du visiteur qui déclare </param>
        /// <param name="date">date de la déclaration</param>
        /// <param name="nbrJustif">nombre de justificatif pris fournis</param>
        public static void AddDeclaration(int matricule, DateTime date, int nbrJustif)
        {

            try
            {
                MySqlConnection connexion = Connexion.connexion();
                connexion.Open();
                MySqlCommand cmdSelect = new MySqlCommand();
                cmdSelect.Connection = connexion;
                cmdSelect.CommandText = "INSERT INTO demanderemboursement (DEMANDEDate,DEMANDENbrJustificatif,ETATDEMANDECode,VISITEURMatricule) VALUES (@date, @nbrJustif, @etatdemandecode, @matricule)";

                cmdSelect.Parameters.AddWithValue("@date", date);
                cmdSelect.Parameters.AddWithValue("@nbrJustif", nbrJustif);
                cmdSelect.Parameters.AddWithValue("@etatdemandecode", "CL");
                cmdSelect.Parameters.AddWithValue("@matricule", matricule);
                MySqlDataReader drVisiteur = cmdSelect.ExecuteReader();

                connexion.Close();
            }


            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la recherche du visiteur dans la BD\n" + e.Message);
            }

        }

        /// <summary>
        /// Execute la requete permettant d'ajouter des frais forfaitaires
        /// </summary>
        /// <param name="demandecode">code de la demande à laquelle sont liés les frais</param>
        /// <param name="fraisforfaitairecode"></param>
        /// <param name="quantite"></param>
        /// <param name="fraisaccepte"></param>
        public static void AddFraisForfaitaire(int demandecode, int fraisforfaitairecode, int quantite, bool fraisaccepte)
        {

            try
            {
                MySqlConnection connexion = Connexion.connexion();
                connexion.Open();
                MySqlCommand cmdSelect = new MySqlCommand();
                cmdSelect.Connection = connexion;
                cmdSelect.CommandText = "INSERT INTO lignefraisforfaitaire (DEMANDECode, FRAISFORFAITAIRECode, LIGNEFFAccepte, LIGNEFFQuantite) VALUES (@demandecode, @fraisforfaitairecode, @fraisaccepte, @quantite)";

                cmdSelect.Parameters.AddWithValue("@demandecode", demandecode);
                cmdSelect.Parameters.AddWithValue("@fraisforfaitairecode", fraisforfaitairecode);
                cmdSelect.Parameters.AddWithValue("@fraisaccepte", fraisaccepte); ;
                cmdSelect.Parameters.AddWithValue("@quantite", quantite);
                MySqlDataReader drVisiteur = cmdSelect.ExecuteReader();

                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de l'insertion" + e.Message);
            }

        }

        /// <summary>
        /// Execute la requete pour ajouter des frais hors forfait
        /// </summary>
        /// <param name="demandecode">demande à la quelle sont liés les frais</param>
        /// <param name="libelle">libelle de frais</param>
        /// <param name="montant">cout des frais</param>
        /// <param name="date">date de la dépense</param>
        /// <param name="fraisaccepte">statut du remboursement des frais</param>
        public static void AddFraisHorsForfait(int demandecode, string libelle, double montant, DateTime date, bool fraisaccepte)
        {

            try
            {
                MySqlConnection connexion = Connexion.connexion();
                connexion.Open();
                MySqlCommand cmdSelect = new MySqlCommand();
                cmdSelect.Connection = connexion;
                cmdSelect.CommandText = "INSERT INTO lignefraishorsforfait (LIGNEHFLibelle, LIGNEHFMontant, LIGNEHFDate, LIGNEHFAccepte,DEMANDECode) VALUES (@libelle, @montant, @date, @fraisaccepte, @demandecode)";

                cmdSelect.Parameters.AddWithValue("@libelle", libelle);
                cmdSelect.Parameters.AddWithValue("@montant", montant);
                cmdSelect.Parameters.AddWithValue("@date", date); ;
                cmdSelect.Parameters.AddWithValue("@fraisaccepte", fraisaccepte);
                cmdSelect.Parameters.AddWithValue("@demandecode", demandecode);
                MySqlDataReader drVisiteur = cmdSelect.ExecuteReader();

                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de l'insertion" + e.Message);
            }

        }

        /// <summary>
        /// Recupere le code de la dernière demande ajoutée
        /// </summary>
        /// <returns>code de la derniere demande ajoutée</returns>
        public static int GetDerniereDemandeCode()
        {
            int codeDerniereDemande = 0;
            try
            {

                MySqlConnection connexion = Connexion.connexion();
                connexion.Open();
                MySqlCommand cmdSelect = new MySqlCommand();
                cmdSelect.Connection = connexion;
                cmdSelect.CommandText = "SELECT MAX(DEMANDECode) FROM demanderemboursement;";

                MySqlDataReader drVisiteur = cmdSelect.ExecuteReader();
                if (drVisiteur.Read())
                {
                    codeDerniereDemande = Convert.ToInt32(drVisiteur.GetValue(0));
                }

                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la recherche D\n" + e.Message);
            }
            return codeDerniereDemande;

        }

        /// <summary>
        /// Obtient toutes les demandes concernant un visiteur
        /// </summary>
        /// <param name="matricule">matrcicule du visiteur</param>
        /// <returns>liste de demande</returns>
        public static List<Demande> GetDemandeVisiteur(int matricule)
        {
            List<Demande> demandes = new List<Demande>();
            try
            {
                
                MySqlConnection connexion = Connexion.connexion();
                connexion.Open();
                MySqlCommand cmdSelect = new MySqlCommand();
                cmdSelect.Connection = connexion;
                cmdSelect.CommandText = "SELECT * FROM demanderemboursement WHERE VISITEURMatricule = @matricule;";

                cmdSelect.Parameters.AddWithValue("@matricule", matricule);

                MySqlDataReader drVisiteur =  cmdSelect.ExecuteReader();
                while (drVisiteur.Read())
                {
                    Demande demande = new Demande();
                    int code = Convert.ToInt32(drVisiteur.GetValue(0));
                    DateTime date = Convert.ToDateTime(drVisiteur.GetValue(1));
                    int nbrJustif = Convert.ToInt32(drVisiteur.GetValue(2));
                    string etatdemande = drVisiteur.GetValue(3).ToString();

                    demande.Date = date;
                    demande.Code = code;
                    demande.Etat = etatdemande;
                    
                    demandes.Add(demande);
                    
                }

                foreach (Demande demande in demandes)
                {
                    demande.fraisF = GetFraisForfaitaire(demande.Code);
                    demande.fraisHF = GetFraisHorsForfait(demande.Code);
                }




                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de l'insertion" + e.Message);
            }

            return demandes;

        }

        /// <summary>
        /// Obtient tous les frais forfaitaire pour une demande
        /// </summary>
        /// <param name="codeDeclaration"></param>
        /// <returns>une liste d'objet de type frais forfaitaire</returns>
        public static List<FraisForfaitaire> GetFraisForfaitaire(int codeDeclaration)
        {
            List<FraisForfaitaire> listFrais = new List<FraisForfaitaire>();
            try
            {

                MySqlConnection connexion = Connexion.connexion();
                connexion.Open();
                MySqlCommand cmdSelect = new MySqlCommand();
                cmdSelect.Connection = connexion;
                cmdSelect.CommandText = "SELECT FRAISFORFAITAIRECode, LIGNEFFAccepte, LIGNEFFQuantite FROM lignefraisforfaitaire WHERE DEMANDECode = @codeDeclaration";

                cmdSelect.Parameters.AddWithValue("@codeDeclaration", codeDeclaration);

                MySqlDataReader drVisiteur = cmdSelect.ExecuteReader();
                while (drVisiteur.Read())
                {
                    
                    int code = Convert.ToInt32(drVisiteur.GetValue(0));
                    bool accepte = Convert.ToBoolean(drVisiteur.GetValue(1));
                    int quantite = Convert.ToInt32(drVisiteur.GetValue(2));

                    TypeFraisForfaitaire typeFrais = GetTypeFraisForfaitaire(code);

                    FraisForfaitaire frais = new FraisForfaitaire(quantite, accepte,typeFrais);

                    listFrais.Add(frais);

                }

                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de l'insertion" + e.Message);
            }

            return listFrais;

        }

        /// <summary>
        /// Recupere le type d'une ligne de frais fortaire selon le code
        /// </summary>
        /// <param name="codeTypeFraisForfaitaire">code du type de frais</param>
        /// <returns>objet de type TypeFraisForfaitaire</returns>
        public static TypeFraisForfaitaire GetTypeFraisForfaitaire(int codeTypeFraisForfaitaire)
        {
            TypeFraisForfaitaire typeFrais = new TypeFraisForfaitaire();
            try
            {

                MySqlConnection connexion = Connexion.connexion();
                connexion.Open();
                MySqlCommand cmdSelect = new MySqlCommand();
                cmdSelect.Connection = connexion;
                cmdSelect.CommandText = "SELECT  * FROM fraisforfaitaire WHERE FRAISFORFAITAIRECode = @codeTypeFraisForfaitaire";

                cmdSelect.Parameters.AddWithValue("@codeTypeFraisForfaitaire", codeTypeFraisForfaitaire);

                MySqlDataReader drVisiteur = cmdSelect.ExecuteReader();
                if (drVisiteur.Read())
                {

                    int code = Convert.ToInt32(drVisiteur.GetValue(0));
                    string libelle = drVisiteur.GetValue(1).ToString();
                    double montant = Convert.ToDouble( drVisiteur.GetValue(2));
                    typeFrais.Libelle = libelle;
                    typeFrais.CodeTypeFrais = code;
                    typeFrais.Montant = montant;


                }

                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de l'insertion" + e.Message);
            }

            return typeFrais;

        }

        /// <summary>
        /// Recupere tous les frais hors forfait pour une demande
        /// </summary>
        /// <param name="codeDemande">code de la demande à laquelle sont liés les frais</param>
        /// <returns>une liste d'objet de type HorsForfait</returns>
        public static List<HorsForfait> GetFraisHorsForfait(int codeDemande)
        {
            List<HorsForfait> listFrais = new List<HorsForfait>();
            try
            {

                MySqlConnection connexion = Connexion.connexion();
                connexion.Open();
                MySqlCommand cmdSelect = new MySqlCommand();
                cmdSelect.Connection = connexion;
                cmdSelect.CommandText = "SELECT LIGNEHFNum, LIGNEHFLibelle, LIGNEHFMontant, LIGNEHFDate, LIGNEHFAccepte FROM lignefraishorsforfait WHERE DEMANDECode = @codeDemande";

                cmdSelect.Parameters.AddWithValue("@codeDemande", codeDemande);

                MySqlDataReader drVisiteur = cmdSelect.ExecuteReader();
                while (drVisiteur.Read())
                {

                    int code = Convert.ToInt32(drVisiteur.GetValue(0));
                    string libelle = drVisiteur.GetValue(1).ToString();
                    double montant = Convert.ToDouble(drVisiteur.GetValue(2));
                    DateTime date = drVisiteur.GetDateTime(3);
                    bool accepte = drVisiteur.GetBoolean(4);

                    HorsForfait horsForfait = new HorsForfait(code,libelle,date,accepte,montant);

                    listFrais.Add(horsForfait);

                }

                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de l'insertion" + e.Message);
            }

            return listFrais;

        }

        /// <summary>
        /// Obtient tous les visiteurs
        /// </summary>
        /// <returns>une liste d'objet de type visiteur. Chaque objet ne contient que nom/prenom et matricule</returns>
        public static List<Visiteur> GetTousLesVisiteurs()
        {
            List<Visiteur> listVisiteurs = new List<Visiteur>();

            try
            {

                MySqlConnection connexion = Connexion.connexion();
                connexion.Open();
                MySqlCommand cmdSelect = new MySqlCommand();
                cmdSelect.Connection = connexion;
                cmdSelect.CommandText = "SELECT VISITEURMatricule, VISITEURNom, VISITEURPrenom FROM visiteur ;";



                MySqlDataReader drVisiteur = cmdSelect.ExecuteReader();
                while (drVisiteur.Read())
                {

                    int matricule = Convert.ToInt32(drVisiteur.GetValue(0));
                    string nom = drVisiteur.GetValue(1).ToString();
                    string prenom = drVisiteur.GetValue(2).ToString();
                    Visiteur visiteur = new Visiteur(matricule, nom, prenom);
                    listVisiteurs.Add(visiteur);

                }

                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de l'insertion" + e.Message);
            }

            return listVisiteurs;
        }

        public static void ChangerStatutDeclaration(string codeEtat, int demandecode)
        {

            try
            {
                MySqlConnection connexion = Connexion.connexion();
                connexion.Open();
                MySqlCommand cmdSelect = new MySqlCommand();
                cmdSelect.Connection = connexion;
                cmdSelect.CommandText = "UPDATE demanderemboursement SET ETATDEMANDECode = @codeEtat WHERE DEMANDECOde = @codeDemande";

                cmdSelect.Parameters.AddWithValue("@codeEtat", codeEtat);
                cmdSelect.Parameters.AddWithValue("@codeDemande", demandecode);
                MySqlDataReader drVisiteur = cmdSelect.ExecuteReader();

                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de l'insertion" + e.Message);
            }

        }

        public static void ValiderFraisForfaitaire(int demandecode,int codeFrais)
        {

            try
            {
                MySqlConnection connexion = Connexion.connexion();
                connexion.Open();
                MySqlCommand cmdSelect = new MySqlCommand();
                cmdSelect.Connection = connexion;
                cmdSelect.CommandText = "UPDATE lignefraisforfaitaire SET LIGNEFFAccepte = true WHERE FRAISFORFAITAIRECode = @codeFrais AND DEMANDECode = @codeDemande ;";

                cmdSelect.Parameters.AddWithValue("@codeFrais", codeFrais);
                cmdSelect.Parameters.AddWithValue("@codeDemande", demandecode);
                MySqlDataReader drVisiteur = cmdSelect.ExecuteReader();

                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de l'insertion" + e.Message);
            }

        }

        public static void ValiderFraiHorsForfait(int hfnum)
        {

            try
            {
                MySqlConnection connexion = Connexion.connexion();
                connexion.Open();
                MySqlCommand cmdSelect = new MySqlCommand();
                cmdSelect.Connection = connexion;
                cmdSelect.CommandText = "UPDATE lignefraishorsforfait SET LIGNEHFAccepte = true WHERE LIGNEHFNum = @hfnum ;";

                cmdSelect.Parameters.AddWithValue("@hfnum", hfnum);
                MySqlDataReader drVisiteur = cmdSelect.ExecuteReader();

                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de l'insertion" + e.Message);
            }

        }

    }

    
}

