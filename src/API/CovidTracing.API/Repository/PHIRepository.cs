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


        public async Task<bool> AcvtivatePHI(int ID)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC ActivatePHI @id=" + ID + "");


            return Convert.ToBoolean(res);
        }

        public async Task<bool> DeactivatePHI(int id)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC DeactivatePHI @id=" + id + "");


            return Convert.ToBoolean(res);
        }

        public async  Task<bool> Create(PHI phi)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC UpdPHI InsPHI @Name ="+phi.Name+ ",@age="+phi.Age+ ",@NIC="+phi.NIC+ ",@Address="+phi.Address+ ",@Email="+phi.Email+ ",@Affiliation="+phi.Affiliation+ ",@Password="+phi.Password+"");

            return Convert.ToBoolean(res);
        }

        public async Task<bool> Update(PHI phi)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC UpdPHI @id="+phi.Id+ ",@age="+phi.Age+ ",@NIC="+phi.NIC+ ",@Address="+phi.Address+ ",@Email="+phi.Email+ ",@Affiliation="+phi.Affiliation+ ",@Password="+phi.Password+"");

            return Convert.ToBoolean(res);
        }

        public async Task<bool> Delete(int Id)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC DelPHI @id=" + Id+ "");

            return Convert.ToBoolean(res);
        }

    }
}
