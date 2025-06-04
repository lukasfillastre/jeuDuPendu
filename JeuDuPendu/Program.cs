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
            string motChoisi = string.Empty;

            try
            {
                if (File.Exists(FICHIER_MOTS))
                {
                    var mots = File.ReadAllLines(FICHIER_MOTS).ToList();
                    if (mots.Count > 0)
                    {
                        var aleatoire = new Random();
                        motChoisi = mots[aleatoire.Next(mots.Count)];
                    }
                    else
                    {
                        Console.WriteLine("Le fichier est vide. Aucun mot disponible.");
                    }
                }
                else
                {
                    Console.WriteLine($"Fichier introuvable : {FICHIER_MOTS}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lecture fichier : {ex.Message}");
            }

            return motChoisi;
        }
    }
}
