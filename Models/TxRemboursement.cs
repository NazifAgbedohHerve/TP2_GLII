using System;
using TP2_GLII.Model;

public class TxRemboursement : Transaction
{
    private decimal montant;
    private Compte de_;
    private Paiement sur;

    public decimal Montant { get => montant; set => montant = value; }
    public Compte De_ { get => de_; set => de_ = value; }
    public Paiement Sur { get => sur; set => sur = value; }

    public override string ResumeTransaction()
    {
        return $"Remboursement de {Montant:C} sur la transaction {Sur?.Numéro}";
    }
}
