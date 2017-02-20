using System;


namespace StockTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            var stock = new Stock("APPL");
            stock.Price = 27.10M;

            stock.PriceChanged += (sender, e) =>
            {
                if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
                    Console.WriteLine("Alert, 10% stock price increase");
            };

            stock.Price = 31.59M;
        }
    }

    public class PriceChangedEventArgs : EventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;

        public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
        {
            LastPrice = lastPrice;
            NewPrice = newPrice;
        }
    }

    public class Stock
    {
        string symbol;
        decimal price;

        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        public Stock(string symbol) { this.symbol = symbol; }

        protected virtual void OnPriceChanged
            (PriceChangedEventArgs e) => PriceChanged?.Invoke(this, e);

        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value) return;
                decimal oldPrice = price;
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
            }
        }
    }
}
