

using System.ComponentModel.DataAnnotations.Schema;

namespace P2EFAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<Inventory> OrderContents { get; set; }
       
        [ForeignKey("User")]
        public int FK_UserId { get; set; }
    }
}
