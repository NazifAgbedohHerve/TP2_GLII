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
    /// Logique d'interaction pour Accuiel.xaml
    /// </summary>
    public partial class Accuiel : Window
    {
        
            public Accuiel()
            {
                InitializeComponent();

                BtnConnexion.Click += (s, e) =>
                {
                    new FenetreConnexion().Show();
                    this.Close();
                };

                BtnInscription.Click += (s, e) =>
                {
                    new FenetreInscription().Show();
                    this.Close();
                };

                BtnCatalogue.Click += (s, e) =>
                {
                    new FenetreCatalogue().Show();
                    this.Close();
                };
            }
        }
    }

    

