using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Serilog;
using Sprague.Andy.WeddingAzure.Models.Rsvp;

namespace Sprague.Andy.WeddingAzure.DataAccess.Rsvp
{
    public class RsvpRepository : IRsvpRepository
    {
        private readonly ServiceConfiguration _config;
        private readonly CloudTable _rvspTable;
        private readonly ILogger _log = Log.ForContext<RsvpRepository>();
        public RsvpRepository(ServiceConfiguration config)
        {
            _config = config;
            var storageAccount = CloudStorageAccount.Parse(_config.StorageConnectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            _rvspTable = tableClient.GetTableReference("WeddingRsvp");
        }

        public async Task AddRsvpAsync(RsvpEntity rsvp)
        {
            _rvspTable.CreateIfNotExistsAsync();

            var insertOperation = TableOperation.Insert(rsvp);
            await _rvspTable.ExecuteAsync(insertOperation);
            _log.Information($"Added rsvp for {rsvp.Name}");
        }

        public async Task AddOrReplaceRsvpAsync(RsvpEntity rsvp)
        {
            _rvspTable.CreateIfNotExistsAsync();

            var insertOperation = TableOperation.InsertOrReplace(rsvp);
            await _rvspTable.ExecuteAsync(insertOperation);
            _log.Information($"Added or replaced rsvp for {rsvp.Name}");
        }

        public async Task DeleteRsvpAsync(RsvpEntity rsvp)
        {
            var retrieveOperation = TableOperation.Retrieve<RsvpEntity>(rsvp.PartitionKey, rsvp.RowKey);
            var retrievedResult = await _rvspTable.ExecuteAsync(retrieveOperation);
            var deleteEntity = (RsvpEntity)retrievedResult.Result;

            if (deleteEntity == null)
            {
                throw new ArgumentException($"Could not delete '{rsvp.Name}' as no record exists");
            }

            var deleteOperation = TableOperation.Delete(deleteEntity);
            await _rvspTable.ExecuteAsync(deleteOperation);

            _log.Information($"Deleted rsvp for {rsvp.Name}");
        }

        public async Task<RsvpEntity> GetRsvpAsync(string name)
        {
            var rsvpToRetrieve = new RsvpEntity(name);
            var retrieveOperation = TableOperation.Retrieve<RsvpEntity>(rsvpToRetrieve.PartitionKey, rsvpToRetrieve.RowKey);
            var retrievedResult = await _rvspTable.ExecuteAsync(retrieveOperation);
            var retrievedEntity = (RsvpEntity)retrievedResult.Result;

            if (retrievedEntity == null)
            {
                throw new ArgumentException($"No record found for {name}");
            }
            return retrievedEntity;
        }
    }
}
