using System.Security.Cryptography;

namespace Projet01
{
    public class Program
    {
        private static Candy[] candies;//variable globale
        public static void Main()
        {
            //chargement des données
            Data dataManager = new Data();
            candies = dataManager.LoadCandies();
            decimal Sommerecu = 0m;
            Board.Print();
            Console.Write("->");
            while (true)
            {
                int selection = GetSelection();
                Candy bonbon = GetCandy(selection);
                Board.Print(bonbon.Name, selection , bonbon.Price);
                Console.Write("->");
                do
                {
                    Board.Print(received: Sommerecu);
                    GetCoin();
                    Sommerecu = Sommerecu + GetCoin();
                } while (selection > 0);

                if (bonbon.Stock == 0)
                {
                    Board.Print(bonbon.Name + " VIDE!");
                }
            }
        }
        public static int GetSelection()
        {
            int selection;
            do
            {
                selection = int.Parse(Console.ReadLine());
            } while (selection < 0 || selection > 26);
            return selection;
        }
        public static Candy GetCandy(int selection)
        {
            return candies[selection -1];
        }

        public static decimal GetCoin()
        {
            bool IsCompleted;
            bool IsCanceled;
            // choix 0 = annule;
            decimal[] choix = new decimal[6];
            // int prix = choix;
            decimal coin = 0;
            choix[0] = coin;
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("[0] = Annuler");
                Console.WriteLine("[1] = 5c");
                Console.WriteLine("[2] = 10c");
                Console.WriteLine("[3] = 25c");
                Console.WriteLine("[4] = 1$");
                Console.WriteLine("[5] = 2$");
                choix[1] = 0.05m;
                choix[2] = 0.10m;
                choix[3] = 0.25m;
                choix[4] = 1.00m;
                choix[5] = 2.00m;
                choix[i] = decimal.Parse(Console.ReadLine());
            }
            return coin;
        }






    }
}