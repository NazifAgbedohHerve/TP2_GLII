using System;
using System.Collections.Generic;

public class CréditFilm {
	private TypeRôle rôle;
    private Film film;
    private Personne personne;

    public TypeRôle Rôle { get => rôle; set => rôle = value; }
    public Film Film { get => Film; set => Film = value; }
    public Personne Personne { get => Personne; set => Personne = value; }

    public CréditFilm(Film film, Personne personne, TypeRôle rôle)
    {
        this.Film = film;
        this.Personne = Personne;
        this.rôle = rôle;
    }

    public override string ToString()
    {
        return $"{Personne?.Nom} ({rôle})";
    }


}
