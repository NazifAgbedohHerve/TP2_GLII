using System;
using System.Collections.Generic;

public class Catégorie {
	private String numéro;
	private String nom;

    private List<Film> appartient;        // Les films de cette catégorie
    private List<Membre> a_des_préférences; // Les membres qui préfèrent cette catégorie

    // Accesseurs publics
    public string Numéro { get => numéro; set => numéro = value; }
    public string NomCategorie { get => nom; set => nom = value; }
    public List<Film> Appartient { get => appartient; set => appartient = value; }
    public List<Membre> ADesPréférences { get => a_des_préférences; set => a_des_préférences = value; }

    // Constructeurs

    public Catégorie() { }

    public Catégorie(string numero, string nom)
    {
        this.numéro = numero;
        this.nom = nom;
        appartient = new List<Film>();
        a_des_préférences = new List<Membre>();
    }

    //  Méthodes utilitaires
    public void AjouterFilm(Film film)
    {
        if (!appartient.Contains(film))
            appartient.Add(film);
    }

    public void AjouterMembre(Membre membre)
    {
        if (!a_des_préférences.Contains(membre))
            a_des_préférences.Add(membre);
    }

}
