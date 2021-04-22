using CovidTracing.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracing.API.Repository.Interface
{
    public interface ITravelLogRepository
    {
        Task<IEnumerable<TravelLog>> GetTravelLog();

        Task<IEnumerable<TravelLog>> GetTravelLogbyId(int id);

        Task<IEnumerable<Citizen>> GetCitizensbyTravelLocations(double Latitude, double longtitude);

        Task<bool> AddTravelLog(TravelLog travelLog);

        Task<bool> UpdateTravelLog(TravelLog travelLog);

        Task<bool> DeleteTravelLog(int id);
    }
}
