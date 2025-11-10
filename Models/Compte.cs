using System;
using System.Transactions;

namespace TP2_GLII.Model
{
    public class Compte
    {
        private string numéro;
        private decimal solde;

        private List<Transaction> transactions = new List<Transaction>();  
        private Paiement[] sur;
        private CarteCrédit[] rattaché_à_;
        private CarteCrédit par_défaut;

        private Membre possède;
        private TxApprovisionnement[] vers;
        private TxRemboursement[] de_;

        public string Numéro { get => numéro; set => numéro = value; }

        
        public decimal Solde { get => solde; set => solde = value; }

        public Paiement[] Sur { get => sur; set => sur = value; }
        public CarteCrédit[] RattachéÀ { get => rattaché_à_; set => rattaché_à_ = value; }
        public CarteCrédit ParDéfaut { get => par_défaut; set => par_défaut = value; }
        public Membre Possède { get => possède; set => possède = value; }
        public TxApprovisionnement[] Vers { get => vers; set => vers = value; }
        public TxRemboursement[] De { get => de_; set => de_ = value; }

        // Propriété pour la gestion de  l'historique
        public List<Transaction> Transactions { get => transactions; set => transactions = value; }

        // Méthodes pour la de gestion du compte
        public void Crediter(decimal montant)
        {
            solde += montant;
        }

        public bool Débiter(decimal montant)
        {
            if (solde >= montant)
            {
                solde -= montant;
                return true;
            }
            return false;
        }

        public void AjouterTransaction(Transaction tx)
        {
            if (Transactions == null)
                Transactions = new List<Transaction>();
            Transactions.Add(tx);
        }

        public void Approvisionner(decimal montant)
        {
            solde += montant;
            transactions.Add(new TxApprovisionnement
            {
                Numéro = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                Montant = montant,
                Vers = this
            });
        }

        public void Rembourser(decimal montant)
        {
            solde += montant;
            transactions.Add(new TxRemboursement
            {
                Numéro = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                Montant = montant,
                De_ = this
            });
        }


        public override string ToString()
        {
            return $"Compte {Numéro} — Solde : {Solde:C}";
        }
    }
}


