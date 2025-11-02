using System;
using TP2_GLII.Models;

public class Visiteur
{
    private Session[] sessions;
    public void ConsulterCatalogue()
    {
        Console.WriteLine("Affichage du catalogue des films (visiteur).");
    }

    public void DemanderFormulaireInscription()
    {
        Console.WriteLine("Affichage du formulaire d’inscription membre.");
    }

    public void SInscrire()
    {
        Session session = new Session();
        Membre nouveau = new Membre();
        session.ConfirmerInscriptionMembre(ref nouveau);
    }
}

