using CovidTracing.API.Data;
using CovidTracing.API.Entities;
using CovidTracing.API.Repository.Interface;
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

        public Task Create(PHI phi)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PHI>> GetPHI()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PHI>> GetPHI(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PHI>> GetTravelLogByPHI(double Longtitude, double Latitude)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(PHI phi)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PHI>> UpdateCitizen(int id)
        {
            throw new NotImplementedException();
        }
    }
}
