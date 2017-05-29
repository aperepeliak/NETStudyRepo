namespace ShoppingCart
{
    public interface ICartDatabase
    {
        long SaveCart(Cart cart);
    }
}
