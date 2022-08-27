namespace Models
{
    public class Customers
    {
        public Customers()
        {

        }
        public Customers(Guid customerID, string email, string password)
        {
            CustomerID = customerID;
            Email = email;
            Password = password;
        }

        Guid CustomerID { get; set; }
        String Email { get; set; } = "";
        String Password { get; set; } = "";
    }
}