using System;

public class Film {
	private String num�ro;
	private String titre;
	private String ann�eSortie;
	private String dur�e;
	private String prix;
	private String synopsis;
	private StatutDisponible statut;
	private String motsCl�s;

	public void Rechercher(ref string crit�res) {
		throw new System.NotImplementedException("Not implemented");
	}
	public DataStream Visionner() {
		throw new System.NotImplementedException("Not implemented");
	}

	private Bande-Annonce[] bande-Annonces;
	private Cat�gorie[] appartient;
	private LanguePiste[] offre;
	private Cr�ditFilm[] cr�ditFilm;

	private TxVisionnement[] concerne;
	private Cote[] cote;

}
