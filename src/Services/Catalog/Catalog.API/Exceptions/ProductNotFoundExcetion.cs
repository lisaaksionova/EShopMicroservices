namespace Catalog.API.Exceptions
{
    public class ProductNotFoundExcetion : Exception
    {
        public ProductNotFoundExcetion() : base("Product not found.")
        {
        }
    }
}
