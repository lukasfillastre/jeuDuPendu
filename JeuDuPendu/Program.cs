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
        const int MAX_ERREURS = 6;

        static void Main()
        {
            var lettresJouees = new List<char>();
            string motCacher = ChoixMot();
            if (motCacher == null)
            {
                return;
            }
            motCacher = motCacher.ToUpper();

            int erreurs = 0;

            while (erreurs < MAX_ERREURS && !MotEntierTrouve(motCacher, lettresJouees))
            {
                Console.ResetColor();
                Console.Clear();
                AfficherPendu(erreurs);

                Console.Write("Lettres jouées : ");
                foreach (char lettrePresente in lettresJouees)
                {
                    if (motCacher.Contains(lettrePresente))
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(lettrePresente + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();

                AfficherMotCache(motCacher, lettresJouees);

                char nouvelle = SaisirLettre(lettresJouees);
                lettresJouees.Add(nouvelle);

                erreurs = CompterErreurs(lettresJouees, motCacher);
            }

            Console.ResetColor();
            Console.Clear();
            AfficherPendu(erreurs);
            AfficherMotCache(motCacher, lettresJouees);

            if (MotEntierTrouve(motCacher, lettresJouees))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vous avez gagné ! Bravo !");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Vous avez perdu ! Le mot était {motCacher}");
            }

            Console.ResetColor();
            Console.WriteLine("\nAppuyez sur une touche pour quitter...");
            Console.ReadKey();
        }



        static char SaisirLettre(List<char> dejaJouees)
        {
            bool continuerSaisie = true;
            char saisieUtilisateur = '\0';

            while (continuerSaisie)
            {
                Console.Write("\nQuelle lettre voulez-vous jouer ? ");
                string saisie = Console.ReadLine();

                if (saisie != null && saisie.Length == 1)
                {
                    char saisi = char.ToUpper(saisie[0]);
                    if (saisi < 'A' || saisi > 'Z')
                    {
                        Console.WriteLine("Votre saisie est invalide.\n");
                    }
                    else if (dejaJouees.Contains(saisi))
                    {
                        Console.WriteLine("Vous avez déjà joué cette lettre.\n");
                    }
                    else
                    {
                        saisieUtilisateur = saisi;
                        continuerSaisie = false;
                    }
                }
                else
                {
                    Console.WriteLine("Votre saisie est invalide.\n");
                }
            }

            return saisieUtilisateur;
        }

        /// <summary>
        /// Compte le nombre de lettres dans lettresJouees qui ne sont pas dans le mot.
        /// </summary>
        static int CompterErreurs(List<char> lettresJouees, string mot)
        {
            int erreurs = 0;
            foreach (char mauvauseLettre in lettresJouees)
            {
                if (!mot.Contains(mauvauseLettre))
                    erreurs++;
            }
            return erreurs;
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

        /// <summary>
        /// Affiche le mot caché.
        /// </summary>
        static void AfficherMotCache(string mot, List<char> lettresJouees)
        {
            foreach (char lettreTrouve in mot)
            {
                Console.Write(lettresJouees.Contains(lettreTrouve) ? lettreTrouve + " " : "_ ");
            }
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Vérifie si toutes les lettres du mot ont été trouvées.
        /// </summary>
        static bool MotEntierTrouve(string mot, List<char> lettresJouees)
        {
            return mot.All(trouver => lettresJouees.Contains(trouver));
        }

        /// <summary>
        /// Affiche la potence en fonction du nombre d'erreurs (de 0 à 6).
        /// </summary>
        static void AfficherPendu(int erreurs)
        {
            string ligne1 = "+--+---";
            string ligne2 = "|";
            string ligne3 = "|";
            string ligne4 = "|";
            string ligne5 = "|";
            string ligne6 = "|";
            string ligne7 = "+-------";

            if (erreurs >= 1)
            {
                ligne2 = "|  |";
            }
            if (erreurs >= 2)
            {
                ligne3 = "|  O";
            }
            if (erreurs >= 3)
            {
                ligne4 = "|  |";
            }
            if (erreurs >= 4)
            {
                ligne4 = "| /|";
            }
            if (erreurs >= 5)
            {
                ligne4 = "| /|\\";
            }
            if (erreurs >= 6)
            {
                ligne5 = "| / \\";
            }

            Console.WriteLine(ligne1);
            Console.WriteLine(ligne2);
            Console.WriteLine(ligne3);
            Console.WriteLine(ligne4);
            Console.WriteLine(ligne5);
            Console.WriteLine(ligne6);
            Console.WriteLine(ligne7);
            Console.WriteLine();
        }
    }
}
