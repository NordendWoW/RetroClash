using RetroClashCore.Files.CsvHelpers;
using RetroClashCore.Files.CsvReader;

namespace RetroClashCore.Files.Logic
{
    public class Globals : Data
    {
        public Globals(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public int NumberValue { get; set; }

        public bool BooleanValue { get; set; }

        public string TextValue { get; set; }

        public int NumberArray { get; set; }

        public string StringArray { get; set; }

        public int AndroidNumberValue { get; set; }

        public bool AndroidBooleanValue { get; set; }

        public string AndroidTextValue { get; set; }

        public int AndroidNumberArrayValue { get; set; }

        public string AndroidStringArrayValue { get; set; }
    }
}