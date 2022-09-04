using Models;

namespace BusinessLayer
{
    public interface IEcommerceBusiness
    {
        Task<Cart> EditCartAsync(Cart cart);
        Task<Cart> FillCartAsync(Cart cart);
        Task<Customers> LoginAsync(Customers login);
        Task<Customers> RegisterCustomerAsync(Customers customer);
        Task<List<Inventory>> ViewInventoryAsync();
    }
}