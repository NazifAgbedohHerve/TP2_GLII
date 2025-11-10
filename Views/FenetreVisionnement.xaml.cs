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

            // Vérifier si le membre a un abonnement actif
            bool abonnementActif = membre.AbonnementActuel != null
                                   && membre.AbonnementActuel.ValideJusqua > DateTime.Now;

            ModeAccès modeAcces;
            Paiement paiement = null;

            if (abonnementActif)
            {
                //  Visionnement inclus dans l’abonnement
                modeAcces = ModeAccès.Abonnement;
            }
            else
            {
                //  Visionnement à l’unité → paiement requis
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
                    Date = DateTime.Now,
                    Montant = prix,
                    Sur = membre.Compte?.ParDéfaut, // si besoin
                };

                DataStore.Paiements.Add(paiement);
            }

            //  Création du TxVisionnement
            var tx = new TxVisionnement
            {
                Film = film,
                Membre = membre,
                ModeAccès = modeAcces,
                Date = DateTime.Now,
                Paiement = paiement
            };

            // Ajout dans l’historique
            membre.Compte.AjouterTransaction(tx);
            DataStore.Transactions.Add(tx);

            MessageBox.Show($"Visionnement de \"{film.Titre}\" lancé.",
                            "Visionnement", MessageBoxButton.OK, MessageBoxImage.Information);

            //  Lancement de la vidéo
            if (!string.IsNullOrEmpty(film.CheminFichier))
            {
                videoPlayer.Source = new Uri(film.CheminFichier, UriKind.RelativeOrAbsolute);
                videoPlayer.Play();
            }
            else
            {
                MessageBox.Show("Aucune source vidéo disponible.");
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

