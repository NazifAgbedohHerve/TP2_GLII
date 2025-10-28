using System;
using System.Collections.Generic;
using TP2_GLII.Models;

public class Film
{
    private string num�ro;
    private string titre;
    private string ann�eSortie;
    private string dur�e;
    private string prix;
    private string synopsis;
    private StatutDisponible statut;
    private string motsCl�s;

    private BandeAnnonce[] bande_Annonces;
    private Cat�gorie[] appartient;
    private LanguePiste[] offre;
    private TxVisionnement[] concerne;
    private Cote[] cote;

    private List<Cr�ditFilm> cr�ditFilm = new List<Cr�ditFilm>();

    public List<Cr�ditFilm> Cr�ditFilm { get => cr�ditFilm; set => cr�ditFilm = value; }

    // Accesseurs publics (pour liaison WPF et logique)
    public string Num�ro { get => num�ro; set => num�ro = value; }
    public string Titre { get => titre; set => titre = value; }
    public string Ann�eSortie { get => ann�eSortie; set => ann�eSortie = value; }
    public string Dur�e { get => dur�e; set => dur�e = value; }
    public string Prix { get => prix; set => prix = value; }
    public string Synopsis { get => synopsis; set => synopsis = value; }
    public StatutDisponible Statut { get => statut; set => statut = value; }
    public string MotsCl�s { get => motsCl�s; set => motsCl�s = value; }

    public BandeAnnonce[] Bande_Annonces { get => bande_Annonces; set => bande_Annonces = value; }
    public Cat�gorie[] Appartient { get => appartient; set => appartient = value; }
    public LanguePiste[] Offre { get => offre; set => offre = value; }
    public TxVisionnement[] Concerne { get => concerne; set => concerne = value; }
    public Cote[] Cote { get => cote; set => cote = value; }

    //  M�thodes UML
    public void Rechercher(ref string crit�res)
    {
        // Repr�sente l�action UML, logique impl�ment�e dans le DataStore ou le Catalogue
        throw new NotImplementedException("Recherche de film non impl�ment�e ici.");
    }

    public DataStream Visionner()
    {
        // Simulation : cr�er un DataStream et enregistrer un txVisionnement si besoin
        var ds = new DataStream();
        System.Diagnostics.Debug.WriteLine($"Lecture simul�e du film : {Titre} (stream {ds.StreamId})");

        // Optionnel : enregistrer le visionnement dans l'historique
        if (DataStore.MembreConnecte != null)
        {
            // cr�er et ajouter une transaction/txVisionnement si tu as la classe TxVisionnement
            // ex: DataStore.MembreConnecte.AjouterVisionnement(new TxVisionnement(...));
        }

        return ds;
    }

    public void AjouterCr�dit(Personne personne, TypeR�le r�le)
    {
        if (personne == null) return;

        var credit = new Cr�ditFilm(this, personne, r�le);
        cr�ditFilm.Add(credit);

        // ajouter aussi au c�t� Personne
        if (personne.Cr�ditFilm == null)
            personne.Cr�ditFilm = new List<Cr�ditFilm>();
        personne.Cr�ditFilm.Add(credit);
    }
}

