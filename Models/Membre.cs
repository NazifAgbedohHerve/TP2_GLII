using System;

public class Membre : Utilisateur , Visiteur  {
	private String numéro;
	private String nom;
	private String prénom;
	private String adresse;
	private String téléphone;
	private String adresseCourriel;
	private String aAcceptéRecevoirNotifications;
	private String nomUsager;
	private String motDePasse;
	private String languePréférée;

	public Membre ValiderInfoConnexion(ref string identifiant, ref string motDePasse) {
		throw new System.NotImplementedException("Not implemented");
	}

	private Catégorie[] a_des_préférences;
	private Compte possède;
	private TxAbonnement a_actuellement;

}
