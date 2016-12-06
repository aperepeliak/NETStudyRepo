namespace _004_LinqExpressions
{
    class ProductInfo
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int NumberInStock { get; set; } = 0;

        public override string ToString()
        {
            return string.Format($"Name = {Name}, Description = {Description}, NumberInStock = {NumberInStock}");
        }
    }
}
