using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cart
    {
        public Cart()
        {

        }
        public Cart(int customerID_FK, int cartRedBricks, int cartBlueBricks, int cartYellowBricks)
        {
            CustomerID_FK = customerID_FK;
            CartRedBricks = cartRedBricks;
            CartBlueBricks = cartBlueBricks;
            CartYellowBricks = cartYellowBricks;
        }

        public int CustomerID_FK { get; set; }
        public int CartRedBricks { get; set; } = 0;
        public int CartBlueBricks { get; set; } = 0;
        public int CartYellowBricks { get; set; } = 0;
        //to do: maybe price?

    }
}
