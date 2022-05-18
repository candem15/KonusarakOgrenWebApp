using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBusiness.Entities;

namespace DataStore.SQL
{
    public interface ICommentRepo
    {
        public IEnumerable<Comment> GetCommentsByProductId(Guid productId);
    }
}