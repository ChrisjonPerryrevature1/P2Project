namespace Tests.EcommerceAPI;
using Models;
using BusinessLayer;


public class UnitTest1
{
    [Fact]
    public void CustomerIDdtoCreatedCorrectly()
    {
        //Arrange
        int id = 100;
        //Act
        CustomerIDdto dto = new CustomerIDdto
        {
            CustomerID = id
        };
        //Assert
        Assert.Equal(dto.CustomerID, id);
    }

    [Fact]
    public void CustomersModelCheck()
    {
        //Arrange
        string email = "1@g.com";
        string password = "password123";
        //Act
        Customers customer = new Customers
        {
            Email = email,
            Password = password
        };
        //Assert
        Assert.Equal(password, customer.Password);

    }

    [Fact]
    public void InventoryModelCheck()
    {
        //Arrange
        int inventoryID = 100;
        string name = "brick";
        int quantity = 50;
        decimal price = 1.00M;
        //Assert
        Inventory inv = new Inventory
        {
            ItemId = inventoryID,
            ItemName = name,
            Quantity = quantity,
            Price = price
        };
        //Act
        Assert.Equal(price, inv.Price);
    }

    //[Fact]
    //public async Task RegisterCustomerCheck()
    //{
    //    //Arrange
    //    Customers customer = new Customers();
    //    customer.Email = "email@email.com";
    //    customer.Password = "password456";
    //    Mock_RepoLayer m = new Mock_RepoLayer();
    //    EcommerceBusiness eb = new EcommerceBusiness(m);
    //    //Act
    //    Customers result = await eb.RegisterCustomerAsync(customer);
    //    //Assert
    //    Assert.Equal(result.Email, customer.Email);
    //}
}