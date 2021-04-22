using CovidTracing.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracing.API.Repository.Interface
{
    public interface IPHIRepository
    {
        Task<IEnumerable<PHI>> GetPHI();

        Task<IEnumerable<PHI>> GetPHI(int Id);

        Task<bool> AcvtivatePHI(int ID);

        Task<bool> DeactivatePHI(int id);

        Task<bool> Create(PHI phi);

        Task<bool> Update(PHI phi);

        Task<bool> Delete(int Id);
    }
}
