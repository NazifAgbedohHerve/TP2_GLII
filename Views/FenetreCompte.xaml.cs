﻿using System;
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
        }

        private void ChargerInfosMembre()
        {
            txtNomMembre.Text = $"{membre.Prénom} {membre.Nom}";
            txtCourriel.Text = membre.AdresseCourriel;
            txtSolde.Text = $"Solde actuel : {membre.Possède.Solde:C2}";

            if (membre.A_Actuellement != null)
                txtAbonnement.Text = $"Type : {membre.A_Actuellement.TypeAbonnement} - Statut : {membre.A_Actuellement.Statut}";
            else
                txtAbonnement.Text = "Aucun abonnement actif.";
        }

        private void BtnApprovisionner_Click(object sender, RoutedEventArgs e)
        {
            membre.Possède.Créditer(10); // exemple : +10$
            MessageBox.Show("Compte approvisionné de 10 $", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            ChargerInfosMembre();
        }

        private void BtnRembourser_Click(object sender, RoutedEventArgs e)
        {
            if (membre.Possède.Solde > 0)
            {
                membre.Possède.Solde = 0;
                MessageBox.Show("Demande de remboursement effectuée.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                ChargerInfosMembre();
            }
            else
            {
                MessageBox.Show("Aucun solde à rembourser.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnSuspendre_Click(object sender, RoutedEventArgs e)
        {
            if (membre.A_Actuellement != null)
            {
                var confirm = MessageBox.Show("Voulez-vous suspendre votre abonnement ?", "Confirmation",
                                              MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (confirm == MessageBoxResult.Yes)
                {
                    membre.A_Actuellement.Statut = "Suspendu";
                    MessageBox.Show("Abonnement suspendu.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    ChargerInfosMembre();
                }
            }
            else
            {
                MessageBox.Show("Vous n’avez aucun abonnement actif.", "Information");
            }
        }

        private void BtnHistorique_Click(object sender, RoutedEventArgs e)
        {
            new FenetreHistoriqueVisionnements(membre).Show();
            this.Close();
        }
    }
}

