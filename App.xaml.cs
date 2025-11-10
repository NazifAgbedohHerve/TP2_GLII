using System.Configuration;
using System.Data;
using TP2_GLII.Models;
using TP2_GLII.Views;
using System.Windows;

namespace TP2_GLII
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DataStore.InitialiserDonnées();
            base.OnStartup(e);
        }



    }

}
