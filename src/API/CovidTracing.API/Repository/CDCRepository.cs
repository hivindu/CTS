using CovidTracing.API.Data;
using CovidTracing.API.Entities;
using CovidTracing.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracing.API.Repository
{
    public class CDCRepository : ICDCRepository
    {
        // Error correction POINT - 1
        private readonly CovidTracingAPIDBContext _context;

        //Error correction - POINT 2
        public CDCRepository(CovidTracingAPIDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CDC>> GetCDC()
        {
            string query = "EXEC SelAllCDC;";
            return await _context.CDC.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<CDC>> GetCDC(int Id)
        {
            string query = "EXEC SelCDCById @id=" + Id + ";";
            return _context.CDC.FromSqlRaw(query).AsEnumerable();
        }


        public async Task Create(CDC cdc)
        {
            int id = cdc.Id;
            string name = cdc.Name;
            string nic = cdc.NIC;
            string password = cdc.Password;

            //var rest = _context.Database
        }

        public async Task<bool> Update(CDC cdc)
        {
            var res = _context.Database.ExecuteSqlCommand("");

            return Convert.ToBoolean(res);
        }

        public async Task<bool> Delete(int Id)
        {
            string query = "";

            var res = _context.Database.ExecuteSqlCommand("");

            return Convert.ToBoolean(res);
        }

    }
}
