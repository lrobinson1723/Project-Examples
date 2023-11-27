using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Search
    {
        public static void SearchByTitle()
        {
            Console.WriteLine("Enter a game title to search:");
            string searchQuery = Console.ReadLine();

            var filteredGames = Program.gameData.Where(game =>
                game.GameTitle.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)
            ).Take(Program.GamesPerPage);

            Program.PrintFilteredGames(filteredGames);
            PDFClass.AskToSaveAsPDF(filteredGames);
        }

        public static void SearchByGenre()
        {
            Console.WriteLine("Enter a genre to search:");
            string searchQuery = Console.ReadLine();

            Console.WriteLine("Select game type: (1) Singleplayer, (2) Multiplayer, (3) Both");
            string gameTypeChoice = Console.ReadLine();

            bool isSingleplayer = false;
            bool isMultiplayer = false;

            if (gameTypeChoice == "1")
            {
                isSingleplayer = true;
            }
            else if (gameTypeChoice == "2")
            {
                isMultiplayer = true;
            }
            else if (gameTypeChoice == "3")
            {
                isSingleplayer = true;
                isMultiplayer = true;
            }

            Console.WriteLine("Do you want to filter by tag? (yes/no)");
            string tagChoice = Console.ReadLine();
            string tagFilter = null;

            if (tagChoice.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Enter the tag to filter:");
                tagFilter = Console.ReadLine();
            }

            var filteredGames = Program.gameData.Where(game =>
                game.Genres.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)
                && ((isSingleplayer && game.Categories.Contains("Single-player", StringComparison.OrdinalIgnoreCase))
                    || (isMultiplayer && game.Categories.Contains("Multi-player", StringComparison.OrdinalIgnoreCase)))
                && (string.IsNullOrEmpty(tagFilter) || game.Tags.Contains(tagFilter, StringComparison.OrdinalIgnoreCase))
            ).Take(Program.GamesPerPage);

            Program.PrintFilteredGames(filteredGames);
            PDFClass.AskToSaveAsPDF(filteredGames);
        }


        public static void SearchByPrice()
        {
            Console.WriteLine("Enter the maximum price:");
            double? maxPrice = Program.ParseNullableDouble(Console.ReadLine());

            Console.WriteLine("Do you want to filter by genre? (yes/no)");
            string genreChoice = Console.ReadLine();

            string genreFilter = null;
            string tagFilter = null;

            if (genreChoice.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Enter the genre to filter:");
                genreFilter = Console.ReadLine();

                Console.WriteLine("Do you want to filter by tag? (yes/no)");
                string tagChoice = Console.ReadLine();

                if (tagChoice.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Enter the tag to filter:");
                    tagFilter = Console.ReadLine();
                }
            }

            var filteredGames = Program.gameData.Where(game =>
                game.Price <= maxPrice
                && (string.IsNullOrEmpty(genreFilter) || game.Genres.Contains(genreFilter, StringComparison.OrdinalIgnoreCase))
                && (string.IsNullOrEmpty(tagFilter) || game.Tags.Contains(tagFilter, StringComparison.OrdinalIgnoreCase))
            ).Take(Program.GamesPerPage);

            Program.PrintFilteredGames(filteredGames);
            PDFClass.AskToSaveAsPDF(filteredGames);
        }


        public static void SearchByTag()
        {
            Console.WriteLine("Enter a tag to search:");
            string searchQuery = Console.ReadLine();

            var filteredGames = Program.gameData.Where(game =>
                game.Tags.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)
            ).Take(Program.GamesPerPage);

            Program.PrintFilteredGames(filteredGames);
            PDFClass.AskToSaveAsPDF(filteredGames);
        }

        public static void SearchRecommendedGames()
        {
            Console.WriteLine("Enter a genre to filter the recommended games:");
            string genreFilter = Console.ReadLine();

            Console.WriteLine("Enter a tag to filter the recommended games (leave blank for no tag filter):");
            string tagFilter = Console.ReadLine();

            var filteredGames = Program.gameData.Where(game =>
                (game.PositiveRatings > game.NegativeRatings || (game.PositiveRatings == 0 && game.NegativeRatings == 0))
                && game.Genres.Contains(genreFilter, StringComparison.OrdinalIgnoreCase)
                && (string.IsNullOrWhiteSpace(tagFilter) || game.Tags.Contains(tagFilter, StringComparison.OrdinalIgnoreCase))
            ).Take(Program.GamesPerPage);

            Program.PrintFilteredGames(filteredGames);
            PDFClass.AskToSaveAsPDF(filteredGames);
        }
    }
}
