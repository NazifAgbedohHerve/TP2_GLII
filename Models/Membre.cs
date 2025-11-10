using System;
using TP2_GLII.Model;
using TP2_GLII.Models;

public class Membre : Utilisateur
{
    // --- Attributs ---
    private string numero;
    private string nom;
    private string prénom;
    private string adresse;
    private string telephone;
    private string adresseCourriel;
    private bool aAccepteRecevoirNotifications;
    private string nomUsager;
    private string motDePasse;
    private string languePreferee;

    // --- Propriétés publiques ---
    public string Numero { get => numero; set => numero = value; }
    public string Nom { get => nom; set => nom = value; }
    public string Prénom { get => prénom; set => prénom = value; }
    public string Adresse { get => adresse; set => adresse = value; }
    public string Telephone { get => telephone; set => telephone = value; }
    public string AdresseCourriel { get => adresseCourriel; set => adresseCourriel = value; }
    public bool AAccepteRecevoirNotifications { get => aAccepteRecevoirNotifications; set => aAccepteRecevoirNotifications = value; }
    public string NomUsager { get => nomUsager; set => nomUsager = value; }
    public string MotDePasse { get => motDePasse; set => motDePasse = value; }
    public string LanguePreferee { get => languePreferee; set => languePreferee = value; }

    // --- Relations UML ---
    public Compte Compte { get; set; } = new Compte();   // un membre possède un compte
    public TxAbonnement AbonnementActuel { get; set; }   // abonnement actif (optionnel)
    public List<Catégorie> Préférences { get; set; } = new List<Catégorie>();

    // --- Méthodes ---
    public Membre ValiderInfoConnexion(string identifiant, string motDePasse)
    {
        if (NomUsager.Equals(identifiant, StringComparison.OrdinalIgnoreCase)
            && MotDePasse == motDePasse)
            return this;

        return null;
    }

    // Abonnement
    public TxAbonnement SAbonner(AbonnementPlan plan, bool renouvellementAuto = true)
    {
        if (AbonnementActuel != null && AbonnementActuel.Statut == "Actif")
            throw new InvalidOperationException("Vous avez déjà un abonnement actif.");

        var tx = new TxAbonnement
        {
            Numéro = Guid.NewGuid().ToString(),
            Date = DateTime.Now,
            AbonnementPlan = plan,
            ValideDepuis = DateTime.Now,
            ValideJusqua = DateTime.Now.AddMonths(1),
            RenouvellementAuto = renouvellementAuto,
            Statut = "Actif"
        };

        AbonnementActuel = tx;
        DataStore.Transactions.Add(tx);

        return tx;
    }

}

