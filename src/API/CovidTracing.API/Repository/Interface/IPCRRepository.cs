using CovidTracing.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracing.API.Repository.Interface
{
    public interface IPCRRepository
    {
        Task<IEnumerable<PCR>> GetRequests();
        Task<IEnumerable<PCR>> GetRequestById(int id);
        Task<IEnumerable<PCR>> GetRequestbyCID(int cid);
        Task<bool> Create(PCR pcr);
        Task<bool> Update(PCR pcr);
        Task<bool> Delete(int Id);
    }
}
