using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatAEntryApp.AppCode
{
    public static class Bootstrap
    {
        public static void ConfigureAutomapper()
        {
            Mapper.Initialize((config) => config.AddProfiles("DataEntryApp", "DataEntryApp"));
        }
    }
}