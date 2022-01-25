using JeweleryApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JeweleryApp.Repositories
{
    public class JeweleryRepository : IJeweleryRepository
    {
        readonly JeweleryDbContext context;

        public JeweleryRepository(JeweleryDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> IsUserValid(string userId, string password)
        {
            return await context.Users.Where(u => u.UserId == userId && u.Password == password).FirstOrDefaultAsync() != null;
        }     

        public async Task<decimal> DiscountCalculator(decimal price, int weight, decimal discount)
        {
            decimal totalPrice = (price * weight) - (discount / 100) * (price * weight);
            return totalPrice;
        }

    }

}
