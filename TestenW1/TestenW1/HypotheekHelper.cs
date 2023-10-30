using System;

namespace TestHypotheek
{
    public static class HypotheekHelper
    {
        public static double GetInkomen()
        {
            string input;

            Console.WriteLine("Wat is jouw maandinkomen in Euro?");

            while (true)
            {
                input = Console.ReadLine()!;
                if (double.TryParse(input.Replace('.', ','), out double inkomen) && inkomen >= 1)
                {
                    return inkomen; // Return the value when it's valid
                }
                else
                {
                    Console.WriteLine("Dat is geen geldig inkomen, uw inkomen moet minimaal 1 Euro zijn. Voer een geldig inkomen in:");
                }
            }
        }

        public static int GetRentevastePeriode()
        {
            string input;

            Console.WriteLine("Welke rentevaste periode wil je? 1, 5, 10, 20 of 30 jaar?");

            while (true)
            {
                input = Console.ReadLine()!;
                if (int.TryParse(input, out int periode) && (periode == 1 || periode == 5 || periode == 10 || periode == 20 || periode == 30))
                {
                    return periode; // Return the value when it's valid
                }
                else
                {
                    Console.WriteLine("Voer een geldige periode in: 1, 5, 10, 20 of 30 (jaar):");
                }
            }
        }

        public static double GetRentePercentage(int rentePeriode)
        {
            double rentepercentage;

            switch (rentePeriode)
            {
                case 1:
                    rentepercentage = 2;
                    break;
                case 5:
                    rentepercentage = 3;
                    break;
                case 10:
                    rentepercentage = 3.5;
                    break;
                case 20:
                    rentepercentage = 4.5;
                    break;
                case 30:
                    rentepercentage = 5;
                    break;
                default:
                    rentepercentage = 5;
                    break;
            }

            return rentepercentage;
        }

        public static double GetPartnerInkomen()
        {
            string partner;
            double partnerInkomen = 0.0;

            Console.WriteLine("Heb je een partner? vul in: ja / nee");
            partner = Console.ReadLine()!;

            while (!(partner.Equals("ja", StringComparison.OrdinalIgnoreCase) || partner.Equals("nee", StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Je hebt iets verkeerds ingevuld, voer in: ja of nee");
                partner = Console.ReadLine()!;
            }

            if (partner.Equals("ja", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Wat is het maandinkomen van je partner in Euro? Een komma moet als punt aangegeven worden:");
                string input;

                while (true)
                {
                    input = Console.ReadLine()!;
                    if (double.TryParse(input.Replace('.', ','), out partnerInkomen) && partnerInkomen >= 1)
                    {
                        break;
                    }

                    Console.WriteLine("Dat is geen geldig inkomen, het inkomen van uw partner moet minimaal 1 Euro zijn. Voer een geldig inkomen in:");
                }
            }

            return partnerInkomen;
        }

        public static bool GetStudieschuldStatus()
        {
            bool studieschuld = false;
            string studieschuldInput;

            Console.WriteLine("Heb je een studieschuld? vul in: ja / nee");
            studieschuldInput = Console.ReadLine()!;

            while (!(studieschuldInput.Equals("ja", StringComparison.OrdinalIgnoreCase) || studieschuldInput.Equals("nee", StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Je hebt iets verkeerds ingevuld, voer in: ja of nee");
                studieschuldInput = Console.ReadLine()!;
            }

            if (studieschuldInput.Equals("ja", StringComparison.OrdinalIgnoreCase))
            {
                studieschuld = true;
            }

            return studieschuld;
        }

        public static bool GetGeldigePostcodeStatus()
        {
            bool geldigePostcode;
            int postcode;
            string input;

            Console.WriteLine("Voer uw postcode (nummer) in");

            while (true)
            {
                input = Console.ReadLine()!;

                if (int.TryParse(input, out postcode) && postcode >= 1000 && postcode <= 9999)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Dat is geen geldige postcode, voer een geldige postcode in (b.v. 1234):");
                }
            }

            if (postcode == 9679 || postcode == 9681 || postcode == 9682)
            {
                geldigePostcode = false;
                Console.WriteLine("Uw postcode wordt helaas niet geaccepteerd.");
            }
            else
            {
                geldigePostcode = true;
            }

            return geldigePostcode;
        }

        public static double GetMaxHypotheeklast(double inkomen, double partnerInkomen, bool studieschuldStatus)
        {
            double maxHypotheeklast;
            double totaalInkomenPerJaar = (inkomen + partnerInkomen) * 12;

            if (!studieschuldStatus)
            {
                maxHypotheeklast = totaalInkomenPerJaar * 4.25;
            }
            else
            {
                maxHypotheeklast = (totaalInkomenPerJaar * 4.25) * 0.75;
                //maxHypotheeklast = totaalInkomenPerJaar * 4; //old wrong way
            }

            return maxHypotheeklast;
        }

        public static double GetLeningBedrag(double maxHypotheeklast)
        {
            double leningBedrag;
            string input;

            Console.WriteLine($"Hoeveel wil je per jaar lenen in Euro? (max {maxHypotheeklast})");

            while (true)
            {
                input = Console.ReadLine()!;
                if (double.TryParse(input.Replace('.', ','), out leningBedrag) && leningBedrag >= 1 && leningBedrag <= maxHypotheeklast)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Voor een geldig bedrag in, minimaal 1 en maximaal {maxHypotheeklast}");
                }
            }

            return leningBedrag;
        }
    }
}
