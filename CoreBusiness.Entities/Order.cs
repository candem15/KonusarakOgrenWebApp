using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBusiness.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItems> OrderItems { get; set; }
        public Customer Customer { get; set; }
    }
}