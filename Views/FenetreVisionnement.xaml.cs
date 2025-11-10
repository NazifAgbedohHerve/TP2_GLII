using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TP2_GLII.Model;
using TP2_GLII.Models;

namespace TP2_GLII.Views
{
    public partial class FenetreVisionnement : Window
    {
        private Film film;
        private Membre membre;

        public FenetreVisionnement(Film filmSelectionne, Membre membreConnecte)
        {
            InitializeComponent();
            film = filmSelectionne;
            membre = membreConnecte;

            if (film != null)
                txtTitreFilm.Text= $"Visionnement : {film.Titre}";
        }

        // Bouton "Visionner"
        private void BtnVisionner_Click(object sender, RoutedEventArgs e)
        {
            if (film == null || membre == null)
            {
                MessageBox.Show("Aucun film ou membre sélectionné.");
                return;
            }

            if (membre.Compte == null)
            {
                MessageBox.Show("Ce membre n'a pas de compte associé.");
                return;
            }

            // Vérifier abonnement actif
            bool abonnementActif = membre.AbonnementActuel != null
                               && membre.AbonnementActuel.Statut == "Actif"
                               && membre.AbonnementActuel.ValideJusqua > DateTime.Now;

            ModeAccès modeAcces;
            Paiement paiement = null;

            if (abonnementActif)
            {
                // Visionnement inclus
                modeAcces = ModeAccès.Abonnement;
            }
            else
            {
                // Visionnement à l’unité
                modeAcces = ModeAccès.A_L_Unité;
                decimal prix = film.Prix;

                if (membre.Compte.Solde < prix)
                {
                    MessageBox.Show("Solde insuffisant. Veuillez recharger votre compte.");
                    return;
                }

                // Déduire le solde
                membre.Compte.Solde -= prix;

                paiement = new Paiement
                {
                    Numéro = Guid.NewGuid().ToString(),
                    Date = DateTime.Now,
                    Montant = prix
                };

                DataStore.Paiements.Add(paiement);
            }

            // Enregistrer la transaction
            var tx = new TxVisionnement
            {
                Numéro = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                Film = film,
                Membre = membre,
                ModeAccès = modeAcces,
                Paiement = paiement
            };

            membre.Compte.AjouterTransaction(tx);
            DataStore.Transactions.Add(tx);

            //  Lecture vidéo
            if (!string.IsNullOrEmpty(film.CheminFichier))
            {
                videoPlayer.Source = new Uri(film.CheminFichier, UriKind.RelativeOrAbsolute);
                videoPlayer.Play();
            }
        }

        private void BtnFermer_Click(object sender, RoutedEventArgs e)
        {
            videoPlayer.Stop();
            new FenetreCatalogue().Show();
            this.Close();
        }

    }
}

