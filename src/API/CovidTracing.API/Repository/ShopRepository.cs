using CovidTracing.API.Data;
using CovidTracing.API.Entities;
using CovidTracing.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public async Task<IEnumerable<Shop>> GetShops()
        {
            string query = "EXEC SelAllShops;";
            return await _context.Shop.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<Shop>> GetShop(int id)
        {
            string query = "EXEC SelShopsById @id="+id+";";
            return await _context.Shop.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<Shop>> GetShopByBR(string br)
        {
            string query = "EXEC SelShopsByBr @BR=" + br + ";";
            return await _context.Shop.FromSqlRaw(query).ToListAsync();
        }

        public async Task<bool> ApproveShop(int id)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC ActivateShop @id="+id+"");

            return Convert.ToBoolean(res);
        }

        public async Task<bool> RejectShop(int id)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC DeactivateShop @id=" + id + "");

            return Convert.ToBoolean(res);
        }

        public async Task<bool> Create(Shop shop)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC InsShop @ShopName="+shop.ShopName+ ",@Contact="+shop.Contact+ ",@Latitude="+shop.Latitude+ ",@Longtitude="+shop.Longtitude+ ",@BrNumber="+shop.BrNumber+";");

            return Convert.ToBoolean(res);
        }

        public async Task<bool> Update(Shop shop)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC UpdShop @Id="+shop.Id+ ",@ShopName="+shop.ShopName+ ",@Contact="+shop.Contact+ ",@Latitude="+shop.Latitude+ ",@Longtitude="+shop.Longtitude+ ",@Status="+shop.Status+ ",@BrNumber="+shop.BrNumber+"");

            return Convert.ToBoolean(res);
        }
        public async Task<bool> Delete(int Id)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC DelShop @id="+Id+"");

            return Convert.ToBoolean(res);
        }

    }
}
