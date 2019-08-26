using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryApp.Common.DAC;
using DataEntryApp.Common.Models;
using static AutoMapper.Mapper;

namespace DataEntryApp.Common.BL
{
    public class DivisionBLL
    {
        public List<DivisionDTO> GetDivisions()
        {
            var divisions = DivisionDAL.GetDivisions();

            if (divisions == null) return null;

            return Map<List<DivisionDTO>>(divisions);
        }
    }
}
