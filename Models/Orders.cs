using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Orders
    {
        public Orders(int orderID, int customerID_FK, int purchasedRedBricks, int purchasedBlueBricks, int parchasedYellowBricks)
        {
            OrderID = orderID;
            CustomerID_FK = customerID_FK;
            PurchasedRedBricks = purchasedRedBricks;
            PurchasedBlueBricks = purchasedBlueBricks;
            ParchasedYellowBricks = parchasedYellowBricks;
        }

        public int OrderID { get; set; }
        public int CustomerID_FK { get; set; }
        public int PurchasedRedBricks { get; set; } = 0;
        public int PurchasedBlueBricks { get; set; } = 0;
        public int ParchasedYellowBricks { get; set; } = 0;
    }
}
