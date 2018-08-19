using Store.Product.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Product.Domain.Services
{
    public interface ICoinApplicationService
    {
        Task RegisterNewCoinAsync(Coin coin);
        Task UpdateCoinAsync(Coin coin, string coinKey);
        Task<IEnumerable<Coin>> GetAllCoinsAsync();
    }
}