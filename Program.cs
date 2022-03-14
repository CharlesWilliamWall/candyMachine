namespace Projet01
{
    public class Program
    {
        private static Candy[] candies;//variable globale
        private static Candy bonbon;
        public static void Main()
        {
            //chargement des données
            Data dataManager = new Data();
            candies = dataManager.LoadCandies();
            while (true)
            {
                int selection = GetSelection();
                Candy bonbon = GetCandy(selection);
                // decimal sommerecu = GetCoin();
                // do
                // {
                //     GetCoin();
                // } while (sommerecu < bonbon.Price);
                Board.Print(bonbon.Name, selection , bonbon.Price);
                Console.Write("->");
                if (bonbon.Stock == 0)
                {
                    Board.Print(bonbon.Name + " VIDE!");
                }
            }
        }
        public static int GetSelection()
        {
            Board.Print();
            Console.Write("->");
            int selection;
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
            return candies[selection -1];
        }
        public static decimal GetCoin()
        {
            bool IsCompleted;
            bool IsCanceled;
            decimal coin;
            decimal sommerecu = 0;
            Console.WriteLine("[0] = Annuler");
            Console.WriteLine("[1] = 5c");
            Console.WriteLine("[2] = 10c");
            Console.WriteLine("[3] = 25c");
            Console.WriteLine("[4] = 1$");
            Console.WriteLine("[5] = 2$");
            coin = decimal.Parse(Console.ReadLine());
            switch (coin)
                {
                    case 0:
                        GetSelection(); break;
                }
                switch (coin)
                {
                    case 1: return 0.05m;
                }
                switch (coin)
                {
                    case 2: return 0.10m;
                }
                switch (coin)
                {
                    case 3: return 0.25m;
                }
                switch (coin)
                {
                    case 4: return 1.00m;
                }
                switch (coin)
                {
                    case 5: return 2.00m;
                }
                sommerecu = coin + sommerecu;
            return sommerecu;
        }
    }
}