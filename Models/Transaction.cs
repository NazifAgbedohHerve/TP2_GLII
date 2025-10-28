using System;
using TP2_GLII.Models;

namespace TP2_GLII.Model
{
    public class Transaction
    {
        private string numéro;
        private DateTime date;
        private decimal prix;
        private decimal montantTaxe;

        private Session fait;

        public string Numéro { get => numéro; set => numéro = value; }
        public DateTime Date { get => date; set => date = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public decimal MontantTaxe { get => montantTaxe; set => montantTaxe = value; }
        public Session Fait { get => fait; set => fait = value; }

        // Historique des transactions d’un membre
        public Transaction[] ConsulterHistorique(ref Membre membre)
        {
            // Implémentation à compléter (simulation)
            Console.WriteLine($"Consultation de l’historique des transactions pour {membre.NomUsager}");
            return Array.Empty<Transaction>();
        }
    }
}
