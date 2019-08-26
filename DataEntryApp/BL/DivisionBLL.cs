using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryApp.DAC;
using DataEntryApp.Entities;
using static AutoMapper.Mapper;

namespace DataEntryApp.BL
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
