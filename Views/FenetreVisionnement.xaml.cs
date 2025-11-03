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
            try
            {
                if (film == null || membre == null)
                {
                    MessageBox.Show("Aucun film ou membre sélectionné.");
                    return;
                }

                if (membre.Compte == null)
                {
                    MessageBox.Show("Aucun compte associé à ce membre !");
                    return;
                }

                // Choix du mode d’accès selon le type de membre
                ModeAccès modeAcces = membre.Compte.Solde > 0 ? ModeAccès.A_L_Unité : ModeAccès.Abonnement;

                Paiement paiement = null;

                if (modeAcces == ModeAccès.A_L_Unité)
                {
                    // Vérifier si le solde est suffisant
                    decimal prix = decimal.Parse(film.Prix);
                    if (membre.Compte.Solde < prix)
                    {
                        MessageBox.Show("Solde insuffisant pour un visionnement à l’unité.");
                        return;
                    }

                    membre.Compte.Solde -= prix;

                    paiement = new Paiement
                    {
                        Date = DateTime.Now,
                        Montant = prix
                    };
                }

                //  Crée la transaction de visionnement
                var tx = new TxVisionnement(film, modeAcces, paiement, membre.Compte);

                // Ajout dans le compte et dans le DataStore
                membre.Compte.AjouterTransaction(tx);
                DataStore.Transactions.Add(tx);

                MessageBox.Show($"Visionnement de \"{film.Titre}\" lancé avec succès !",
                                "Visionnement", MessageBoxButton.OK, MessageBoxImage.Information);

                // Simule la lecture du film
                film.Visionner();

                Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Erreur de transaction", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur inattendue : {ex.Message}");
            }
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

