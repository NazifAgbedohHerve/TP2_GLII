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

namespace TP2_GLII.Views
{
    /// <summary>
    /// Logique d'interaction pour FenetreHistoriqueVisionnements.xaml
    /// </summary>
    public partial class FenetreHistoriqueVisionnements : Window
    {
        private Membre membre;

        public FenetreHistoriqueVisionnements(Membre membre)
        {
            InitializeComponent();
            this.membre = membre;
            ChargerHistorique();
            BtnRetour.Click += (s, e) => { new FenetreCompte(membre).Show(); this.Close(); };
            BtnDetails.Click += BtnDetails_Click;
        }

        private void ChargerHistorique()
        {
            lvHistorique.ItemsSource = null;

            if (membre?.Compte?.Transactions == null)
            {
                lvHistorique.ItemsSource = new List<object>();
                return;
            }

            var visionnements = membre.Compte.Transactions
                .Where(t => t is TxVisionnement)
                .Cast<TxVisionnement>()
                .OrderByDescending(v => v.Date)
                .Select(v => new {
                    Date = v.Date.ToString("g"),
                    Film = v.Film,
                    ModeAccesString = v.ModeAccès == ModeAccès.Abonnement ? "Abonnement" : "À l'unité",
                    PaiementMontant = v.Paiement != null ? v.Paiement.Montant.ToString("C") : (v.ModeAccès == ModeAccès.Abonnement ? "Inclus" : "—"),
                    Tx = v
                }).ToList();

            lvHistorique.ItemsSource = visionnements;
        }

        private void BtnDetails_Click(object sender, RoutedEventArgs e)
        {
            var item = lvHistorique.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Sélectionnez un visionnement pour voir les détails.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // l'objet anonyme contient Tx = v
            var txProp = item.GetType().GetProperty("Tx");
            var tx = txProp?.GetValue(item) as TxVisionnement;
            if (tx != null)
            {
                var fiche = new FenetreFicheFilm(tx.Film); // si l'on veux ouvrir la fiche film
                fiche.Show();
            }
        }
    }
}

