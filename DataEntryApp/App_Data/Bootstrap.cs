using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechTicket.DataEntry.AppCode
{
    public static class Bootstrap
    {
        public static void ConfigureAutomapper()
        {
            Mapper.Initialize((config) => config.AddProfiles("TechTicket.DataEntry", "TechTicket.DataEntry"));
        }
    }
}