using JeweleryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeweleryApp.Repositories
{
    public interface IJeweleryRepository
    {
        Task<bool> IsUserValid(string UserId, string Password);
        Task<decimal> DiscountCalculator(decimal price, int weight, decimal discount);
    }
}
