using System;
using TP2_GLII.Model;

public class Membre : Utilisateur   {
	private String numero;
	private String nom { get ; set; }
    private String prénom { get; set; }
    private String adresse { get; set; }
    private String telephone { get; set; }
    private String adresseCourriel { get; set; }
    private bool aAccepteRecevoirNotifications { get; set; }
    private String nomUsager { get; set; }
    private String motDePasse { get; set; }
    private String languePreferee { get; set; }

    // Accesseurs publics
    public string Numero { get => numero; set => numero = value; }
    public string Nom { get => nom; set => nom = value; }
    public string Prénom { get => prénom; set => prénom = value; }
    public string Adresse { get => adresse; set => adresse = value; }
    public string Telephone { get => telephone; set => telephone = value; }
    public string AdresseCourriel { get => adresseCourriel; set => adresseCourriel = value; }
    public bool AAccepteRecevoirNotifications { get => aAccepteRecevoirNotifications; set => aAccepteRecevoirNotifications= value; }
    public string NomUsager { get => nomUsager; set => nomUsager = value; }
    public string MotDePasse { get => motDePasse; set => motDePasse = value; }
    public string LanguePreferee { get => languePreferee; set => languePreferee = value; }

    public Membre ValiderInfoConnexion(ref string identifiant, ref string motDePasse)
    {
        // On considère identifiant = nomUsager 
        if (nomUsager == identifiant && this.motDePasse == motDePasse)
            return this;
        return null;
    }

    private Compte possède;

    public Compte Compte
    {
        get => possède;
        set => possède = value;
    }

    private Catégorie[] a_des_préférences;
	private Compte possede { get; set; }
    private TxAbonnement a_actuellement { get; set; }

    public Compte Possède { get => possede; set => possede = value; }
    public TxAbonnement A_Actuellement { get => a_actuellement; set => a_actuellement = value; }


}
