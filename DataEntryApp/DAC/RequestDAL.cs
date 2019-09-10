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
        /// <summary>
        ///  Get Requests
        /// </summary>
        /// <returns></returns>
        public static List<Request> GetRequests()
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                try
                {
                    var requests = dbSession.Query<Request>().ToList();


                    foreach (var r in requests)
                    {
                        var division = dbSession.Query<Division>().Where(d => d.Id == r.DivisionId).FirstOrDefault();
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


        /// <summary>
        /// Get request - By Name
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public static Request GetRequest(Request request)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                try
                {
                    var requests = dbSession.Query<Request>().Where(d => d.RequestName == request.RequestName && d.DivisionId == request.DivisionId).FirstOrDefault();
                    return requests;


                }
                catch (Exception ex)
                {
                    dbSession.Advanced.Clear();
                    throw;
                }

            }
        }

        /// <summary>
        ///  Get Requests
        /// </summary>
        /// <returns></returns>
        public static List<Request> GetRequestsForDivision(string divisionId)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                try
                {
                    var requests = dbSession.Query<Request>().Where(r => r.DivisionId == divisionId).ToList();

                    return requests;

                }
                catch
                {
                    dbSession.Advanced.Clear();
                    throw;
                }

            }
        }


        /// <summary>
        /// Add Requests
        /// </summary>
        /// <param name="requests"></param>
        public static void AddRequests(List<Request> requests)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {
                requests.ForEach(d => dbSession.Store(d));
                dbSession.SaveChanges();
            }
        }

        /// <summary>
        /// Update Requests
        /// </summary>
        /// <param name="requests"></param>
        public static void UpdateRequests(Request requests)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                var request = dbSession.Load<Request>(requests.Id);
                if (request == null)
                {
                    requests.Id = null;
                    requests.CreatedDate = DateTime.Now;
                    requests.ModifiedDate = DateTime.Now;
                    dbSession.Store(requests);
                }
                else
                {
                    request.RequestName = requests.RequestName;
                    request.DivisionId = requests.DivisionId;
                    request.ModifiedDate = DateTime.Now;
                }
                dbSession.SaveChanges();

            }
        }

        /// <summary>
        /// Delete Requests 
        /// </summary>
        /// <param name="request"></param>
        public static void DeleteRequests(Request request)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {
                var requests = dbSession.Query<Request>().Where(r => r.Id == request.Id).ToList();

                if (requests.Count != 0)
                {
                    foreach (var r in requests)
                    {
                        var emailTemplates = dbSession.Query<EmailTemplate>().Where(et => et.RequestId == r.Id).ToList();
                        if (emailTemplates.Count != 0)
                        {
                            foreach (var e in emailTemplates)
                            {
                                var emailTemplateFields = dbSession.Query<EmailTemplateField>().Where(etf => etf.EmailTemplateId == e.Id).ToList();

                                if (emailTemplateFields.Count != 0)
                                {
                                    emailTemplateFields.ForEach(etf => dbSession.Delete(etf));
                                }
                            }

                            emailTemplates.ForEach(et => dbSession.Delete(et));
                        }
                    }
                    requests.ForEach(r => dbSession.Delete(r));
                }

                dbSession.SaveChanges();
            }
        }
    }
}
