public class ProductService : IProductService
{
    private readonly List<Product> _products;

    public ProductService()
    {
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.99M },
            new Product { Id = 2, Name = "Product 2", Price = 20.49M },
            new Product { Id = 3, Name = "Product 3", Price = 15.99M }
        };
    }

    public List<Product> GetProducts()
    {
        return _products;
    }

    public Product GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    // The process of creating a new product.
    // Automatically determines the ID of the product and adds it to the list.
    public void CreateProduct(Product product)
    {
        product.Id = _products.Max(p => p.Id) + 1;
        _products.Add(product);
    }

    // The process of updating an existing product.
    // Finds the product by ID and updates it with updated information
    public void UpdateProduct(int id, Product updatedProduct)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == id);
        if (existingProduct != null)
        {
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;
        }
    }

    public void DeleteProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _products.Remove(product);
        }
    }
}
