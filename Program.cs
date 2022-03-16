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
            bool annuler = false;
            bool iscompleted = false;
            decimal somme = 0;
            decimal change;
            while (true)
            {
                Board.Print();
                int selection = GetSelection();
                {
                    Candy bonbon = GetCandy(selection);
                    do
                    {
                        if (bonbon.Stock > 0)
                        {
                            Board.Print(bonbon.Name, selection, price: bonbon.Price, received: somme, result: "",
                                returned: 0.00m);
                            decimal coin;
                            coin = GetCoin();
                            if (coin != 0.00m)
                            {
                                if (somme < bonbon.Price)
                                {
                                    somme = somme + coin;
                                    Board.Print(bonbon.Name, selection, price: bonbon.Price, received: somme, result: "",
                                        returned: 0.00m);
                                    Console.WriteLine(bonbon.Price);
                                }

                                if (somme > bonbon.Price)
                                {
                                    iscompleted = true;
                                    bonbon.Stock--;
                                    candies[selection - 1].Stock--;
                                    change = Math.Abs(bonbon.Price - somme);
                                    Board.Print("prener votre bonbon", selection, price: bonbon.Price, received: somme,
                                        result: bonbon.Name, returned: change);
                                }
                            }

                            if (coin == 0.00m)
                            {
                                annuler = true;
                                Board.Print("Annuler", selection, price: bonbon.Price, received: somme, result: "", returned: coin);
                            }
                        }

                        if (bonbon.Stock == 0)
                        {
                            {
                                Board.Print(bonbon.Name + " VIDE!", selection);
                            }
                        }
                    } while (iscompleted == false && annuler == false);
                }
                Console.WriteLine("\nAppuyez sur une touche pour acheter d'autre bonbon...");
                Console.ReadKey();
            }
        }

        public static int GetSelection()
        {
            int selection;
            do
            {
                Console.Write("->");
                selection = int.Parse(Console.ReadLine());
            } while (selection > 25 || selection < 0);

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

