﻿using System;
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
        public Cart(Guid orderID, Guid customerID_FK, int cartRedBricks, int cartBlueBricks, int cartYellowBricks)
        {
            OrderID = orderID;
            CustomerID_FK = customerID_FK;
            CartRedBricks = cartRedBricks;
            CartBlueBricks = cartBlueBricks;
            CartYellowBricks = cartYellowBricks;
        }

        Guid OrderID { get; set; }
        Guid CustomerID_FK { get; set; }
        int CartRedBricks { get; set; } = 0;
        int CartBlueBricks { get; set; } = 0;
        int CartYellowBricks { get; set; } = 0;
        //to do: maybe price?

    }
}
