using System;

public class Personne {
	private String numéro;
	private String nom;
	private String pays;
	private TypePersonne typePersonne;
    private List<CréditFilm> créditFilm = new List<CréditFilm>();

    // Accesseurs publics
    public string Numéro { get => numéro; set => numéro = value; }
    public string Nom { get => nom; set => nom = value; }
    public string Pays { get => pays; set => pays = value; }
    public TypePersonne TypePersonne { get => typePersonne; set => typePersonne = value; }
    public List<CréditFilm> CréditFilm { get => créditFilm; set => créditFilm = value; }

    public override string ToString() => $"{Nom} ({TypePersonne})";

}
