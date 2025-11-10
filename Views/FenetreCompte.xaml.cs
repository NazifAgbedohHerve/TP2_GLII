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
using TP2_GLII.Models;

namespace TP2_GLII.Views
{
    /// <summary>
    /// Logique d'interaction pour FenetreCompte.xaml
    /// </summary>
    public partial class FenetreCompte : Window
    {
        private Membre membre;

        public FenetreCompte(Membre membre)
        {
            InitializeComponent();
            this.membre = membre;

            ChargerInfosMembre();

            BtnRetour.Click += (s, e) => { new FenetreCatalogue().Show(); this.Close(); };
            BtnApprovisionner.Click += BtnApprovisionner_Click;
            BtnRembourser.Click += BtnRembourser_Click;
            BtnSuspendre.Click += BtnSuspendre_Click;
            BtnHistorique.Click += BtnHistorique_Click;
            BtnSAbonner.Click += BtnSAbonner_Click;
            BtnReactiver.Click += BtnReactiver_Click;
            BtnSuspendre.Click += BtnSuspendre_Click;

        }

        private void ChargerInfosMembre()
        {
            txtNomMembre.Text = $"{membre.Prénom} {membre.Nom}";
            txtCourriel.Text = membre.AdresseCourriel;
            txtSolde.Text = $"Solde actuel : {membre.Compte.Solde:C2}";

            if (membre.AbonnementActuel != null)
                txtAbonnement.Text = $"Plan : {membre.AbonnementActuel.AbonnementPlan.Nom}  (Valide jusqu’au {membre.AbonnementActuel.ValideJusqua:dd/MM/yyyy})";
            else
                txtAbonnement.Text = "Aucun abonnement actif.";
        }

        private void BtnApprovisionner_Click(object sender, RoutedEventArgs e)
        {
            membre.Compte.Crediter(10m); // +10$
            MessageBox.Show("Compte approvisionné de 10 $", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            ChargerInfosMembre();
        }

        private void BtnSAbonner_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Vérifier s'il existe déjà un abonnement actif
                if (membre.AbonnementActuel != null &&
                    membre.AbonnementActuel.Statut == "Actif" &&
                    membre.AbonnementActuel.ValideJusqua > DateTime.Now)
                {
                    MessageBox.Show("Vous avez déjà un abonnement actif.", "Information");
                    return;
                }

                // Créer l’abonnement
                var tx = membre.SAbonner(DataStore.PlansAbonnement[0]);

                MessageBox.Show(
                    $"Abonnement « {tx.TypeAbonnement} » activé jusqu’au {tx.ValideJusqua:dd MMM yyyy}.",
                    "Abonnement confirmé", MessageBoxButton.OK, MessageBoxImage.Information);

                ChargerInfosMembre();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void BtnRembourser_Click(object sender, RoutedEventArgs e)
        {
            if (membre.Compte.Solde > 0)
            {
                membre.Compte.Solde = 0;
                MessageBox.Show("Votre solde a été remboursé.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                ChargerInfosMembre();
            }
            else
            {
                MessageBox.Show("Aucun solde à rembourser.", "Information", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnSuspendre_Click(object sender, RoutedEventArgs e)
        {
            if (membre.AbonnementActuel == null)
            {
                MessageBox.Show("Vous n'avez aucun abonnement actif.");
                return;
            }

            membre.AbonnementActuel.Statut = "Suspendu";
            MessageBox.Show("Abonnement suspendu.");
            ChargerInfosMembre();
        }

        private void BtnReactiver_Click(object sender, RoutedEventArgs e)
        {
            if (membre.AbonnementActuel == null)
            {
                MessageBox.Show("Aucun abonnement à réactiver.");
                return;
            }

            membre.AbonnementActuel.Statut = "Actif";
            MessageBox.Show("Abonnement réactivé.");
            ChargerInfosMembre();
        }

        private void BtnHistorique_Click(object sender, RoutedEventArgs e)
        {
            new FenetreHistoriqueVisionnements(membre).Show();
            this.Close();
        }
    }
}

