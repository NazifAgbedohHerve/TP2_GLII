using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_GLII.Models
{
    public static class DataStore
    {
        // Liste globale des membres inscrits
        public static List<Membre> Membres { get; set; } = new List<Membre>();

        // Membre actuellement connecté
        public static Membre MembreConnecte { get; set; } = null;

        // Exemple : liste de films (si tu veux lier au catalogue)
        public static List<Film> Films { get; set; } = new List<Film>();

        // Simulation simple pour initialiser quelques données
        static DataStore()
        {
            // Exemple : films fictifs
            Films.Add(new Film { Titre = "Inception", Genre = "Science-fiction", Prix = 4.99 });
            Films.Add(new Film { Titre = "Avatar", Genre = "Aventure", Prix = 3.99 });
            Films.Add(new Film { Titre = "Tenet", Genre = "Action", Prix = 5.49 });
        }
    }
}
