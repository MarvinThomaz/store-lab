using Store.Product.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Product.Domain.Repositories
{
    public interface ICoinRepository
    {
        Task CreateCoinAsync(Coin coin);
        Task UpdateCoinAsync(Coin coin, string coinKey);
        Task<IEnumerable<Coin>> GetAllCoinsAsync();
    }
}