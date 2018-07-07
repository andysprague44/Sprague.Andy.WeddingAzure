using System.Configuration;

namespace Sprague.Andy.WeddingAzure.DataAccess
{
    public class ServiceConfiguration
    {
        public string StorageConnectionString => ConfigurationManager.AppSettings["StorageConnectionString"];
    }
}
