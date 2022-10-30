namespace GalaxyApi.ViewModels
{
    public class SpeciesViewModel
    {
        public string RowKey { get; set; }
        public string Name { get; set; }
        public int SpeciesCount { get; set; }
    }

    public class SpeciesCreateViewModel
    {
        public string RowKey { get; set; }
        public string Name { get; set; }
    }
}