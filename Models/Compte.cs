using System;
using System.Transactions;

namespace TP2_GLII.Model
{
    public class Compte
    {
        private string num�ro;
        private decimal solde;

        private List<Transaction> transactions = new List<Transaction>();  
        private Paiement[] sur;
        private CarteCr�dit[] rattach�_�_;
        private CarteCr�dit par_d�faut;

        private Membre poss�de;
        private TxApprovisionnement[] vers;
        private TxRemboursement[] de_;

        public string Num�ro { get => num�ro; set => num�ro = value; }

        
        public decimal Solde { get => solde; set => solde = value; }

        public Paiement[] Sur { get => sur; set => sur = value; }
        public CarteCr�dit[] Rattach�� { get => rattach�_�_; set => rattach�_�_ = value; }
        public CarteCr�dit ParD�faut { get => par_d�faut; set => par_d�faut = value; }
        public Membre Poss�de { get => poss�de; set => poss�de = value; }
        public TxApprovisionnement[] Vers { get => vers; set => vers = value; }
        public TxRemboursement[] De { get => de_; set => de_ = value; }

        // Propri�t� pour la gestion de  l'historique
        public List<Transaction> Transactions { get => transactions; set => transactions = value; }

        // M�thodes pour la de gestion du compte
        public void Cr�diter(decimal montant)
        {
            solde += montant;
        }

        public bool D�biter(decimal montant)
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
            if (tx != null)
                transactions.Add(tx);
        }

        public override string ToString()
        {
            return $"Compte {Num�ro} � Solde : {Solde:C}";
        }
    }
}


