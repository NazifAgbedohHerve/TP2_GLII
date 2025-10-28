using System;
using System.Collections.Generic;
using TP2_GLII.Models;

public class Film
{
    private string numéro;
    private string titre;
    private string annéeSortie;
    private string durée;
    private string prix;
    private string synopsis;
    private StatutDisponible statut;
    private string motsClés;

    private BandeAnnonce[] bande_Annonces;
    private Catégorie[] appartient;
    private LanguePiste[] offre;
    private TxVisionnement[] concerne;
    private Cote[] cote;

    private List<CréditFilm> créditFilm = new List<CréditFilm>();

    public List<CréditFilm> CréditFilm { get => créditFilm; set => créditFilm = value; }

    // Accesseurs publics (pour liaison WPF et logique)
    public string Numéro { get => numéro; set => numéro = value; }
    public string Titre { get => titre; set => titre = value; }
    public string AnnéeSortie { get => annéeSortie; set => annéeSortie = value; }
    public string Durée { get => durée; set => durée = value; }
    public string Prix { get => prix; set => prix = value; }
    public string Synopsis { get => synopsis; set => synopsis = value; }
    public StatutDisponible Statut { get => statut; set => statut = value; }
    public string MotsClés { get => motsClés; set => motsClés = value; }

    public BandeAnnonce[] Bande_Annonces { get => bande_Annonces; set => bande_Annonces = value; }
    public Catégorie[] Appartient { get => appartient; set => appartient = value; }
    public LanguePiste[] Offre { get => offre; set => offre = value; }
    public TxVisionnement[] Concerne { get => concerne; set => concerne = value; }
    public Cote[] Cote { get => cote; set => cote = value; }

    //  Méthodes UML
    public void Rechercher(ref string critères)
    {
        // Représente l’action UML, logique implémentée dans le DataStore ou le Catalogue
        throw new NotImplementedException("Recherche de film non implémentée ici.");
    }

    public DataStream Visionner()
    {
        // Simulation : créer un DataStream et enregistrer un txVisionnement si besoin
        var ds = new DataStream();
        System.Diagnostics.Debug.WriteLine($"Lecture simulée du film : {Titre} (stream {ds.StreamId})");

        // Optionnel : enregistrer le visionnement dans l'historique
        if (DataStore.MembreConnecte != null)
        {
            // créer et ajouter une transaction/txVisionnement si tu as la classe TxVisionnement
            // ex: DataStore.MembreConnecte.AjouterVisionnement(new TxVisionnement(...));
        }

        return ds;
    }

    public void AjouterCrédit(Personne personne, TypeRôle rôle)
    {
        if (personne == null) return;

        var credit = new CréditFilm(this, personne, rôle);
        créditFilm.Add(credit);

        // ajouter aussi au côté Personne
        if (personne.CréditFilm == null)
            personne.CréditFilm = new List<CréditFilm>();
        personne.CréditFilm.Add(credit);
    }
}

