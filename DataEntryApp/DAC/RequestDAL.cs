using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryApp.DAC.POCOEntities;

namespace DataEntryApp.DAC
{
    public static class RequestDAL
    {
        public static List<Request> GetRequests(string divisionId)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                try
                {
                    return dbSession.Query<Request>()
                                    .Where(r => r.DivisionId == divisionId)
                                    .ToList();

                }
                catch
                {
                    dbSession.Advanced.Clear();
                    throw;
                }

            }
        }
    }
}
