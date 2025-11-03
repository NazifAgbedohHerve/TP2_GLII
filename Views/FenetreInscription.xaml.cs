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
    /// Logique d'interaction pour FenetreInscription.xaml
    /// </summary>
    public partial class FenetreInscription : Window
    {
        private Visiteur _visiteur;
        private Session _session;

        public FenetreInscription()
        {
            InitializeComponent();

            // Le visiteur actuel ouvre une session
            _visiteur = new Visiteur();
            _visiteur.SAuthentifier("", ""); // Création symbolique d'une session
            _session = _visiteur.SessionCourante;

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
                // Création d'un objet Membre basé sur les champs du formulaire
                Membre nouveauMembre = new Membre
                {
                    
                    Nom = txtNom.Text.Trim(),
                    Prénom = txtPrenom.Text.Trim(),
                    Adresse = txtAdresse.Text.Trim(),
                    Telephone = txtTelephone.Text.Trim(),
                    AdresseCourriel = txtCourriel.Text.Trim(),
                    NomUsager = txtNomUsager.Text.Trim(),
                    MotDePasse = txtMotDePasse.Password.Trim(),
                    LanguePreferee = ((cbLangue.SelectedItem as ComboBoxItem)?.Content ?? "Français").ToString(),
                    AAccepteRecevoirNotifications = chkNotif.IsChecked == true
                };

                // Simulation d’un numéro unique
                nouveauMembre.Numero = Guid.NewGuid().ToString();

                // Confirmation de l’inscription via la Session
                _session.ConfirmerInscriptionMembre(ref nouveauMembre);

                // Ajout à la base simulée
                DataStore.Membres.Add(nouveauMembre);
                DataStore.MembreConnecte = nouveauMembre;

                MessageBox.Show($"Bienvenue {nouveauMembre.Prénom} ! Votre compte a été créé avec succès.",
                                "Inscription réussie",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                // Redirection vers le catalogue
                new FenetreCatalogue().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l’inscription : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
