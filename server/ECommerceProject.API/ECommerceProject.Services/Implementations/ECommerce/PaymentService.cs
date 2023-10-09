using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Services.Contracts.ECommerce;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Services.Implementations.ECommerce
{
    public class PaymentService: IPaymentService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;

        public PaymentService(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            this._context = context;
            this._user = user;
        }
    }
}
