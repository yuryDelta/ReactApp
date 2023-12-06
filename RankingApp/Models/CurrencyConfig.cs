namespace RankingApp.Models
{
    public class CurrencyConfig
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }

    public class CurrencyConfigOptions
    {
        public List<CurrencyConfig>? Options { get; set; }
    }
}
