using System;
using TP2_GLII.Model;

    public class TxApprovisionnement : Transaction
    {
        private decimal montant;
        private Compte vers;
        private CarteCrédit sur;

        public decimal Montant { get => montant; set => montant = value; }
        public Compte Vers { get => vers; set => vers = value; }
        public CarteCrédit Sur { get => sur; set => sur = value; }

        public override string ResumeTransaction()
        {
            return $"Approvisionnement de {Montant:C} sur le compte {Vers?.Numéro}";
        }
    }


