using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;

namespace FinalProject
{
    public static class PDFClass
    {
        public static void GeneratePDF(IEnumerable<SteamGames> games)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string savePath = Path.Combine(currentDirectory, "game_results.pdf");

            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(savePath, FileMode.Create));
            document.Open();

            
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;

            table.AddCell("Game Title");
            table.AddCell("Price");

            foreach (var game in games)
            {
                table.AddCell(game.GameTitle);
                table.AddCell(game.Price.ToString());
            }

            document.Add(table);

            document.Close();
            writer.Close();

            Console.WriteLine("PDF file saved successfully.");
        }

        public static void PDFFilteredGames(IEnumerable<SteamGames> filteredGames)
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

            Console.WriteLine("Do you want to save the results to a PDF file? (yes/no)");
            string saveToPdf = Console.ReadLine();
            if (saveToPdf.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                GeneratePDF(filteredGames);
            }
        }
        public static void AskToSaveAsPDF(IEnumerable<SteamGames> games)
        {
            Console.WriteLine("Do you want to save the results to a PDF file? (yes/no)");
            string saveToPdf = Console.ReadLine();
            if (saveToPdf.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                GeneratePDF(games);
            }
        }
    }
}
