using System;

namespace TestHypotheek
{
    public class HypotheekCalculator
    {
        public static void Run()
        {
            double inkomen = HypotheekHelper.GetInkomen();
            int rentevastePeriode = HypotheekHelper.GetRentevastePeriode();
            double rentepercentage = HypotheekHelper.GetRentePercentage(rentevastePeriode);
            double partnerInkomen = HypotheekHelper.GetPartnerInkomen();
            bool studieschuldStatus = HypotheekHelper.GetStudieschuldStatus();
            bool geldigePostcode = HypotheekHelper.GetGeldigePostcodeStatus();

            if (!geldigePostcode) { return; }

            double maxHypotheeklast = HypotheekHelper.GetMaxHypotheeklast(inkomen, partnerInkomen, studieschuldStatus);
            double rentePercentagePerMaand = (rentepercentage / 100) / 12;
            double leningBedrag = HypotheekHelper.GetLeningBedrag(maxHypotheeklast);
            double renteBetalenPerMaand = Math.Round(rentePercentagePerMaand * leningBedrag, 2);
            double aflossingPerMaand = Math.Round(leningBedrag / 360.0, 2);
            double totaalMaandBedrag = Math.Round(renteBetalenPerMaand + aflossingPerMaand, 2);
            double betaaldNaDertigJaar = Math.Round(totaalMaandBedrag * 360.0, 2);

            Console.WriteLine("\n---------------------------------------------------");

            Console.WriteLine($"Totaal maandBedrag: {totaalMaandBedrag}\nRente betalen per maand: {renteBetalenPerMaand}\nAflossing betalen per maand: {aflossingPerMaand}\nBetaald na dertig jaar: {betaaldNaDertigJaar}");
        }
    }
}
