using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBusiness.Entities;

namespace DataStore.SQL
{
    public class CommentRepo :ICommentRepo
    {
        private readonly AppDbContext _context;

        public CommentRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetCommentsByProductId(Guid productId)
        {

            return _context.Comments.Where(x=>x.ProductId==productId).ToList();
        }
    }
}