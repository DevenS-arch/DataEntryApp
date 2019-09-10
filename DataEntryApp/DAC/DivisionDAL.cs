using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTicket.DataEntry.DAC.POCOEntities;

namespace TechTicket.DataEntry.DAC
{
    public static class DivisionDAL
    {
        /// <summary>
        /// Get Division
        /// </summary>
        /// <returns></returns>
        public static List<Division> GetDivisions()
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                try
                {
                    return dbSession.Query<Division>()
                                    .OrderBy(d => d.DivisionName)
                                    .ToList();

                }
                catch (Exception ex)
                {
                    dbSession.Advanced.Clear();
                    throw;
                }

            }
        }

        /// <summary>
        /// Get Division - By Name
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public static Division GetDivision(Division division)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                try
                {
                    return dbSession.Query<Division>().Where(d => d.DivisionName == division.DivisionName).FirstOrDefault();
                                    

                }
                catch (Exception ex)
                {
                    dbSession.Advanced.Clear();
                    throw;
                }

            }
        }

        /// <summary>
        /// Add Division
        /// </summary>
        /// <param name="divisions"></param>
        public static void AddDivisions(List<Division> divisions)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {
                divisions.ForEach(d => dbSession.Store(d));
                dbSession.SaveChanges();
            }
        }

        /// <summary>
        /// Update Division
        /// </summary>
        /// <param name="divisions"></param>
        public static void UpdateDivisions(Division divisions)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                var division = dbSession.Load<Division>(divisions.Id);
                if (division == null)
                {
                   var time = DateTime.Now;
                    divisions.Id = null;
                    divisions.CreatedDate = time;
                    divisions.ModifiedDate = time;
                    dbSession.Store(divisions);

                }
                else
                {
                    division.DivisionName = divisions.DivisionName;
                    division.ModifiedDate = DateTime.Now;
                }
                dbSession.SaveChanges();

            }
        }

        /// <summary>
        /// Delete Division
        /// </summary>
        /// <param name="divisions"></param>
        public static void DeleteDivisions(Division divisions)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                var division = dbSession.Load<Division>(divisions.Id);
                if (division != null)
                {
                    var requests = dbSession.Query<Request>().Where(r => r.DivisionId == divisions.Id).ToList();

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

                    dbSession.Delete(division);


                    dbSession.SaveChanges();
                }
            }
        }
    }
}
