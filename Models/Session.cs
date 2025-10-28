using System;
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

        Console.WriteLine($"Session {Numéro} ouverte pour le membre {membre.nomUsager}.");

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
            Numéro = Guid.NewGuid().ToString();
            DateConnexion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DataStore.MembreConnecte = membre;
            AfficherMessageConnexionRéussie();
            return membre;
        }
        else
        {
            AfficherMessageÉchecConnexion();
            return null;
        }
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
	
	public void DemanderFormulaireRechercheFilms() {
		throw new System.NotImplementedException("Not implemented");
	}
	
	public void AfficherFormulaireRechercheFilms() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void RechercherFilms(ref string critères) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherFilms(ref Film[] films) {
		throw new System.NotImplementedException("Not implemented");
	}
	public Film SélectionnerFilm() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherDescriptionFilm(ref Film film) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void VisionnerFilm(ref Film film) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void VisualiserDataStreaming(ref DataStream dataStream) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void ConsulterHistoriqueTransactions(ref Client client) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherTransactions(ref Transaction transactions) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void ConsulterHistoriqueVisonnements(ref Réalisateur réalisateur) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherVisionnements(ref TxVisionnement[] visionnements) {
		throw new System.NotImplementedException("Not implemented");
	}


	

}
}

