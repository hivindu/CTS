using CovidTracing.API.Entities;
using CovidTracing.API.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracing.API.Repository
{
    public class TravelLogRepository : ITravelLogRepository
    {
        public Task<bool> AddTravelLog()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTravelLog(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Citizen>> GetCitizensbyTravelLocations(double Latitude, double longtitude)
        {
            throw new NotImplementedException();
        }

        public Task<List<TravelLog>> GetTravelLog()
        {
            throw new NotImplementedException();
        }

        public Task<TravelLog> GetTravelLogbyId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTravelLog(TravelLog travelLog)
        {
            throw new NotImplementedException();
        }
    }
}
