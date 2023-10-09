using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Services.Contracts.ECommerce;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Services.Implementations.ECommerce
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;

        public CommentService(ApplicationDbContext context,UserManager<ApplicationUser> user)
        {
            this._context = context;
            this._user = user;
        }

        public async Task<Guid> CreateComment(string userId, Guid productId, string text)
        {
            var product = await this._context.Products
           .FindAsync(productId);

            if (product == null)
            {
                throw new ArgumentException("This product doesn't exist");
            }

            var user = await _user.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("This user doesn't exist");
            }

            Comment comment = new Comment 
            {
                UserId = userId,
                Text = text,
                ProductId = productId,
                Date = DateTime.Now,
            };

            await _context.AddAsync(comment);
            await this._context.SaveChangesAsync();
            return comment.Id;
        }

        public async Task RemoveComment(string userId, Guid commentId)
        {
            var comment = await _context.Comments
                                         .Where(c=>c.Id == commentId)
                                         .FirstOrDefaultAsync();

            if(comment == null)
            {
                throw new ArgumentException("This comment is not yours or doesn't exist");
            }

            if(comment.UserId == userId)
            {
                throw new ArgumentException("This comment is not yours or doesn't exist");
            }

            this._context.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetComments(Guid productId)
        {
            var product = await this._context.Products
            .FindAsync(productId);

            if(product == null)
            {
                throw new ArgumentException("This product doesn't exist");
            }

            var comments = await _context.Comments.Where(c => c.ProductId == productId).ToListAsync();

            if(comments == null)
            {
                throw new ArgumentException("This product doesn't have comments");
            }

            return comments;
        }
    }
}
