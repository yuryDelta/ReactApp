namespace RankingApp.Models
{
    public class CurrencyConfig
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public bool Active { get; init; }
    }

    public class CurrencyConfigOptions
    {
        public List<CurrencyConfig>? Options { get; init; }
    }
}
