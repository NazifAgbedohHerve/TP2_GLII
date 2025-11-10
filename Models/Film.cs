using System;
using System.Collections.Generic;
using TP2_GLII.Model;
using TP2_GLII.Models;

public class Film
{
    private string numéro;
    private string titre;
    private string annéeSortie;
    private string durée;
    private decimal prix;
    private string synopsis;
    private StatutDisponible statut;
    private string motsClés;

    private BandeAnnonce[] bande_Annonces;
    private Catégorie[] appartient;
    private LanguePiste[] offre;
    private TxVisionnement[] concerne;
    private Cote[] cote;

    private List<CréditFilm> créditFilm = new List<CréditFilm>();

    public List<CréditFilm> CréditFilm { get; set; } = new List<CréditFilm>();


    // Accesseurs publics (pour liaison WPF et logique)
    public string Numéro { get => numéro; set => numéro = value; }
    public string Titre { get => titre; set => titre = value; }
    public string AnnéeSortie { get => annéeSortie; set => annéeSortie = value; }
    public string Durée { get => durée; set => durée = value; }
    public decimal Prix { get => prix; set => prix = value; }
    public string Synopsis { get => synopsis; set => synopsis = value; }
    public StatutDisponible Statut { get => statut; set => statut = value; }
    public string MotsClés { get => motsClés; set => motsClés = value; }

    public string CheminFichier { get; set; } // exemple : "Videos/Inception.mp4"


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

    public void Visionner(Membre membre)
    {
        if (membre == null)
            return;

        // Enregistrer le visionnement comme transaction
        var tx = new TxVisionnement
        {
            Film = this,
            Date = DateTime.Now,
            Membre = membre,
            ModeAccès = membre.AbonnementActuel != null ? ModeAccès.Abonnement : ModeAccès.A_L_Unité
        };

        DataStore.Transactions.Add(tx);
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

