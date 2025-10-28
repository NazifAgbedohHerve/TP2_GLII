using System;
using TP2_GLII.Model;
using TP2_GLII.Models;

namespace TP2_GLII.Models
{
    public class Session {
	private String num�ro;
	private String dateConnexion;
	private String dateD�connexion;

    // Relation UML : une session peut faire des transactions, des cotes, etc.
    private List<Transaction> fait = new List<Transaction>();
    private List<Cote> cote = new List<Cote>();

    // Association avec un visiteur (optionnelle, peut �tre null)
    private Visiteur s_authentifie;

    //  Accesseurs publics 
    public string Num�ro { get => num�ro; set => num�ro = value; }
    public string DateConnexion { get => dateConnexion; set => dateConnexion = value; }
    public string DateD�connexion { get => dateD�connexion; set => dateD�connexion = value; }
    public Visiteur SAUTHENTIFIE { get => s_authentifie; set => s_authentifie = value; }


    public void FermerSession()
    {
        DateD�connexion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Console.WriteLine($"Session {Num�ro} ferm�e � {DateD�connexion}.");
    }

    public void DemanderFormInscriptionMembre()
    {
        Console.WriteLine("Affichage du formulaire d'inscription membre (FenetreInscription).");
    }

    public void AfficherFormInscriptionMembre()
    {
        Console.WriteLine("Affiche la fen�tre d'inscription membre.");
    }

    public void ConfirmerInscriptionMembre(ref Membre membre)
    {
        // Attribution d�un identifiant unique � la session
        Num�ro = Guid.NewGuid().ToString();
        DateConnexion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        Console.WriteLine($"Session {Num�ro} ouverte pour le membre {membre.nomUsager}.");

        // On ajoute le membre au DataStore (comme simul� dans ton projet)
        if (!DataStore.Membres.Contains(membre))
        {
            DataStore.Membres.Add(membre);
            DataStore.MembreConnecte = membre;
        }

        // Relation : cette session appartient � un visiteur qui s�est authentifi�
        if (s_authentifie == null)
            s_authentifie = new Visiteur();

        // Optionnel : afficher confirmation
        AfficherMessageConnexionR�ussie();
    }

    public void AfficherMessageConnexionR�ussie()
    {
        Console.WriteLine("Connexion r�ussie !");
    }

    public void AfficherMessage�checConnexion()
    {
        Console.WriteLine("�chec de la connexion.");
    }

    public Membre ValiderInfoConnexion(string identifiant, string motDePasse)
    {
        // Recherche d'un membre existant
        Membre membre = DataStore.Membres.FirstOrDefault(m =>
            m.NomUsager.Equals(identifiant, StringComparison.OrdinalIgnoreCase)
            && m.MotDePasse == motDePasse);

        if (membre != null)
        {
            Num�ro = Guid.NewGuid().ToString();
            DateConnexion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DataStore.MembreConnecte = membre;
            AfficherMessageConnexionR�ussie();
            return membre;
        }
        else
        {
            AfficherMessage�checConnexion();
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
	public void RechercherFilms(ref string crit�res) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherFilms(ref Film[] films) {
		throw new System.NotImplementedException("Not implemented");
	}
	public Film S�lectionnerFilm() {
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
	public void ConsulterHistoriqueVisonnements(ref R�alisateur r�alisateur) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherVisionnements(ref TxVisionnement[] visionnements) {
		throw new System.NotImplementedException("Not implemented");
	}


	

}
}

