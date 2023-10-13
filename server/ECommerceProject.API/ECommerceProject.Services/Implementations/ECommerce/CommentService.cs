using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Services.Contracts.ECommerce;
using ECommerceProject.Shared.Models.ECommerce;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Services.Implementations.ECommerce;

/// <summary>
/// A class representing the comment service
/// </summary>
public class CommentService : ICommentService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;


    /// <summary>
    /// A constructor used for injecting dependencies
    /// </summary>
    /// <param name="context"></param>
    /// <param name="user"></param>
    public CommentService(ApplicationDbContext context,UserManager<ApplicationUser> user)
    {
        this._context = context;
        this._userManager = user;
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateCommentAsync(string userId, CommentIM commentIM)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
        {
            throw new ArgumentException("This user doesn't exist");
        }

        var product = await this._context.Products.FindAsync(commentIM.ProductId);
        if (product is null)
        {
            throw new ArgumentException("This product doesn't exist");
        }

        var comment = commentIM.Adapt<Comment>();
        comment.UserId = userId;
        comment.Date = DateTime.Now;

        await _context.AddAsync(comment);
        await this._context.SaveChangesAsync();

        return comment.Id;
    }

    /// <inheritdoc/>
    public async Task RemoveCommentAsync(string userId, Guid commentId)
    {
        var comment = await _context.Comments
            .FirstOrDefaultAsync(x => x.UserId == userId && x .Id == commentId);

        if(comment == null)
        {
            throw new ArgumentException($"This comment is not yours or doesn't exist");
        }

        this._context.Remove(comment);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task<ICollection<Comment>> GetCommentsAsync(Guid productId)
    {
        var product = await this._context.Products
            .FindAsync(productId);

        if(product is null)
        {
            throw new ArgumentException("This product doesn't exist");
        }

        var comments = await _context.Comments
            .Where(c => c.ProductId == productId)
            .ToListAsync();

        if(comments is null)
        {
            throw new ArgumentException("This product doesn't have comments");
        }

        return comments;
    }
}