using System.Threading.Tasks;

namespace JeweleryApp.Services
{
    public interface IJeweleryService
    {
        string GenerateToken(string userId);
        Task<decimal> DiscountCalculator(decimal price, int weight, decimal? discount);
    }
}
