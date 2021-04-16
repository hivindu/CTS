using CovidTracing.API.Data;
using CovidTracing.API.Entities;
using CovidTracing.API.Repository.Interface;
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
        public Task Create(CDC cdc)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CDC>> DeactivatePHI(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CDC>> DeactivateUser(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CDC>> GetCDC()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CDC>> GetCDC(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CDC>> GetTravelLogByCDC(double Longtitude, double Latitude)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(CDC cdc)
        {
            throw new NotImplementedException();
        }
    }
}
