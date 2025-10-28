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
    public partial class FenetreFicheFilm : Window
    {
        private Film film;

        public FenetreFicheFilm(Film film)
        {
            InitializeComponent();
            this.film = film;

            // Remplissage des champs
            txtTitre.Text = film.Titre;
            txtCategorie.Text = film.Appartient != null && film.Appartient.Length > 0
                ? film.Appartient[0].NomCategorie
                : "Catégorie non spécifiée";
            txtAnnee.Text = $"Année de sortie : {film.AnnéeSortie}";
            txtDuree.Text = $"Durée : {film.Durée}";
            txtPrix.Text = $"Prix : {film.Prix} $";
            txtSynopsis.Text = film.Synopsis;

            // Actions boutons
            BtnRetour.Click += (s, e) => { new FenetreCatalogue().Show(); this.Close(); };
            BtnVisionner.Click += BtnVisionner_Click;
        }

        private void BtnVisionner_Click(object sender, RoutedEventArgs e)
        {
            if (DataStore.MembreConnecte == null)
            {
                MessageBox.Show("Vous devez être membre pour visionner ce film.", "Accès restreint",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                new FenetreInscription().Show();
                this.Close();
            }
            else
            {
                new FenetreVisionnement(film).Show();
                this.Close();
            }
        }
    }
}

