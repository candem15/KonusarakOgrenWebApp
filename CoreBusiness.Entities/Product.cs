using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBusiness.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        public Guid? CategoryId { get; set; }
        [Required]
        public Guid? BrandId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public double? Price { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int ModelYear { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public List<OrderItems> OrderItems { get; set; }
        public List<Comment> Comments { get; set; }
    }
}