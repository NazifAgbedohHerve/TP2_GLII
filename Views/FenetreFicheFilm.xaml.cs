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
        private Membre membre;

        public FenetreFicheFilm(Film filmSelectionne, Membre membreConnecte)
        {
            InitializeComponent();
            film = filmSelectionne;
            membre = membreConnecte;
            ChargerFicheFilm();
        }

        private void ChargerFicheFilm()
        {
            if (film == null) return;

            txtTitreFilm.Text = film.Titre;
            txtInfosFilm.Text = $"{film.AnnéeSortie}  •  {string.Join(", ", film.Appartient.Select(c => c.NomCategorie))}";
            txtSynopsis.Text = film.Synopsis;

            // Charger les crédits
            lstCredits.Items.Clear();
            if (film.CréditFilm != null)
            {
                foreach (var credit in film.CréditFilm)
                {
                    string texte = $"{credit.Rôle} : {credit.Personne?.Nom}";
                    lstCredits.Items.Add(texte);
                }
            }
            else
            {
                lstCredits.Items.Add("(Aucun crédit disponible)");
            }
        }

        //  Ouvre la fenêtre de visionnement
        private void btnVisionner_Click(object sender, RoutedEventArgs e)
        {
            var fenetreVisionnement = new FenetreVisionnement(film, membre);
            fenetreVisionnement.ShowDialog();
        }

        private void btnFermer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

