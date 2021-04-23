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
    public class PCRRepository : IPCRRepository
    {
        private readonly CovidTracingAPIDBContext _context;

        public PCRRepository(CovidTracingAPIDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PCR>> GetRequests()
        {
            string query = "EXEC SelAllPCR ;";
            return await _context.PCR.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<PCR>> GetRequestById(int id)
        {
            string query = "EXEC SelPCRId @id="+id+";";
            return  _context.PCR.FromSqlRaw(query).AsEnumerable();
        }

        public async Task<IEnumerable<PCR>> GetRequestbyCID(int cid)
        {
            string query = "EXEC SelPCRById @cid=" + cid + ";";
            return await _context.PCR.FromSqlRaw(query).ToListAsync();
        }

        public async Task<bool> Create(PCR pcr)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC InsPCR @CID=" + pcr.CID + ",@dt=" + pcr.dateTime + ";");

            return Convert.ToBoolean(res);
        }

        public async Task<bool> Update(PCR pcr)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC UpdPCR @Id=" + pcr.Id + ",@CID="+pcr.CID+ ",@dateTime="+pcr.dateTime+";");

            return Convert.ToBoolean(res);
        }

        public async Task<bool> Delete(int Id)
        { 
            var res = _context.Database.ExecuteSqlCommand("EXEC DelPCr @id=" + Id + "");

            return Convert.ToBoolean(res);
        }

    }
}
