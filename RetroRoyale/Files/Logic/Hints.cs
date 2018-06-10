using RetroGames.Files.CsvReader;
using RetroRoyale.Files.CsvHelpers;

namespace RetroRoyale.Files.Logic
{
    public class Hints : Data
    {
        public Hints(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public int TownHallLevelMin { get; set; }

        public int TownHallLevelMax { get; set; }

        public string iOSTID { get; set; }

        public string AndroidTID { get; set; }
    }
}