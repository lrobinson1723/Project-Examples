using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace FinalProject
{
    public static class SteamDataLoader
    {
        public static List<SteamGames> LoadSteamGamesFromCSV(string filePath)
        {
            List<SteamGames> games = new List<SteamGames>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                   
                    reader.ReadLine();

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');

                        SteamGames game = new SteamGames
                        {
                            SteamID = ParseNullableInt(fields[0]),
                            GameTitle = fields[1],
                            ReleaseDate = ParseDateTime(fields[2]),
                            Developer = fields[3],
                            Publisher = fields[4],
                            Platforms = fields[5],
                            Categories = fields[6],
                            Genres = fields[7].Trim(),
                            Tags = fields[8],
                            Achievements = ParseNullableInt(fields[9]),
                            PositiveRatings = ParseNullableInt(fields[10]),
                            NegativeRatings = ParseNullableInt(fields[11]),
                            AveragePlaytime = ParseNullableInt(fields[12]),
                            MedianPlaytime = ParseNullableInt(fields[13]),
                            Owners = ParseNullableInt(fields[14]),
                            Price = ParseNullableDouble(fields[15])
                        };
                        games.Add(game);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading game data from CSV: {e.Message}");
            }

            return games;
        }

        private static int? ParseNullableInt(string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }

            return null;
        }
        private static double? ParseNullableDouble(string value)
        {
            if (double.TryParse(value, out double result))
            {
                return result;
            }

            return null;
        }

        private static DateTime ParseDateTime(string value)
        {
            if (DateTime.TryParse(value, out DateTime result))
            {
                return result;
            }

            return DateTime.MinValue;
        }
    }
}
