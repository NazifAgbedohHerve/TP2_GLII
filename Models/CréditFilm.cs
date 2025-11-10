using System;
using System.Collections.Generic;

public class CréditFilm
{
    private TypeRôle rôle;
    private Film film;
    private Personne personne;

    public TypeRôle Rôle
    {
        get => rôle;
        set => rôle = value;
    }

    public Film Film
    {
        get => film;
        set => film = value;
    }

    public Personne Personne
    {
        get => personne;
        set => personne = value;
    }

    public CréditFilm() { }

    public CréditFilm(Film film, Personne personne, TypeRôle rôle)
    {
        this.film = film;
        this.personne = personne;
        this.rôle = rôle;
    }

    public override string ToString()
    {
        return $"{personne?.Nom} ({rôle})";
    }
}

