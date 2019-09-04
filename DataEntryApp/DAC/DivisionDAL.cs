using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryApp.DAC.POCOEntities;

namespace DataEntryApp.DAC
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

        public static void AddDivisions(List<Division> divisions)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {               
                divisions.ForEach(d => dbSession.Store(d));
                dbSession.SaveChanges();
            }
        }


        public static void UpdateDivisions(Division divisions)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                var division = dbSession.Load<Division>(divisions.Id);

                division.DivisionName = divisions.DivisionName;
                dbSession.SaveChanges();

            }
        }
        public static void DeleteDivisions(Division divisions)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                var division = dbSession.Load<Division>(divisions.Id);

                dbSession.Delete(division);
                dbSession.SaveChanges();

               
            }
        }
    }
}
