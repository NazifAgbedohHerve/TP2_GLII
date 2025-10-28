using System;

public class Personne {
	private String num�ro;
	private String nom;
	private String pays;
	private TypePersonne typePersonne;
    private List<Cr�ditFilm> cr�ditFilm = new List<Cr�ditFilm>();

    // Accesseurs publics
    public string Num�ro { get => num�ro; set => num�ro = value; }
    public string Nom { get => nom; set => nom = value; }
    public string Pays { get => pays; set => pays = value; }
    public TypePersonne TypePersonne { get => typePersonne; set => typePersonne = value; }
    public List<Cr�ditFilm> Cr�ditFilm { get => cr�ditFilm; set => cr�ditFilm = value; }

    public override string ToString() => $"{Nom} ({TypePersonne})";

}
