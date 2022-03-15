namespace Projet01
{
    public class Program
    {
        private static Candy[] candies; //variable globale
        private static Candy bonbon;
        public static void Main()
        {
            Board.Print();
            Console.Write("->");
            //chargement des données
            Data dataManager = new Data();
            candies = dataManager.LoadCandies();
            int selection = GetSelection();
            Candy bonbon = GetCandy(selection);
            decimal somme = 0;
            decimal change;
            // while (true)
            Board.Print(bonbon.Name, selection, price: bonbon.Price, received: somme, result: "", returned: 0.00m);
            if (bonbon.Stock == 0)
            {
                Board.Print(bonbon.Name + " VIDE!");
                Console.WriteLine("stock vide ;<( appuyer sur une touche pour faire un autre choix");
                Console.ReadKey();
                Main();
            }
            // if (user enter zero)
            { 
                change = somme - bonbon.Price;
                Board.Print("Annuler", selection, price: bonbon.Price, received: somme, result: "", returned: change);
                Console.WriteLine("au revoir: appuyer une touche pour commencer...");
                Console.ReadKey();
                Main();
            }
            do
            {
                somme = somme + GetCoin();
                Board.Print(bonbon.Name, selection, price: bonbon.Price, received: somme, result: "", returned: 0.00m);
            } while (somme < bonbon.Price);

            if (bonbon.Price <= somme) ;
            {
                change = somme - bonbon.Price;
                Board.Print("prener votre bonbon", selection, price: bonbon.Price, received: somme, result: bonbon.Name,
                    returned: change);
            }
            bonbon.Stock = -1;// need to verify it
            Console.WriteLine("\nAppuyez sur une touche pour acheter d'autre bonbon...");
            Console.ReadKey();
            Main();
        }
        public static int GetSelection()
        {
            int selection;
            // Board.Print();
            // Console.Write("->");
            selection = int.Parse(Console.ReadLine());
            if (selection > 25 || selection == 0 || selection == 'a')
            {
                Console.WriteLine("mauvais choix");
                Console.Write("->");
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
            decimal coin;
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
