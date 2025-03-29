﻿using SMS.Application.DTOs;
using SMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Persistance.Contracts
{
    public interface IStylistRepo:IGenricRepo<Stylist>
    {
        Task<IEnumerable<Stylist>> GetStylistBySalon(string salonId);
        Task<IEnumerable<StyistServiceLink>> GetStylistByService(string styleServiceLinkId);
        Task<Stylist> GetStylistByName(string name);
    }
}
