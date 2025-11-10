using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_GLII.Model;


namespace TP2_GLII.Models
{
    public static class DataStore
    {   


        public static List<Film> Films { get; set; } = new List<Film>();
        public static List<Membre> Membres { get; set; } = new List<Membre>();
        public static List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public static List<Paiement> Paiements { get; } = new();
        public static List<AbonnementPlan> PlansAbonnement = new();

        public static Membre MembreConnecte { get; set; }

        public static void InitialiserDonnées()
        {
            // 1) personnes
            var nolan = new Personne { Numéro = "P001", Nom = "Christopher Nolan", Pays = "CAD", TypePersonne = TypePersonne.Physique };
            var cameron = new Personne { Numéro = "P002", Nom = "James Cameron", Pays = "USA", TypePersonne = TypePersonne.Physique };
            var villeneuve = new Personne { Numéro = "P003", Nom = "Denis Villeneuve", Pays = "CAN", TypePersonne = TypePersonne.Physique };
            var tarantino = new Personne { Numéro = "P004", Nom = "Quentin Tarantino", Pays = "USA", TypePersonne = TypePersonne.Physique };
            var jackson = new Personne { Numéro = "P005", Nom = "Peter Jackson", Pays = "NZ", TypePersonne = TypePersonne.Physique };

            // 2) catégories
            var catAction = new Catégorie("1", "Action");
            var catDrame = new Catégorie("2", "Drame");

            // 3) Plans d'abonnement
            var planBasic = new AbonnementPlan("PL001", "Basic", 9.99m);
            PlansAbonnement.Add(planBasic);

            // On pourra y accéder comme : DataStore.PlansAbonnement[0]


            // 4) Films
            var film1 = new Film
            {
                Numéro = "F001",
                Titre = "Ong-Bak",
                AnnéeSortie = "2010",
                Prix = 5.99m,
                Synopsis = "Un voleur infiltre les rêves.",
                Appartient = new[] { catDrame },
                CheminFichier = @"C:\Users\nazif\Videos\Captures\Ong-Bak.mp4"
            };
            film1.CréditFilm.Add(new CréditFilm(film1, nolan, TypeRôle.Réalisateur));
            Films.Add(film1);

            var film2 = new Film
            {
                Numéro = "F002",
                Titre = "The Dark Knight",
                AnnéeSortie = "2008",
                Prix = 4.99m,
                Synopsis = "Batman contre le Joker.",
                Appartient = new[] { catAction },
                CheminFichier = @"C:\Films\Inception.mp4"
            };
            film2.CréditFilm.Add(new CréditFilm(film2, nolan, TypeRôle.Réalisateur));
            Films.Add(film2);

            var film3 = new Film
            {
                Numéro = "F003",
                Titre = "Avatar",
                AnnéeSortie = "2009",
                Prix = 6.49m,
                Synopsis = "Un ancien marine explore une planète extraterrestre.",
                Appartient = new[] { catAction, catDrame },
                CheminFichier = @"C:\Films\Avatar.mp4"
            };
            film3.CréditFilm.Add(new CréditFilm(film3, cameron, TypeRôle.Réalisateur));
            Films.Add(film3);

            var film4 = new Film
            {
                Numéro = "F004",
                Titre = "Dune",
                AnnéeSortie = "2021",
                Prix = 7.99m,
                Synopsis = "Un jeune héritier lutte pour survivre dans un désert hostile.",
                Appartient = new[] { catAction, catDrame },
                CheminFichier = @"C:\Films\Dune.mp4"
            };
            film4.CréditFilm.Add(new CréditFilm(film4, villeneuve, TypeRôle.Réalisateur));
            Films.Add(film4);

            var film5 = new Film
            {
                Numéro = "F005",
                Titre = "Le Seigneur des Anneaux: La Communauté de l'Anneau",
                AnnéeSortie = "2001",
                Prix = 5.49m,
                Synopsis = "Un groupe improbable tente de détruire un artefact maléfique.",
                Appartient = new[] { catAction },
                CheminFichier = @"C:\Films\LSDA1.mp4"
            };
            film5.CréditFilm.Add(new CréditFilm(film5, jackson, TypeRôle.Réalisateur));
            Films.Add(film5);

            var film6 = new Film
            {
                Numéro = "F006",
                Titre = "Django Unchained",
                AnnéeSortie = "2012",
                Prix = 4.79m,
                Synopsis = "Un esclave libéré devient chasseur de primes.",
                Appartient = new[] { catAction, catDrame },
                CheminFichier = @"C:\Films\Django.mp4"
            };
            film6.CréditFilm.Add(new CréditFilm(film6, tarantino, TypeRôle.Réalisateur));
            Films.Add(film6);

            var film7 = new Film
            {
                Numéro = "F007",
                Titre = "Titanic",
                AnnéeSortie = "1997",
                Prix = 5.29m,
                Synopsis = "Un amour naissant à bord d'un navire légendaire.",
                Appartient = new[] { catDrame },
                CheminFichier = @"C:\Films\Titanic.mp4"
            };
            film7.CréditFilm.Add(new CréditFilm(film7, cameron, TypeRôle.Réalisateur));
            Films.Add(film7);

            var film8 = new Film
            {
                Numéro = "F008",
                Titre = "Badlands",
                AnnéeSortie = "2025",
                Prix = 10.5m,
                Synopsis = "Un Predator exilé trouve un allié androïde et part traquer l’adversaire ultime.",
                Appartient = new[] { catDrame },
                CheminFichier = @"C:\Films\Badlands.mp4"
            };
            film8.CréditFilm.Add(new CréditFilm(film8, cameron, TypeRôle.Réalisateur));
            Films.Add(film8);

            // Affiches
            film1.Affiche = @"C:\Users\nazif\Pictures\Affiches\Ong-bak.jpg";
            film2.Affiche = @"C:\Users\nazif\Pictures\Affiches\The Dark Knight.jpg";
            film3.Affiche = @"C:\Users\nazif\Pictures\Affiches\Avatar.jpg";
            film4.Affiche = @"C:\Users\nazif\Pictures\Affiches\Dune.jpg";
            film5.Affiche = @"C:\Users\nazif\Pictures\Affiches\LeSeigneurdesAnneaux.jpg";
            film6.Affiche = @"C:\Users\nazif\Pictures\Affiches\DjangoUnchained.jpg";
            film7.Affiche = @"C:\Users\nazif\Pictures\Affiches\Titanic.jpg";
            film8.Affiche = @"C:\Users\nazif\Pictures\Affiches\Badlands.jpg";
        }



    }
}

