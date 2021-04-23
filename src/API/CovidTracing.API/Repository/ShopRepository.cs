using CovidTracing.API.Data;
using CovidTracing.API.Entities;
using CovidTracing.API.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracing.API.Repository
{
    public class ShopRepository : IShopRepository
    {
        private readonly CovidTracingAPIDBContext _context;

        public ShopRepository(CovidTracingAPIDBContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Shop>> GetShops()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shop>> GetShop(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shop>> GetShopByBR(string br)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ApproveShop(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RejectShop(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(Shop shop)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Shop shop)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
