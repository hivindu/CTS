﻿using CovidTracing.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracing.API.Repository.Interface
{
    public interface ICDCRepository
    {
        Task<IEnumerable<CDC>> GetCDC();

        Task<IEnumerable<CDC>> GetCDC(int Id);

        Task<IEnumerable<CDC>> GetTravelLogByCDC(double Longtitude, double Latitude);

        Task<IEnumerable<CDC>> DeactivateUser(int Id);

        Task<IEnumerable<CDC>> DeactivatePHI(int Id);

        Task Create(CDC cdc);

        Task<bool> Update(CDC cdc);

        Task<bool> Delete(int Id);
    }
}