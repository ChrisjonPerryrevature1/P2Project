using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CustomerIDdto
    {
        public CustomerIDdto(int customerID)
        {
            CustomerID = customerID;
        }

        public int CustomerID { get; set; } 
    }
}
