using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP2_GLII.Models;
using TP2_GLII.Views;

namespace TP2_GLII
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AutoRedirect(3000);
        }

        private async void AutoRedirect(int milliseconds)
        {
            await Task.Delay(milliseconds);
            if (this.IsLoaded) // Vérifier que la fenêtre est toujours ouverte
            {
                RedirectToAccueil();
            }
        }

        private void BtnEntrer_Click(object sender, RoutedEventArgs e)
        {
            RedirectToAccueil();
        }

        private void RedirectToAccueil()
        {
            // Ouvrir la fenêtre d'accueil
            var accueil = new Views.Accuiel();
            accueil.Show();

            // Fermer cette fenêtre de bienvenue
            this.Close();
        }
    }
}