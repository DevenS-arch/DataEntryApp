using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTicket.DataEntry.DAC;
using TechTicket.DataEntry.DAC.POCOEntities;
using TechTicket.DataEntry.Entities;
using static AutoMapper.Mapper;

namespace TechTicket.DataEntry.BL
{
    public class DivisionBLL
    {
        public List<DivisionDTO> GetDivisions()
        {
            var divisions = DivisionDAL.GetDivisions();

            if (divisions == null) return null;

            return Map<List<DivisionDTO>>(divisions);
        }

        public void AddDivisions(List<DivisionDTO> divisions)
        {
            DivisionDAL.AddDivisions( Map<List<Division>>(divisions) );

        }

        public void  UpdateDivisions(DivisionDTO divisions)
        {
            DivisionDAL.UpdateDivisions(Map<Division>(divisions));
        }

            public void DeleteDivisions(DivisionDTO divisions)
        {
            DivisionDAL.DeleteDivisions(Map<Division>(divisions));
        }

        }
    }
 