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
        private Membre membre; // peut être null si visiteur

        // Le membre est optionnel (visiteur peut ouvrir la fiche)
        public FenetreFicheFilm(Film filmSelectionne, Membre membreConnecte = null)
        {
            InitializeComponent();
            film = filmSelectionne ?? throw new ArgumentNullException(nameof(filmSelectionne));
            membre = membreConnecte;
            ChargerFicheFilm();
        }

        private void ChargerFicheFilm()
        {
            if (film == null) return;

            // Titres / synopsis / infos
            txtTitreFilm.Text = film.Titre ?? "Titre inconnu";
            txtSynopsis.Text = film.Synopsis ?? "(Synopsis non disponible)";

            // Prix (si présent dans le modèle)
            try
            {
                txtInfosFilm.Text = film.AnnéeSortie?.ToString() ?? ""; // adapte selon le type
            }
            catch
            {
                // Si la propriété s'appelle différemment, laisse vide pour l'instant
                txtInfosFilm.Text = "";
            }

            // Si Film.Prix existe et est un string ou decimal
            try
            {
                txtSynopsis.Text = film.Synopsis ?? txtSynopsis.Text;
                if (film.Prix != null)
                    ; // on n'affiche pas Prix ici (tu peux ajouter un TextBlock si besoin)
            }
            catch { /* ignore si propriété absent */ }

            // Catégories (Film.Appartient doit exister : tableau ou List)
            try
            {
                if (film.Appartient != null && film.Appartient.Length > 0)
                    txtInfosFilm.Text += $"  •  {string.Join(", ", film.Appartient.Select(c => c.NomCategorie))}";
            }
            catch
            {
                // si Appartient n'existe pas ou a un autre nom, on ignore
            }

            // Crédits : on attend que CréditFilm contienne Personne et Rôle
            lstCredits.Items.Clear();
            try
            {
                if (film.CréditFilm != null && film.CréditFilm.Count > 0)
                {
                    foreach (var credit in film.CréditFilm)
                    {
                        // Defensive: si Personne ou Role n'existent pas, on s'adapte
                        string role = credit?.Rôle.ToString() ?? "Rôle inconnu";
                        string personneNom = null;
                        try { personneNom = credit?.Personne?.Nom; } catch { personneNom = null; }

                        if (!string.IsNullOrEmpty(personneNom))
                            lstCredits.Items.Add($"{role} : {personneNom}");
                        else
                            lstCredits.Items.Add($"{role}");
                    }
                }
                else
                {
                    lstCredits.Items.Add("(Aucun crédit disponible)");
                }
            }
            catch
            {
                // Si la structure diffère, affiche un message générique
                lstCredits.Items.Add("(Crédits non disponibles — vérifie le modèle)");
            }
        }

        // Lorsque l'utilisateur clique sur "Visionner" depuis la fiche
        private void btnVisionner_Click(object sender, RoutedEventArgs e)
        {
            // Respect du TP : le visiteur voit la fiche, mais ne peut pas visionner.
            var membreActuel = DataStore.MembreConnecte; // la session globale
            if (membreActuel == null)
            {
                MessageBox.Show("Vous devez être membre pour visionner ce film. Veuillez vous inscrire ou vous connecter.",
                                "Accès réservé", MessageBoxButton.OK, MessageBoxImage.Information);
                new FenetreInscription().Show();
                this.Close();
                return;
            }

            // Ouvre FenetreVisionnement qui exige (Film, Membre)
            var fenetreVisionnement = new FenetreVisionnement(film, membreActuel);
            fenetreVisionnement.ShowDialog();
        }

        private void btnFermer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}


