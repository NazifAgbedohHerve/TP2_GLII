using System;

public class Session {
	private String numéro;
	private String dateConnexion;
	private String dateDéconnexion;

	public void DemanderFormInscriptionMembre() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherFormInscriptionMembre() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void ConfirmerInscriptionMembre(ref Membre membre) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void DemanderFormInscriptionAdmin() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherFormInscriptionAdmin() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void ConfirmerInscriptionAdmin(ref Administrateur admin) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void DemanderFormOuvertureSession() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherFormOuvertureSession() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void ValiderInfoConnexion(ref string identifiant, ref string motDePasse) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherMessageConnexionRéussie() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void DemanderFormulaireRechercheFilms() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherMessageÉchecConnexion() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherFormulaireRechercheFilms() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void RechercherFilms(ref string critères) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherFilms(ref Film[] films) {
		throw new System.NotImplementedException("Not implemented");
	}
	public Film SélectionnerFilm() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherDescriptionFilm(ref Film film) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void VisionnerFilm(ref Film film) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void VisualiserDataStreaming(ref DataStream dataStream) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void ConsulterHistoriqueTransactions(ref Client client) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherTransactions(ref Transaction transactions) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void ConsulterHistoriqueVisonnements(ref Réalisateur réalisateur) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AfficherVisionnements(ref TxVisionnement[] visionnements) {
		throw new System.NotImplementedException("Not implemented");
	}

	private Transaction[] fait;
	private Cote[] cote;

	private Visiteur s'authentifie;

}
