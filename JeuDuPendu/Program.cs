/* Auteur : Fillastre Lukas
 * 
 * Date : 21.05.2025
 * 
 * Description : M3 - Jeu du pendu
*/

namespace JeuDuPendu
{
    internal class Program
    {
        const string FICHIER_MOTS = "mots.txt";

        static void Main()
        {
            List<char> lettresJouées = SaisirLettre();
            string motCacher = ChoixMot();

            Console.WriteLine($"{motCacher}");

            Console.WriteLine("+--+---      Lettres jouées :");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("+-------");
        }

        static List<char> SaisirLettre(int nbreLettre = 1)
        {
            List<char> lettresJouees = new List<char>();
            bool continuerSaisie = true;

            do
            {
                Console.Write("Quelle lettre voulez-vous jouer ? ");
                if (char.TryParse(Console.ReadLine(), out char lettreSaisie))
                {
                    lettresJouees.Add(lettreSaisie);

                }
                else if (lettresJouees.Count >= nbreLettre)
                {
                    continuerSaisie = false;
                }
                else
                {
                    Console.WriteLine("Votre saisie est invalide.\n");
                }
            } while (continuerSaisie);

            return lettresJouees;
        }

        static string ChoixMot()
        {
            if (!File.Exists(FICHIER_MOTS))
            {
                Console.WriteLine($"Fichier introuvable : {FICHIER_MOTS}");
            }

            List<string> listeMots = File.ReadAllLines(FICHIER_MOTS).ToList();
            Random hasard = new Random();
            int indexAleatoire = hasard.Next(listeMots.Count);
            string motChoisi = listeMots[indexAleatoire];

            return motChoisi;
        }
    }
}
