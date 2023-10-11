using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Shared.Models.ECommerce;

namespace ECommerceProject.Services.Contracts.ECommerce;

public interface ICommentService
{
    Task<Guid> CreateComment(string userId, CommentIM commentIM);

    Task RemoveComment(string userId, Guid commentId);

    Task<ICollection<Comment>> GetComments(Guid productId); 
}