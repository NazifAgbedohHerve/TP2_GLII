using System;

namespace TP2_GLII.Model
{
    public class AbonnementPlan
    {
        private string numéro;
        private string nom;
        private decimal prixMensuel;
        private int limiteAppareils;

        private TxAbonnement[] basé_sur;

        public string Numéro { get => numéro; set => numéro = value; }
        public string Nom { get => nom; set => nom = value; }
        public decimal PrixMensuel { get => prixMensuel; set => prixMensuel = value; }
        public int LimiteAppareils { get => limiteAppareils; set => limiteAppareils = value; }
        public TxAbonnement[] BaséSur { get => basé_sur; set => basé_sur = value; }

        public AbonnementPlan(string numero, string nom, decimal prix)
        {
            Numéro = numero;
            Nom = nom;
            PrixMensuel = prix;
        }

        public override string ToString()
        {
            return $"{Nom} ({PrixMensuel:C}/mois, {LimiteAppareils} appareils)";
        }
    }
}
