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
    /// <summary>
    /// Logique d'interaction pour FenetreInscription.xaml
    /// </summary>
    public partial class FenetreInscription : Window
    {
        private Visiteur _visiteur;
        private Session _session;

        public FenetreInscription()
        {
            InitializeComponent();

            // Une nouvelle session démarre pour l'inscription
            _session = new Session
            {
                Numéro = Guid.NewGuid().ToString(),
                DateConnexion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            BtnCreer.Click += BtnCreer_Click;
            BtnRetour.Click += (s, e) =>
            {
                new Accuiel().Show();
                this.Close();
            };
        }

        private void BtnCreer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Membre nouveauMembre = new Membre
                {
                    Nom = txtNom.Text.Trim(),
                    Prénom = txtPrenom.Text.Trim(),
                    Adresse = txtAdresse.Text.Trim(),
                    Telephone = txtTelephone.Text.Trim(),
                    AdresseCourriel = txtCourriel.Text.Trim(),
                    NomUsager = txtNomUsager.Text.Trim(),
                    MotDePasse = txtMotDePasse.Password.Trim(),
                    LanguePreferee = (cbLangue.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    AAccepteRecevoirNotifications = chkNotif.IsChecked ?? false
                };

                nouveauMembre.Numero = Guid.NewGuid().ToString();
                nouveauMembre.Compte = new Compte(); // ✅ on crée le compte

                _session.ConfirmerInscriptionMembre(ref nouveauMembre);

                MessageBox.Show($"Bienvenue {nouveauMembre.Prénom} !",
                                "Inscription réussie",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                new FenetreCatalogue().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
        }


    }
}
