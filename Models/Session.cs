using System;
using System.Windows;
using TP2_GLII.Model;
using TP2_GLII.Models;

namespace TP2_GLII.Models
{
    public class Session {
	private String numéro;
	private String dateConnexion;
	private String dateDéconnexion;

    // Relation UML : une session peut faire des transactions, des cotes, etc.
    private List<Transaction> fait = new List<Transaction>();
    private List<Cote> cote = new List<Cote>();

    // Association avec un visiteur (optionnelle, peut être null)
    private Visiteur s_authentifie;

    //  Accesseurs publics 
    public string Numéro { get => numéro; set => numéro = value; }
    public string DateConnexion { get => dateConnexion; set => dateConnexion = value; }
    public string DateDéconnexion { get => dateDéconnexion; set => dateDéconnexion = value; }
    public Visiteur SAUTHENTIFIE { get => s_authentifie; set => s_authentifie = value; }


    public void FermerSession()
    {
        DateDéconnexion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Console.WriteLine($"Session {Numéro} fermée à {DateDéconnexion}.");
    }

    public void DemanderFormInscriptionMembre()
    {
        Console.WriteLine("Affichage du formulaire d'inscription membre (FenetreInscription).");
    }

    public void AfficherFormInscriptionMembre()
    {
        Console.WriteLine("Affiche la fenêtre d'inscription membre.");
    }

    public void ConfirmerInscriptionMembre(ref Membre membre)
    {
        // Attribution d’un identifiant unique à la session
        Numéro = Guid.NewGuid().ToString();
        DateConnexion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        Console.WriteLine($"Session {Numéro} ouverte pour le membre {membre.NomUsager}.");

        // On ajoute le membre au DataStore (comme simulé dans ton projet)
        if (!DataStore.Membres.Contains(membre))
        {
            DataStore.Membres.Add(membre);
            DataStore.MembreConnecte = membre;
        }

        // Relation : cette session appartient à un visiteur qui s’est authentifié
        if (s_authentifie == null)
            s_authentifie = new Visiteur();

        // Optionnel : afficher confirmation
        AfficherMessageConnexionRéussie();
    }

    public void AfficherMessageConnexionRéussie()
    {
        Console.WriteLine("Connexion réussie !");
    }

    public void AfficherMessageÉchecConnexion()
    {
        Console.WriteLine("Échec de la connexion.");
    }

        public Membre ValiderInfoConnexion(string identifiant, string motDePasse)
        {
            // Recherche d'un membre existant
            Membre membre = DataStore.Membres.FirstOrDefault(m =>
                m.NomUsager.Equals(identifiant, StringComparison.OrdinalIgnoreCase)
                && m.MotDePasse == motDePasse);

            if (membre != null)
            {
                // Créer une session logique
                Numéro = Guid.NewGuid().ToString();
                DateConnexion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                DataStore.MembreConnecte = membre;

                Console.WriteLine($"Connexion réussie de {membre.NomUsager}, session {Numéro}");

                return membre;
            }

            Console.WriteLine("Échec de connexion.");
            return null;
        }


        public void DemanderFormInscriptionAdmin() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherFormInscriptionAdmin() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void ConfirmerInscriptionAdmin(ref Administrateur admin) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void DemanderFormOuvertureSession() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherFormOuvertureSession() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void ValiderInfoConnexion(ref string identifiant, ref string motDePasse) {
		throw new System.NotImplementedException("Not implemented");
	}

        //    Recherche et catalogue
        public void DemanderFormulaireRechercheFilms()
        {
            Console.WriteLine("Affichage du formulaire de recherche de films (FenetreCatalogue).");
        }

        public Film[] RechercherFilms(string critere)
        {
            var resultats = DataStore.Films
                .Where(f =>
                    (!string.IsNullOrEmpty(f.Titre) && f.Titre.Contains(critere, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(f.MotsClés) && f.MotsClés.Contains(critere, StringComparison.OrdinalIgnoreCase)))
                .ToArray();

            Console.WriteLine($"{resultats.Length} film(s) trouvé(s) pour '{critere}'.");
            return resultats;
        }

        public void AfficherFilms(Film[] films)
        {
            foreach (var f in films)
                Console.WriteLine($"- {f.Titre} ({f.AnnéeSortie})");
        }

        public Film SélectionnerFilm(Film film)
        {
            Console.WriteLine($"Film sélectionné : {film.Titre}");
            return film;
        }

        public void AfficherDescriptionFilm(ref Film film)
        {
            Console.WriteLine($"Détails du film : {film.Titre}\nSynopsis : {film.Synopsis}");
        }

        //    Visionnement

        public void VisionnerFilm(Film film, ModeAccès mode)
        {
            if (film == null || DataStore.MembreConnecte == null)
            {
                MessageBox.Show("Veuillez vous connecter pour visionner un film.");
                return;
            }

            var membre = DataStore.MembreConnecte;
            var compte = membre.Compte;

            // 🔹 Crée une nouvelle transaction
            var tx = new TxVisionnement
            {
                Film = film,
                Compte = compte,
                Membre = membre,
                ModeAccès = mode,
                Numéro = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                Prix = film.Prix
            };

            DataStore.Transactions.Add(tx);

            Console.WriteLine($" {membre.NomUsager} visionne {film.Titre} ({mode})");
        }

        //  Historique Transactions

        public void ConsulterHistoriqueTransactions( Membre membre)
        {
            var transactions = DataStore.Transactions
                .Where(t => (t as TxVisionnement)?.Membre == membre)
                .ToArray();

            Console.WriteLine($"Historique pour {membre.NomUsager} : {transactions.Length} transaction(s)");
            AfficherTransactions(ref transactions);
        }

        public void AfficherTransactions(ref Transaction[] transactions)
        {
            foreach (var tx in transactions)
                Console.WriteLine(tx.ResumeTransaction());
        }
        // Historique Visionnements
        
        public void ConsulterHistoriqueVisionnements(ref Personne realisateur)
        {
            var tx = new TxVisionnement();
            var visionnements = tx.ConsulterHistoriquePourUnRéalisateur(realisateur);
            AfficherVisionnements(ref visionnements);
        }

        public void AfficherVisionnements(ref TxVisionnement[] visionnements)
        {
            foreach (var v in visionnements)
                Console.WriteLine($"- {v.Film.Titre} visionné par {v.Membre.NomUsager}");
        }

    }
}

