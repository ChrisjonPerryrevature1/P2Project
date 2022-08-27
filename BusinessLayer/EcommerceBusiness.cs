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

    }
}