using Raven.Client;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTicket.DataEntry.DAC
{

    public static class DocumentStoreHolder
    {
        // Use Lazy<IDocumentStore> to initialize the document store lazily. 
        // This ensures that it is created only once - when first accessing the public `Store` property.
        private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

        public static IDocumentStore Store => store.Value;

        private static IDocumentStore CreateStore()
        {
            IDocumentStore store = new DocumentStore()
            {

                // Define the cluster node URLs (required)
                Urls = new[] { "http://jrricsrvas600:8080", 
                           /*some additional nodes of this cluster*/ },




                // Set conventions as necessary (optional)
                Conventions =
            {
                MaxNumberOfRequestsPerSession = 50,
                UseOptimisticConcurrency = true
            },



                // Define a default database (optional)
                Database = "TechTicketDB",



                // Define a client certificate (optional)
                //Certificate = new X509Certificate2("C:\\path_to_your_pfx_file\\cert.pfx"),



                // Initialize the Document Store
            }.Initialize();



            return store;
        }
    }

    //public static class DocumentStoreHolder
    //{
    //    private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

    //    public static IDocumentStore Store
    //    {
    //        get { return store.Value; }
    //    }

    //    private static IDocumentStore CreateStore()
    //    {
    //        IDocumentStore store = new DocumentStore()
    //        {
    //            Urls = "http://jrricsrvas600:8080",
    //            ConnectionStringName = "TechTicketServer",
    //            DefaultDatabase = "UATClaims"
    //        }.Initialize();

    //        return store;
    //    }
    //}

}
