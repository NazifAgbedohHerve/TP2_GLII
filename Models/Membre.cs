using System;

public class Membre : Utilisateur , Visiteur  {
	private String num�ro;
	private String nom;
	private String pr�nom;
	private String adresse;
	private String t�l�phone;
	private String adresseCourriel;
	private String aAccept�RecevoirNotifications;
	private String nomUsager;
	private String motDePasse;
	private String languePr�f�r�e;

	public Membre ValiderInfoConnexion(ref string identifiant, ref string motDePasse) {
		throw new System.NotImplementedException("Not implemented");
	}

	private Cat�gorie[] a_des_pr�f�rences;
	private Compte poss�de;
	private TxAbonnement a_actuellement;

}
