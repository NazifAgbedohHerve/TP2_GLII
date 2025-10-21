using System;

public class Compte {
	private String numéro;
	private String solde;

	private Paiement[] sur;
	private CarteCrédit[] rattaché_à_;
	private CarteCrédit par_défaut;

	private Membre possède;
	private TxApprovisionnement[] vers;
	private TxRemboursement[] de_;

}
