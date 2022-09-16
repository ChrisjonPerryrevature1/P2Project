namespace Ecomerce.Testing;
using P2EFAPI.Models;

public class UnitTest1
{
    [Fact]
    public void UserCreatedCorrectly()
    {
        //Arrange
        int id = 100;
        //Act
        User user1 = new User
        {
            UserId = id
        };
        //Assert
        Assert.Equal(user1.UserId, id);
    }

    [Fact]
    public void inventoryTest()
    {
        // Arrange
        int id2 = 1001;
        //Act
        Inventory invent = new Inventory
        {
            ItemId = id2
        };

        //Assert
        Assert.Equal(invent.ItemId, id2);

    }
    [Fact]
    public void OrderTest()
    {
        //Arrange
        int order1id = 1200;
        //Act
        Order ord = new Order
        {
            OrderId = order1id
        };
        //Assert
        Assert.Equal(ord.OrderId, order1id);
    }
}
