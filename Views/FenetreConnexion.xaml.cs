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
    public partial class FenetreConnexion : Window
    {
        private Session session = new Session();

        public FenetreConnexion()
        {
            InitializeComponent();
            BtnConnexion.Click += BtnConnexion_Click;
            BtnRetour.Click += (s, e) => { new Accuiel().Show(); this.Close(); };
            BtnInscription.Click += (s, e) => { new FenetreInscription().Show(); this.Close(); };
        }

        private void BtnConnexion_Click(object sender, RoutedEventArgs e)
        {
            string identifiant = txtNomUsager.Text.Trim();
            string motDePasse = txtMotDePasse.Password.Trim();

            if (string.IsNullOrWhiteSpace(identifiant) || string.IsNullOrWhiteSpace(motDePasse))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Membre membre = session.ValiderInfoConnexion(identifiant, motDePasse);

            if (membre != null)
            {
                MessageBox.Show($"Bienvenue {membre.Prénom} !", "Connexion réussie", MessageBoxButton.OK, MessageBoxImage.Information);
                new FenetreCatalogue().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nom d'usager ou mot de passe incorrect.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}



