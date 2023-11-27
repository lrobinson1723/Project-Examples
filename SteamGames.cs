using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class SteamGames
    {
        public int? SteamID { get; set; }
        public string GameTitle { get; set; }
        public string Developer { get; set; }
        public string Platforms { get; set; }
        public string Publisher { get; set; }
        public string Categories { get; set; }
        public string Genres { get; set; }
        public int? Achievements { get; set; }
        public int? CurrentPlayers { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? PositiveRatings { get; set; }
        public int? NegativeRatings { get; set; }
        public int? AveragePlaytime { get; set; }
        public int? MedianPlaytime { get; set; }
        public int? Owners { get; set; }
        public string Tags { get; set; }
        public double? Price { get; set; }

        public override string ToString()
        {
            return $"SteamID: {SteamID}\n" +
                   $"GameTitle: {GameTitle}\n" +
                   $"ReleaseDate: {ReleaseDate.ToShortDateString()}\n" +
                   $"Developer: {Developer}\n" +
                   $"Publisher: {Publisher}\n" +
                   $"Platforms: {Platforms}\n" +
                   $"Categories: {Categories}\n" +
                   $"Genres: {Genres}\n" +
                   $"Tags: {Tags}\n" +
                   $"Achievements: {Achievements}\n" +
                   $"PositiveRatings: {PositiveRatings}\n" +
                   $"NegativeRatings: {NegativeRatings}\n" +
                   $"AveragePlaytime: {AveragePlaytime}\n" +
                   $"MedianPlaytime: {MedianPlaytime}\n"+
                   $"Owners: {Owners}\n" +
                   $"Price: {Price}\n";
        }
    }
}
