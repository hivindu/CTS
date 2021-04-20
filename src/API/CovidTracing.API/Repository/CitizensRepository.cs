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
    public class CitizensRepository : ICitizensRepository
    {
        private readonly CovidTracingAPIDBContext _context;

        public CitizensRepository(CovidTracingAPIDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Citizen>> GetCitizen()
        {
            string query = "EXEC SelAllCitizen;";
            return await _context.Citizen.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<Citizen>> GetCitizen(int Id)
        {
            string query = "EXEC SelCitizenById @id=" + Id + ";";
            return  _context.Citizen.FromSqlRaw(query).AsEnumerable();
        }

        public async Task<IEnumerable<PHI>> GetTravelLogByPHI(double Longtitude, double Latitude)
        {
            string query = "";
            return _context.PHI.FromSqlRaw(query).AsEnumerable();
        }

        public Task<IEnumerable<Citizen>> UpdateTravel(double Latitude, double Longtitude)
        {
            throw new NotImplementedException();
        }

        public Task Create(Citizen citizens)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Citizen citizens)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
