using System;

namespace TP2_GLII.Model
{
    public class Paiement
    {
        private string numéro;
        private DateTime date;
        private decimal montant;

        private TxVisionnement concerne;
        private CarteCrédit sur;
        private TxAbonnement génère;

        public string Numéro { get => numéro; set => numéro = value; }
        public DateTime Date { get => date; set => date = value; }
        public decimal Montant { get => montant; set => montant = value; }

        public TxVisionnement Concerne { get => concerne; set => concerne = value; }
        public CarteCrédit Sur { get => sur; set => sur = value; }
        public TxAbonnement Génère { get => génère; set => génère = value; }

        public override string ToString()
        {
            return $"Paiement {Numéro} - {Montant:C} le {Date:dd/MM/yyyy}";
        }
    }
}
