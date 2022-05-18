using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBusiness.Entities
{
    public class Comment
    {
        [Key]
        public Guid CommentId { get; set; }
        [Required]
        public Guid? ProductId { get; set; }
        [Required]
        public Guid? CustomerId { get; set; }
        [Required]
        public string ProductComment { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}