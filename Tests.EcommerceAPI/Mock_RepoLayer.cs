using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoLayer;
using BusinessLayer;
using Models;
using System.Data.SqlClient;

namespace Tests.EcommerceAPI
{
    public class Mock_RepoLayer : IEcommerceRepo
    {
        public async Task<Customers> RegisterCustomerAsync(Customers customer)
        {
            await Task.Delay(100);
            throw new NotImplementedException();
        }
        public async Task<Customers> LoginAsync(Customers login)
        {
            await Task.Delay(100);
            throw new NotImplementedException();
        }

        public async Task<List<Inventory>> ViewInventoryAsync()
        {
            await Task.Delay(100);
            throw new NotImplementedException();
        }

        public async Task<Cart> FillCartAsync(Cart cart)
        {
            await Task.Delay(100);
            throw new NotImplementedException();
        }

        public async Task<Cart> EditCartAsync(Cart cart)
        {
            await Task.Delay(100);
            throw new NotImplementedException();
        }
    }
}
