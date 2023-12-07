namespace RankingApp.Models
{
    public class ItemsGenerator
    {
        private static readonly CurrencyBase[] MainCurrencies = new[]
        {
            /* "Euro", "GBP", "USD", "Swiss Franc", "Australian Dollar", "Canadian Dollar", "Japanese Yen", "Chinese Yuan", "Kuwaiti Dinar", "Bahraini Dinar" */
            new CurrencyBase() { Id = 0, CurrencyName= "GBP", Base = 0.86},
            new CurrencyBase() { Id = 1, CurrencyName= "USD", Base = 1.08},
            new CurrencyBase() { Id = 2, CurrencyName= "Swiss Franc", Base = 0.94},
            new CurrencyBase() { Id = 3, CurrencyName= "Australian Dollar", Base = 1.64},
            new CurrencyBase() { Id = 4, CurrencyName= "Canadian Dollar", Base = 1.47},
            new CurrencyBase() { Id = 5, CurrencyName= "Japanese Yen", Base = 159.46},
            new CurrencyBase() { Id = 6, CurrencyName= "Chinese Yuan", Base = 7.72},
            new CurrencyBase() { Id = 7, CurrencyName= "Kuwaiti Dinar", Base = 0.33},
            new CurrencyBase() { Id = 8, CurrencyName= "Bahraini Dinar", Base = 0.41},

        };

        public static List<Item> GetConfiguredItems(List<CurrencyConfig>? options)
        {
            List<Item> items = new List<Item>();
            if (options is null)
            {
                return items;
            }
            ;
            foreach (CurrencyConfig itemConfigured in options)
            {
                if(!itemConfigured.Active)
                    continue;
                var currency = MainCurrencies.FirstOrDefault(c => c.Id == itemConfigured.Id)!;
                var item = new Item()
                {
                    Id = itemConfigured.Id,
                    /* make first BidPrice value static (no change during generation */
                    BidPrice = itemConfigured.Id == 0 ? 0.85 : Math.Round(currency.Base - GetRandomNumber(0.01, 0.2), 2),
                    /* make first AskPrice value static (no change during generation */
                    AskPrice = itemConfigured.Id == 0 ? 0.87 : Math.Round(currency.Base + GetRandomNumber(0.01, 0.2), 2),
                    ItemName = itemConfigured.Name,
                };
                items.Add(item);
            }
            return items;
        }

        /* generate values in the range */
        private static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
