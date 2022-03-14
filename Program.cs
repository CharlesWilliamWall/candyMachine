namespace Projet01
{
    public class Program
    {
        private static Candy[] candies; //variable globale
        private static Candy bonbon;
        public static void Main()
        {
            //chargement des données
            Data dataManager = new Data();
            candies = dataManager.LoadCandies();
            int selection = GetSelection();
            Candy bonbon = GetCandy(selection);
            decimal somme = 0;
            while (true)
            {
                Board.Print(bonbon.Name, price: bonbon.Price, received: somme, result: "xD");
                Console.Write("->");
                if (bonbon.Stock == 0)
                {
                    Board.Print(bonbon.Name + " VIDE!");
                }
                do
                {
                    somme = somme + GetCoin();
                } while (somme < bonbon.Price);
            }
        }
        public static int GetSelection()
        {
            int selection;
            Board.Print();
            Console.Write("->");
            selection = int.Parse(Console.ReadLine());
            if (selection > 25)
            {
                // Console.WriteLine("mauvais choix");
                GetSelection();
            }
            if (selection < 0)
            {
                return selection;
            }
            return selection;
        }
        public static Candy GetCandy(int selection)
        {
            return candies[selection - 1];
        }
        public static decimal GetCoin()
        {
            bool IsCompleted;
            bool IsCanceled;
            decimal coin;
            decimal sommerecu = 0.00m;
            Console.WriteLine("[0] = Annuler");
            Console.WriteLine("[1] = 5c");
            Console.WriteLine("[2] = 10c");
            Console.WriteLine("[3] = 25c");
            Console.WriteLine("[4] = 1$");
            Console.WriteLine("[5] = 2$");
            coin = decimal.Parse(Console.ReadLine());
            {
                switch (coin)
                {
                    case 0: return 0.00m;
                    case 1: return 0.05m;
                    case 2: return 0.10m;
                    case 3: return 0.25m;
                    case 4: return 1.00m;
                    case 5: return 2.00m;
                    default: return 0.00m;
                }
            }
        }
    }
}
