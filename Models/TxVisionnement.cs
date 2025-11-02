using System;
using TP2_GLII.Model;
using TP2_GLII.Models;
public class TxVisionnement : Transaction
    {
        private Film film;
        private ModeAccès modeAccès;
        private Paiement paiement;
        private Compte compte;

        public Film Film { get => film; set => film = value; }
        public ModeAccès ModeAccès { get => modeAccès; set => modeAccès = value; }
        public Paiement Paiement { get => paiement; set => paiement = value; }
        public Compte Compte { get => compte; set => compte = value; }

        public TxVisionnement() { }

        public TxVisionnement(Film film, ModeAccès modeAccès, Paiement paiement, Compte compte)
        {
            this.film = film;
            this.modeAccès = modeAccès;
            this.paiement = paiement;
            this.compte = compte;

            //  Validation conforme aux contraintes du diagramme 
            if (modeAccès == ModeAccès.A_L_Unité && paiement == null)
                throw new InvalidOperationException("Visionnement à l’unité : un paiement est requis.");
            if (modeAccès == ModeAccès.Abonnement && paiement != null)
                throw new InvalidOperationException("Visionnement par abonnement : aucun paiement ne doit être lié.");
        }

        /// <summary>
        /// Retourne les visionnements des films réalisés par une personne donnée
        /// (celle-ci doit être créditée comme Réalisateur dans les films).
        /// </summary>
        public TxVisionnement[] ConsulterHistoriquePourUnRéalisateur(ref Personne personne)
        {
            if (personne == null)
                return Array.Empty<TxVisionnement>();

            //  Récupérer les films où la personne a un crédit "Réalisateur"
            var filmsDuRealisateur = DataStore.Films
                .Where(f => f.CréditsFilm != null &&
                            f.CréditsFilm.Any(c =>
                                c.Personne == personne &&
                                c.Rôle == TypeRôle.Réalisateur))
                .ToList();

            //  Sélectionner les visionnements liés à ces films
            var visionnements = DataStore.Transactions
                .OfType<TxVisionnement>()
                .Where(tx => filmsDuRealisateur.Contains(tx.Film))
                .ToArray();

            return visionnements;
        }

        /// <summary>
        /// Retourne une représentation lisible du visionnement.
        /// </summary>
        public override string ToString()
        {
            string mode = ModeAccès == ModeAccès.Abonnement ? "Abonnement" : "À l’unité";
            string prix = Paiement != null ? $"{Paiement.Montant:C}" : "Inclus";
            return $"{Film?.Titre ?? "Film inconnu"} - {mode} - {prix}";
        }
    }



