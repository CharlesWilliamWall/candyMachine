namespace Projet01
{
    public class Program
    {
        private static Candy[] candies; //variable globale
        private static Candy bonbon;
        public static void Main() // main xD
        {
            Data dataManager = new Data(); //chargement des données
            candies = dataManager.LoadCandies();
            bool annuler; bool iscompleted; decimal somme = 0; decimal change; // variable bool et decimal
            while (true)
            {
                Board.Print();//plus tard dans le board print on va inserer les 2 objets de Candy prix et nom ainsi que des variable comme la selection la somme et le change
                int selection = GetSelection();//Appel de selectiom
                {
                    Candy bonbon = GetCandy(selection);//selection vas choisir le bon candy et lappel
                    do//babyshark
                    {
                        annuler = false;//on les remet a false en recommencant la boucle
                        iscompleted = false;
                        if (bonbon.Stock == 0)//on verifie le stock
                        {
                            annuler = true;// on annuler devien true pour sortir de la boucle
                            Board.Print(bonbon.Name + " VIDE!", selection, returned:somme); // on retourne le change si yen a juste au cas et on affiche comme quoi le bonbon est vide
                        }
                        if (bonbon.Stock != 0)// si ya le stock on rentre 
                        {
                            decimal coin;
                            Board.Print(bonbon.Name, selection, price: bonbon.Price, received: somme, result: "", returned: 0.00m);
                            coin = GetCoin();//on apppel getcoin
                            if (coin != 0.00m) //on verifie que lutilisateur de rentre pas de 0 pour annuler
                            {
                                if (somme < bonbon.Price) //si somme est plus petit alors
                                {
                                    iscompleted = false; //pour rester dans cest condition
                                    somme = somme + coin;//on addiotione
                                    Board.Print(bonbon.Name, selection, price: bonbon.Price, received: somme, result: "", returned: 0.00m);//on imprime largent recu
                                }
                                if (somme >= bonbon.Price)//si la somme ou egale au prix
                                {
                                    iscompleted = true;//pour sortir de la boucle et pouvoir recommencer si on le desire
                                    change = Math.Abs(bonbon.Price - somme);//on redonne le change avec la soustraction
                                    Board.Print("prener votre bonbon", selection, price: bonbon.Price, received: somme, result: bonbon.Name, returned: change);//on imprime le resultat du bonbon + le change
                                    candies[selection - 1].Stock--;//on decrement le stock du bonbon apres lachat fini
                                }
                            }
                            if (coin == 0.00m)//si lutilisateur rentre le input 0 de get coin
                            {
                                annuler = true;//annuler devien true pour pouvois sortir de la boucle et recommencer
                                Board.Print("Annuler", selection, price: bonbon.Price, received: somme, result: "", returned: somme);//on affiche Annuler dans la machine
                            }
                        }
                    } while (annuler == false && iscompleted == false);// nos false pour rester dans la boucle
                    somme = 0.00m;//remmetre le compteur somme a 0
                }
                Console.WriteLine("\nAppuyez sur une touche pour acheter d'autre bonbon...");//on demande a lutilisateur si il veut recommencer en appuyant sur une touche
                Console.ReadKey();// on lis
            }
        }
        public static int GetSelection()
        {
            int selection; string mauvaischoix;//pour le tryparse
            do
            {
                Console.Write("->");
                mauvaischoix = Console.ReadLine();
                int.TryParse(mauvaischoix, out selection);// on try parse pour voir si lutilisateur a entre une mauvais touche
            } while (selection > 25 || selection < 1 || selection == 0);//tant que cest pas une selection valide
            return selection;// on retourne la selection
        }
        public static Candy GetCandy(int selection)
        {
            return candies[selection - 1];// on retourne la selection -1 vu que candies est un tableau pour pouvoir aller chercher le candy
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
            coin = decimal.Parse(Console.ReadLine());// on approprit la valeur de chaque coin
            {
                switch (coin)
                {
                    case 0: return 0.00m;
                    case 1: return 0.05m;
                    case 2: return 0.10m;
                    case 3: return 0.25m;
                    case 4: return 1.00m;
                    case 5: return 2.00m;
                    default: return 0.00m;// on retourne la valeur
                }
            }
        }
    }
}

