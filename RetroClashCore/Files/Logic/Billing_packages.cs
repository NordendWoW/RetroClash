using RetroClashCore.Files.CsvHelpers;
using RetroClashCore.Files.CsvReader;

namespace RetroClashCore.Files.Logic
{
    public class Billing_packages : Data
    {
        public Billing_packages(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public bool Disabled { get; set; }

        public int Diamonds { get; set; }

        public int USD { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public string ShopItemExportName { get; set; }
    }
}