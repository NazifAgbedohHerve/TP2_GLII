using System;

public class TxAbonnement : Transaction  {
	private String valideDepuis;
	private String valideJusqua;
	private String renouvellementAuto;

	private AbonnementPlan abonnementPlan;
	private Paiement[] g�n�re;

	private Membre a_actuellement;

}
