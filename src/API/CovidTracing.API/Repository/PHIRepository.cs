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
    public class PHIRepository : IPHIRepository
    {
        private readonly CovidTracingAPIDBContext _context;

        public PHIRepository(CovidTracingAPIDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PHI>> GetPHI()
        {
            string query = "EXEC SelAllPHI;";
            return await _context.PHI.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<PHI>> GetPHI(int Id)
        {
            string query = "EXEC SelPHIById @id=" + Id + "";
            return _context.PHI.FromSqlRaw(query).AsEnumerable();
        }

        public Task<IEnumerable<PHI>> UpdateCitizen(int id)
        {
            throw new NotImplementedException();
        }
        public Task Create(PHI phi)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(PHI phi)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
