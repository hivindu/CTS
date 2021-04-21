using CovidTracing.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracing.API.Repository.Interface
{
    public interface ICitizensRepository
    {
        Task<IEnumerable<Citizen>> GetCitizen();

        Task<IEnumerable<Citizen>> GetCitizen(int Id);

        Task<IEnumerable<PHI>> GetTravelLog(double Longtitude, double Latitude);

        Task<IEnumerable<Citizen>> UpdateTravel(double Latitude, double Longtitude);

        Task<bool> ActiveCitizen(int id);

        Task<bool> DeactivateCitizen(int id);

        Task Create(Citizen citizens);

        Task<bool> Update(Citizen citizens);

        Task<bool> Delete(int Id);
    }
}
