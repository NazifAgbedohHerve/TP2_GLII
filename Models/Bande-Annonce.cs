using System;

public class BandeAnnonce {
	private String numéro;
	private String durée;
	private String bande;

	private Film film;


    //  Accesseurs publics
    public string Numéro { get => numéro; set => numéro = value; }
    public string Durée { get => durée; set => durée = value; }
    public string Bande { get => bande; set => bande = value; }
    public Film FilmParent
    {
        get { return film; }
        private set { film = value; } 
    }

    //  Constructeur
    public BandeAnnonce(string numero, string duree, string bande, Film film)
    {
        this.numéro = numero;
        this.durée = duree;
        this.bande = bande;
        this.film = film;
    }

    //  Méthode de lecture simulée
    public void Lire()
    {
        Console.WriteLine($"Lecture de la bande-annonce du film {film.Titre}");
    }

}
