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
        private readonly CovidTracingAPIDBContext _context;

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

        public Task<IEnumerable<CDC>> DeactivatePHI(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CDC>> DeactivateUser(int Id)
        {
            throw new NotImplementedException();
        }

        public Task Create(CDC cdc)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(CDC cdc)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
