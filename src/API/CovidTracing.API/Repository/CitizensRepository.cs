using CovidTracing.API.Data;
using CovidTracing.API.Entities;
using CovidTracing.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Citizen>> GetCitizen()
        {
            string query = "EXEC SelAllCitizen;";
            return await _context.Citizen.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<Citizen>> GetCitizen(int Id)
        {
            string query = "EXEC SelCitizenById @id=" + Id + ";";
            return  _context.Citizen.FromSqlRaw(query).AsEnumerable();
        }

        public async Task<bool> ActiveCitizen(int id)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC ActivateCitizen @id="+id+"");


            return Convert.ToBoolean(res);
        }

        public async Task<bool> DeactivateCitizen(int id)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC DeactivateCitizen @id=" + id + "");


            return Convert.ToBoolean(res);
        }

        public async Task<bool> Create(Citizen citizens)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC InsCitizen @Name="+citizens.Name+ ",@Age="+citizens.Age+ ",@NIC="+citizens.NIC+ ",@Address="+citizens.Address+ ",@Proffession="+citizens.Proffession+ ",@Email="+citizens.Email+ ",@Affiliation="+citizens.Affiliation+ ",@Password="+citizens.Password+ ",@HealthStatus="+citizens.HealthStatus+ ",@Latitude="+citizens.Latitude+ ",@Longtitude="+citizens.Longtitude+"");


            return Convert.ToBoolean(res);
        }

        public async Task<bool> Update(Citizen citizens)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC UpdCitizen @Id=" + citizens.Id + ",@Name=" + citizens.Name + ",@Age=" + citizens.Age + ",@NIC=" + citizens.NIC + ",@Address=" + citizens.Address + ",@Proffession=" + citizens.Proffession + ",@Email=" + citizens.Email + ",@Affiliation=" + citizens.Affiliation + ",@Password=" + citizens.Password + ",@HealthStatus=" + citizens.HealthStatus + ",@Latitude=" + citizens.Latitude + ",@Longtitude="+citizens.Longtitude+"");

            return Convert.ToBoolean(res);
        }

        public async Task<bool> Delete(int Id)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC DelCitizen @id=" + Id + "");


            return Convert.ToBoolean(res);
        }

        
    }
}
