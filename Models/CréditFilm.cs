using System;

public class Cr�ditFilm {
	private TypeR�le r�le;
    private Film film;
    private Personne personne;

    public TypeR�le R�le { get => r�le; set => r�le = value; }
    public Film Film { get => Film; set => Film = value; }
    public Personne Personne { get => Personne; set => Personne = value; }

    public Cr�ditFilm(Film film, Personne personne, TypeR�le r�le)
    {
        this.Film = film;
        this.Personne = Personne;
        this.r�le = r�le;
    }

    public override string ToString()
    {
        return $"{Personne?.Nom} ({r�le})";
    }


}
