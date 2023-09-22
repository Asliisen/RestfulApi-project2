public interface IProductService
{
    List<Product> GetProducts();
    Product GetProductById(int id);
    void CreateProduct(Product product);
    void UpdateProduct(int id, Product updatedProduct);
    void DeleteProduct(int id);

}
