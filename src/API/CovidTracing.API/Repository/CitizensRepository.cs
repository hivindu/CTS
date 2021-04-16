using CovidTracing.API.Data;
using CovidTracing.API.Entities;
using CovidTracing.API.Repository.Interface;
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

        public Task<IEnumerable<Citizen>> GetCitizen()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Citizen>> GetCitizen(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Citizen citizens)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Citizen>> UpdateTravel(double Latitude, double Longtitude)
        {
            throw new NotImplementedException();
        }

        public Task Create(Citizen citizens)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
