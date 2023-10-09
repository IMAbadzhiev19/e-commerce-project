using ECommerceProject.Data.Models.ECommerce;

namespace ECommerceProject.Services.Contracts.ECommerce;

public interface ICommentService
{
    Task<Guid> CreateComment(string userId, Guid productId, string text);

    Task RemoveComment(string userId, Guid commentId);

    Task<List<Comment>> GetComments(Guid productId); 
}
