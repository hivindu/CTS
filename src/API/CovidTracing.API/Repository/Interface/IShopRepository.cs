using CovidTracing.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracing.API.Repository.Interface
{
    public interface IShopRepository
    {
        Task<IEnumerable<Shop>> GetShops();

        Task<IEnumerable<Shop>> GetShop(int id);

        Task<IEnumerable<Shop>> GetShopByBR(string br);

        Task<bool> ApproveShop(int id);

        Task<bool> RejectShop(int id);

        Task<bool> Create(Shop shop);
        Task<bool> Update(Shop shop);
        Task<bool> Delete(int Id);
    }
}
