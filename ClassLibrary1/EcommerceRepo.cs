namespace RepoLayer
{
    public class EcommerceRepo
    {
        /* public async Task<List<Request>> RequestsAsync(int type)
         {
             SqlConnection conn = new SqlConnection("Server=tcp:mathiasriverasqlserver1.database.windows.net,1433;Initial Catalog=RainbowRoadP2;Persist Security Info=False;User ID=MathiasRiveraRevature1;Password=JohnDaniel(9);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
             using (SqlCommand command = new SqlCommand($"SELECT * FROM Request WHERE Status = @type", conn))
             {
                 command.Parameters.AddWithValue("@type", type); //SQL inj prevention
                 conn.Open();
                 SqlDataReader? ret = await command.ExecuteReaderAsync();
                 List<Request> rlist = new List<Request>();
                 while (ret.Read())
                 {
                     Request r = new Request((Guid)ret[0], (Guid)ret[1], ret.GetString(2), ret.GetDecimal(3), ret.GetInt32(4));
                     rlist.Add(r);
                 }
                 conn.Close();
                 return rlist;
             }

         } */
    }
}