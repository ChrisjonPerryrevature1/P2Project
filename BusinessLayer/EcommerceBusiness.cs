using Models;
using RepoLayer;

namespace BusinessLayer
{
    public class EcommerceBusiness
    {

        private readonly EcommerceRepo _repoLayer;
        public EcommerceBusiness()
        {
            this._repoLayer = new EcommerceRepo();
        }

        public async Task<Customers> RegisterCustomerAsync(Customers customer)
        {
            Customers newCustomer = await this._repoLayer.RegisterCustomerAsync(customer);
            return newCustomer;
        }

        public async Task<Customers> LoginAsync(Customers login)
        {
            Customers newLogin = await this._repoLayer.LoginAsync(login);
            return newLogin;
        }

        public async Task<List<Inventory>> ViewInventoryAsync()
        {
            List<Inventory> ViewInventory = await this._repoLayer.ViewInventoryAsync();
            return ViewInventory;
        }

        public async Task<Cart> FillCartAsync(Cart cart)
        {
            Cart FilledCart = await this._repoLayer.FillCartAsync(cart);
            return FilledCart;
        }

        public async Task<Cart> EditCartAsync(Cart cart)
        {
            Cart editedCart = await this._repoLayer.EditCartAsync(cart);
            return editedCart;
        }
    }
}