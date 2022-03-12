namespace Projet01
{
    public class Program
    {
        private static Candy[] candies;//variable globale
        public static void Main()
        {
            //chargement des données
            Candy[] candies = new Candy[25];
            Data DataManager = new Data(); 
            candies = DataManager.LoadCandies();
            GetSelection();
            GetCandy();
        }
        public static int GetSelection()
        {
            int selection = 0;
            do
            {
                Board.Print();
                Console.Write("->");
                selection = int.Parse(Console.ReadLine());
            } while (selection > 0 && selection < 25);
            
            if (selection > 25 || selection < 0)
            {
                Console.WriteLine("entrer une nouvelle selection");
                Console.Write("->");
                selection = int.Parse(Console.ReadLine());
            }
            return selection;
        }
        public static Candy[] GetCandy()
        {
            return candies;
        }
    }
}