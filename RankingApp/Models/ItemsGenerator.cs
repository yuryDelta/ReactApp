namespace RankingApp.Models
{
    public class ItemsGenerator
    {
        private static readonly CurrencyBase[] MainCurrencies = new[]
{
            //"Euro", "GBP", "USD", "Swiss Franc", "Australian Dollar", "Canadian Dollar", "Japanese Yen", "Chinese Yuan", "Kuwaiti Dinar", "Bahraini Dinar"
            // new CurrencyBase() { CurrencyName= "Euro", Base = 1},
            new CurrencyBase() { CurrencyName= "GBP", Base = 0.86},
            new CurrencyBase() { CurrencyName= "USD", Base = 1.08},
            new CurrencyBase() { CurrencyName= "Swiss Franc", Base = 0.94},
            new CurrencyBase() { CurrencyName= "Australian Dollar", Base = 1.64},
            new CurrencyBase() { CurrencyName= "Canadian Dollar", Base = 1.47},
            new CurrencyBase() { CurrencyName= "Japanese Yen", Base = 159.46},
            new CurrencyBase() { CurrencyName= "Chinese Yuan", Base = 7.72},
            new CurrencyBase() { CurrencyName= "Kuwaiti Dinar", Base = 0.33},
            new CurrencyBase() { CurrencyName= "Bahraini Dinar", Base = 0.41},

        };

        public static List<Item> GetAllItems()
        {
            List<Item> items = new List<Item>();
            int i = 0;
            foreach (CurrencyBase currency in MainCurrencies)
            {
                var item = new Item()
                {
                    Id = i,
                    BidPrice = i == 0 ? 0.85 : Math.Round(currency.Base - GetRandomNumber(0.01, 0.2), 2),
                    AskPrice = i == 0 ? 0.87 : Math.Round(currency.Base + GetRandomNumber(0.01, 0.2), 2),
                    ItemName = currency.CurrencyName,
                };
                items.Add(item);
                i++;
            }
            return items;
        }

        public static List<Item> GetConfiguredItems(List<CurrencyConfig>? options)
        {
            List<Item> items = new List<Item>();
            int i = 0;
            foreach (CurrencyBase currency in MainCurrencies)
            {   
                var active = options?.FirstOrDefault(c => c.Id == i)?.Active;
                var item = new Item()
                {
                    Id = i,
                    BidPrice = i == 0 ? 0.85 : Math.Round(currency.Base - GetRandomNumber(0.01, 0.2), 2),
                    AskPrice = i == 0 ? 0.87 : Math.Round(currency.Base + GetRandomNumber(0.01, 0.2), 2),
                    ItemName = currency.CurrencyName,
                };
                if(active ??= true)
                    items.Add(item);
                i++;
            }
            return items;
        }

        public static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
