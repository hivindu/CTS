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

        Task<bool> ActiveCitizen(int id);

        Task<bool> DeactivateCitizen(int id);

        Task<bool> Create(Citizen citizens);

        Task<bool> Update(Citizen citizens);

        Task<bool> Delete(int Id);
    }
}
