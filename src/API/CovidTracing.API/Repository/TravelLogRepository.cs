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
    public class TravelLogRepository : ITravelLogRepository
    {
        private readonly CovidTracingAPIDBContext _context;

        public TravelLogRepository(CovidTracingAPIDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TravelLog>> GetTravelLog()
        {
            string query = "EXEC SelAllTravelLog;";
            return await _context.TravelLog.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<TravelLog>> GetTravelLogbyId(int id)
        {
            string query = "EXEC SelTravelLogById @id="+id+";";
            return  _context.TravelLog.FromSqlRaw(query).AsEnumerable();
        }

        public async Task<IEnumerable<Citizen>> GetCitizensbyTravelLocations(double Latitude, double longtitude)
        {
            string query = "EXEC SelCitizensByLocation @Lat="+Latitude+ ",@Longtitude="+longtitude+";";
            return await _context.Citizen.FromSqlRaw(query).ToListAsync();
        }

        public async Task<bool> AddTravelLog(TravelLog travelLogS)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC InsTravelLog @CID="+travelLogS.CID+ ",@Lat="+travelLogS.Lat+ ",@Long="+travelLogS.Long+"");

            return Convert.ToBoolean(res);
        }

        public async Task<bool> UpdateTravelLog(TravelLog travelLog)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC UpdTravelLog @Id=" + travelLog.Id + ",@CID="+travelLog.CID+ ",@Lat="+travelLog.Lat+ ",@Long="+travelLog.Lat+"");

            return Convert.ToBoolean(res);
        }

        public async Task<bool> DeleteTravelLog(int id)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC DelTravelLog @id=" + id + "");

            return Convert.ToBoolean(res);
        }
    }
}
