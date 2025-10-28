using System;

public class Membre : Utilisateur   {
	private String numero;
	private String nom { get ; set; }
    private String prénom { get; set; }
    private String adresse { get; set; }
    private String telephone { get; set; }
    private String adresseCourriel { get; set; }
    private bool aAcceptéRecevoirNotifications { get; set; }
    private String nomUsager { get; set; }
    private String motDePasse { get; set; }
    private String languePreferee { get; set; }

    // Accesseurs publics
    public string Numéro { get => numero; set => numero = value; }
    public string Nom { get => nom; set => nom = value; }
    public string Prénom { get => prénom; set => prénom = value; }
    public string Adresse { get => adresse; set => adresse = value; }
    public string Telephone { get => telephone; set => telephone = value; }
    public string AdresseCourriel { get => adresseCourriel; set => adresseCourriel = value; }
    public bool AAccepterRecevoirNotifications { get => aAcceptéRecevoirNotifications; set => aAcceptéRecevoirNotifications= value; }
    public string NomUsager { get => nomUsager; set => nomUsager = value; }
    public string MotDePasse { get => motDePasse; set => motDePasse = value; }
    public string LanguePreferee { get => languePreferee; set => languePreferee = value; }

    public Membre ValiderInfoConnexion(ref string identifiant, ref string motDePasse) {
		throw new System.NotImplementedException("Not implemented");
	}

	private Catégorie[] a_des_préférences;
	private Compte Compte { get; set; }
    private TxAbonnement a_actuellement { get; set; }

}
