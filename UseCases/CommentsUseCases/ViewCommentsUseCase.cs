using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBusiness.Entities;
using DataStore.SQL;

namespace UseCases
{
    public class ViewCommentsUseCase : IViewCommentsUseCase
    {
        private readonly ICommentRepo commentRepo;
        public ViewCommentsUseCase(ICommentRepo commentRepo)
        {
            this.commentRepo = commentRepo;

        }
        public IEnumerable<Comment> Execute(Guid productId)
        {
            return commentRepo.GetCommentsByProductId(productId);
        }

    }
}
