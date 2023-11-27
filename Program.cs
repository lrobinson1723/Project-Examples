using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace FinalProject
{
    public class Program
    {
        public static List<SteamGames> gameData;
        public const int GamesPerPage = 47;

        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Expected exactly one argument, the path to the data file");
                Environment.Exit(1);
            }

            string dataFile = "steamProject.csv";
            gameData = SteamDataLoader.LoadSteamGamesFromCSV(dataFile);

            Console.WriteLine("Welcome to the Steam Game Browser! Find a collection of games and download their purchasing information!");

            while (true)
            {
                Console.WriteLine("What would you like to search by? Title, Genre, Price, Tag, Recommended Games");
                string searchOption = Console.ReadLine().ToUpper();

                if (searchOption == "TITLE")
                {
                    Search.SearchByTitle();
                }
                else if (searchOption == "GENRE")
                {
                    Search.SearchByGenre();
                }
                else if (searchOption == "PRICE")
                {
                    Search.SearchByPrice();
                }
                else if (searchOption == "TAG")
                {
                    Search.SearchByTag();
                }
                else if (searchOption == "RECOMMENDED GAMES")
                {
                    Search.SearchRecommendedGames();
                }

                Console.WriteLine("Would you like to start over? (yes/no)");
                string restartChoice = Console.ReadLine();
                if (restartChoice.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    
                    break;
                }
            }
        }
        public static void PrintFilteredGames(IEnumerable<SteamGames> filteredGames)
        {
            Console.WriteLine($"Found {filteredGames.Count()} games:");
            foreach (var game in filteredGames)
            {
                Console.WriteLine(game);
            }

            if (!filteredGames.Any())
            {
                Console.WriteLine("No games found.");
            }
        }
        public static double? ParseNullableDouble(string value)
        {
            if (double.TryParse(value, out double result))
            {
                return result;
            }

            return null;
        }
    }
}

