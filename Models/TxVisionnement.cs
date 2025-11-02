using System;
using TP2_GLII.Model;
using TP2_GLII.Models;
public class TxVisionnement : Transaction
    {
        private Film film;
        private ModeAcc�s modeAcc�s;
        private Paiement paiement;
        private Compte compte;

        public Film Film { get => film; set => film = value; }
        public ModeAcc�s ModeAcc�s { get => modeAcc�s; set => modeAcc�s = value; }
        public Paiement Paiement { get => paiement; set => paiement = value; }
        public Compte Compte { get => compte; set => compte = value; }

        public TxVisionnement() { }

        public TxVisionnement(Film film, ModeAcc�s modeAcc�s, Paiement paiement, Compte compte)
        {
            this.film = film;
            this.modeAcc�s = modeAcc�s;
            this.paiement = paiement;
            this.compte = compte;

            //  Validation conforme aux contraintes du diagramme 
            if (modeAcc�s == ModeAcc�s.A_L_Unit� && paiement == null)
                throw new InvalidOperationException("Visionnement � l�unit� : un paiement est requis.");
            if (modeAcc�s == ModeAcc�s.Abonnement && paiement != null)
                throw new InvalidOperationException("Visionnement par abonnement : aucun paiement ne doit �tre li�.");
        }

        /// <summary>
        /// Retourne les visionnements des films r�alis�s par une personne donn�e
        /// (celle-ci doit �tre cr�dit�e comme R�alisateur dans les films).
        /// </summary>
        public TxVisionnement[] ConsulterHistoriquePourUnR�alisateur(ref Personne personne)
        {
            if (personne == null)
                return Array.Empty<TxVisionnement>();

            //  R�cup�rer les films o� la personne a un cr�dit "R�alisateur"
            var filmsDuRealisateur = DataStore.Films
                .Where(f => f.Cr�ditsFilm != null &&
                            f.Cr�ditsFilm.Any(c =>
                                c.Personne == personne &&
                                c.R�le == TypeR�le.R�alisateur))
                .ToList();

            //  S�lectionner les visionnements li�s � ces films
            var visionnements = DataStore.Transactions
                .OfType<TxVisionnement>()
                .Where(tx => filmsDuRealisateur.Contains(tx.Film))
                .ToArray();

            return visionnements;
        }

        /// <summary>
        /// Retourne une repr�sentation lisible du visionnement.
        /// </summary>
        public override string ToString()
        {
            string mode = ModeAcc�s == ModeAcc�s.Abonnement ? "Abonnement" : "� l�unit�";
            string prix = Paiement != null ? $"{Paiement.Montant:C}" : "Inclus";
            return $"{Film?.Titre ?? "Film inconnu"} - {mode} - {prix}";
        }
    }



