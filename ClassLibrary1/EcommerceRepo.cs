using Models;
using System.Data.SqlClient;

namespace RepoLayer
{
    public class EcommerceRepo
    {

        public async Task<Customers> RegisterCustomerAsync(Customers customer)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:mathiasriverasqlserver1.database.windows.net,1433;Initial Catalog=RainbowRoadP2;Persist Security Info=False;User ID=MathiasRiveraRevature1;Password=JohnDaniel(9);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO Customers (Email, Password) VALUES (@Email, @Password)", conn))
            {
                command.Parameters.AddWithValue("@Email", customer.Email); //SQL inj prevention
                command.Parameters.AddWithValue("@Password", customer.Password); //SQL inj prevention

                conn.Open();
                int ret = await command.ExecuteNonQueryAsync();
                while (ret>0)
                {
                    return customer;
                }
                conn.Close();
                return null;
            }
        }
        public async Task<Customers> LoginAsync(Customers login)
        {

            SqlConnection conn = new SqlConnection("Server=tcp:mathiasriverasqlserver1.database.windows.net,1433;Initial Catalog=RainbowRoadP2;Persist Security Info=False;User ID=MathiasRiveraRevature1;Password=JohnDaniel(9);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT Email,Password FROM Customers WHERE Email = @Email AND Password = @Password", conn))
            {
                command.Parameters.AddWithValue("@Email", login.Email); //SQL inj prevention
                command.Parameters.AddWithValue("@Password", login.Password); //SQL inj prevention

                conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Customers? newLogin = new Customers(ret.GetString(0), ret.GetString(1));
                    conn.Close();
                    return newLogin;
                }
            }
            conn.Close();
            return null;
        }

        public async Task<List<Inventory>> ViewInventoryAsync()
        {
            SqlConnection conn = new SqlConnection("Server=tcp:mathiasriverasqlserver1.database.windows.net,1433;Initial Catalog=RainbowRoadP2;Persist Security Info=False;User ID=MathiasRiveraRevature1;Password=JohnDaniel(9);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT*FROM Inventory", conn))
            {
                conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                List<Inventory> rlist = new List<Inventory>();
                while (ret.Read())
                {
                    Inventory r = new Inventory(ret.GetInt32(0), ret.GetString(1), ret.GetInt32(2), ret.GetDecimal(3));
                    rlist.Add(r);
                }
                conn.Close();
                return rlist;
            }


        }

        public async Task<Cart> FillCartAsync(Cart cart)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:mathiasriverasqlserver1.database.windows.net,1433;Initial Catalog=RainbowRoadP2;Persist Security Info=False;User ID=MathiasRiveraRevature1;Password=JohnDaniel(9);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO Cart (CustomerID_FK, RedBricks, BlueBricks, YellowBricks) VALUES (@CustomerID_FK, @RedBricks, @BlueBricks, @YellowBricks)", conn))
            {
                command.Parameters.AddWithValue("@CustomerID_FK", cart.CustomerID_FK); //SQL inj prevention
                command.Parameters.AddWithValue("@RedBricks", cart.CartRedBricks); //SQL inj prevention
                command.Parameters.AddWithValue("@BlueBricks", cart.CartBlueBricks); //SQL inj prevention
                command.Parameters.AddWithValue("@YellowBricks", cart.CartYellowBricks); //SQL inj prevention


                conn.Open();
                int ret = await command.ExecuteNonQueryAsync();
                while (ret > 0)
                {
                    return cart;
                }
                conn.Close();
                return null;
            }
        }

        public async Task<Cart> EditCartAsync(Cart cart)
        {

            SqlConnection conn = new SqlConnection("Server=tcp:mathiasriverasqlserver1.database.windows.net,1433;Initial Catalog=RainbowRoadP2;Persist Security Info=False;User ID=MathiasRiveraRevature1;Password=JohnDaniel(9);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"UPDATE Cart SET CustomerID_FK = @CustomerID_FK, RedBricks = @RedBricks, BlueBricks = @BlueBricks, YellowBricks = @YellowBricks WHERE CustomerID_FK = @CustomerID_FK", conn))
            {
                command.Parameters.AddWithValue("@CustomerID_FK", cart.CustomerID_FK); //SQL inj prevention
                command.Parameters.AddWithValue("@RedBricks", cart.CartRedBricks); //SQL inj prevention
                command.Parameters.AddWithValue("@BlueBricks", cart.CartBlueBricks); //SQL inj prevention
                command.Parameters.AddWithValue("@YellowBricks", cart.CartYellowBricks); //SQL inj prevention


                conn.Open();
                int ret = await command.ExecuteNonQueryAsync();
                while (ret > 0)
                {
                    return cart;
                }
                conn.Close();
                return null;
            }
        }

        public async Task<Orders> CheckoutCartAsync(CustomerIDdto customer)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:mathiasriverasqlserver1.database.windows.net,1433;Initial Catalog=RainbowRoadP2;Persist Security Info=False;User ID=MathiasRiveraRevature1;Password=JohnDaniel(9);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO Orders SELECT CustomerID_FK, RedBricks, BlueBricks, YellowBricks FROM Cart WHERE CustomerID_FK = @CustomerID_FK; SELECT * FROM Inventory MINUS SELECT * FROM Orders WHERE CustomerID_FK = @CustomerID_FK; DELETE FROM Cart WHERE CustomerID_FK = @CustomerID_FK;", conn))
            {
                command.Parameters.AddWithValue("@CustomerID_FK", customer.CustomerID); //SQL inj prevention

                conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Orders? r = new Orders(ret.GetInt32(0), ret.GetInt32(1), ret.GetInt32(2), ret.GetInt32(3), ret.GetInt32(4));
                    conn.Close();
                    return r;
                }
            }
            conn.Close();
            return null;
        
        }
    }   
}