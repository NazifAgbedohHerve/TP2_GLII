using System;

namespace TP2_GLII.Model
{
    public class Paiement
    {
        private string num�ro;
        private DateTime date;
        private decimal montant;

        private TxVisionnement concerne;
        private CarteCr�dit sur;
        private TxAbonnement g�n�re;

        public string Num�ro { get => num�ro; set => num�ro = value; }
        public DateTime Date { get => date; set => date = value; }
        public decimal Montant { get => montant; set => montant = value; }

        public TxVisionnement Concerne { get => concerne; set => concerne = value; }
        public CarteCr�dit Sur { get => sur; set => sur = value; }
        public TxAbonnement G�n�re { get => g�n�re; set => g�n�re = value; }

        public override string ToString()
        {
            return $"Paiement {Num�ro} - {Montant:C} le {Date:dd/MM/yyyy}";
        }
    }
}
