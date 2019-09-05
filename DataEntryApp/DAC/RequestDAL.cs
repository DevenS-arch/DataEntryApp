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
        public static List<Request> GetRequests()
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                try
                {
                    var requests = dbSession.Query<Request>().ToList();


                    foreach (var r in requests)
                    {
                        var division = dbSession.Query<Division>().Where(d => d.Id == r.DivisionId).Single();
                        r.Division = division;
                    }
                    return requests;

                }
                catch
                {
                    dbSession.Advanced.Clear();
                    throw;
                }

            }
        }


        public static void AddRequests(List<Request> requests)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {
                requests.ForEach(d => dbSession.Store(d));
                dbSession.SaveChanges();
            }
        }


        public static void UpdateRequests(Request requests)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                var request = dbSession.Load<Request>(requests.Id);
                if (request == null)
                {
                    requests.Id = null;
                    dbSession.Store(requests);
                }
                else
                {
                    request.RequestName = requests.RequestName;
                    request.DivisionId = requests.DivisionId;
                }
                dbSession.SaveChanges();

            }
        }

        public static void DeleteRequests(List<Request> requests)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                requests.ForEach(r => dbSession.Delete(r));
                dbSession.SaveChanges();
            }
        }
    }
}
