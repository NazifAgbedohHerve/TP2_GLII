using System;

namespace TP2_GLII.Model
{
    public class TxAbonnement : Transaction
    {
        private DateTime valideDepuis;
        private DateTime valideJusqua;
        private bool renouvellementAuto;

        private AbonnementPlan abonnementPlan;
        private Paiement[] génère;
        

        public DateTime ValideDepuis { get => valideDepuis; set => valideDepuis = value; }
        public DateTime ValideJusqua { get => valideJusqua; set => valideJusqua = value; }
        public bool RenouvellementAuto { get => renouvellementAuto; set => renouvellementAuto = value; }
        public AbonnementPlan AbonnementPlan { get => abonnementPlan; set => abonnementPlan = value; }
        public Paiement[] Génère { get => génère; set => génère = value; }
        public string Statut { get; set; } = "Actif"; // Actif | Suspendu | Expiré

        public string TypeAbonnement
        {
            get
            {
                if (AbonnementPlan != null)
                    return AbonnementPlan.Nom; 
                return "Non spécifié";
            }
        }

        public override string ResumeTransaction()
        {
            string plan = AbonnementPlan?.Nom ?? "Inconnu";
            return $"Abonnement : {plan} (valide du {ValideDepuis:yyyy-MM-dd} au {ValideJusqua:yyyy-MM-dd})";
        }


        // Vérifie la règle UML : pas de chevauchement d’abonnement
        public bool Chevauche(TxAbonnement autre)
        {
            return !(ValideJusqua <= autre.ValideDepuis || autre.ValideJusqua <= ValideDepuis);
        }
    }
}

