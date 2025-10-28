using System;
using TP2_GLII.Models;

namespace TP2_GLII.Model
{
    public class Transaction
    {
        private string num�ro;
        private DateTime date;
        private decimal prix;
        private decimal montantTaxe;

        private Session fait;

        public string Num�ro { get => num�ro; set => num�ro = value; }
        public DateTime Date { get => date; set => date = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public decimal MontantTaxe { get => montantTaxe; set => montantTaxe = value; }
        public Session Fait { get => fait; set => fait = value; }

        // Historique des transactions d�un membre
        public Transaction[] ConsulterHistorique(ref Membre membre)
        {
            // Impl�mentation � compl�ter (simulation)
            Console.WriteLine($"Consultation de l�historique des transactions pour {membre.NomUsager}");
            return Array.Empty<Transaction>();
        }
    }
}
