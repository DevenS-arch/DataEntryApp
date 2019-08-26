using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryApp.Common.DAC.POCOEntities;

namespace DataEntryApp.Common.DAC
{
    public static class DivisionDAL
    {
        public static List<Division> GetDivisions()
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                try
                {
                    return dbSession.Query<Division>()
                                    .ToList();

                }
                catch (Exception ex)
                {
                    dbSession.Advanced.Clear();
                    throw;
                }

            }
        }
    }
}
