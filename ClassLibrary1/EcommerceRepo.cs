﻿using Models;
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
    }
}