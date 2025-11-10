using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using TP2_GLII.Models; 

namespace TP2_GLII.Views
{
    public partial class FenetreCatalogue : Window
    {
        public FenetreCatalogue()
        {
            InitializeComponent();

            // Remplissage depuis DataStore
            lvFilms.ItemsSource = DataStore.Films;

            // Greeting selon membre connecté
            if (DataStore.MembreConnecte != null)
            {
                // exemple d'accès au nom d'usager (si tu as exposé nomUsagerPublic)
                txtGreeting.Text = $"Bonjour {DataStore.MembreConnecte.NomUsager}  ";
            }
            else
            {
                txtGreeting.Text = "Visiteur";
            }

            BtnConnexion.Click += (s, e) => { new FenetreConnexion().Show(); this.Close(); };
            BtnInscription.Click += (s, e) => { new FenetreInscription().Show(); this.Close(); };
            BtnRechercher.Click += BtnRechercher_Click;
        }

        private void BtnRechercher_Click(object sender, RoutedEventArgs e)
        {
            string critere = txtRecherche.Text?.Trim().ToLower() ?? "";

            if (string.IsNullOrEmpty(critere))
            {
                lvFilms.ItemsSource = DataStore.Films;
                return;
            }

            var résultats = DataStore.Films.Where(f =>
                (f.Titre?.ToLower().Contains(critere) ?? false) ||
                (f.Appartient != null && f.Appartient.Any(cat =>
                    cat.NomCategorie.ToLower().Contains(critere)))
            ).ToList();

            lvFilms.ItemsSource = résultats;
            if (!résultats.Any())
                MessageBox.Show("Aucun film correspond à votre recherche.");

        }



        private void BtnDetails_Click(object sender, RoutedEventArgs e)
        {
            var film = (sender as FrameworkElement)?.DataContext as Film;
            if (film == null) return;

            var fiche = new FenetreFicheFilm(film);
            fiche.Show();
            this.Close();
        }

        private void BtnCompte_Click(object sender, RoutedEventArgs e)
        {
            if (DataStore.MembreConnecte == null)
            {
                MessageBox.Show("Vous devez être connecté.");
                return;
            }

            new FenetreCompte(DataStore.MembreConnecte).Show();
        }


        private void BtnVisionner_Click(object sender, RoutedEventArgs e)
        {
            var film = (sender as FrameworkElement)?.DataContext as Film;
            if (film == null) return;

            if (DataStore.MembreConnecte == null)
            {
                MessageBox.Show("Vous devez être membre pour visionner ce film. Veuillez vous inscrire ou vous connecter.",
                                "Accès réservé", MessageBoxButton.OK, MessageBoxImage.Information);
                new FenetreInscription().Show();
                this.Close();
                return;
            }

            var membre = DataStore.MembreConnecte;
            var vision = new FenetreVisionnement(film, membre);
            vision.Show();
            this.Close();
        }

    }
}



