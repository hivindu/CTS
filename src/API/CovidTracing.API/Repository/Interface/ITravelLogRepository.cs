using CovidTracing.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracing.API.Repository.Interface
{
    public interface ITravelLogRepository
    {
        Task<List<TravelLog>> GetTravelLog();

        Task<TravelLog> GetTravelLogbyId(int id);

        Task<List<Citizen>> GetCitizensbyTravelLocations(double Latitude, double longtitude);

        Task<bool> AddTravelLog();

        Task<bool> UpdateTravelLog(TravelLog travelLog);

        Task<bool> DeleteTravelLog(int id);
    }
}
