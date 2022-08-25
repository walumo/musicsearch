using Microsoft.Azure.Cosmos;
using musicsearch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace musicsearch.DBinterface
{
    public class CosmosDbService : ICosmosDbService
    {
        private Microsoft.Azure.Cosmos.Container _container;

        public CosmosDbService(
        CosmosClient cosmosDbClient,
        string databaseName,
        string containerName)
        {
            _container = cosmosDbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddAsync(DBmodel item)
        {
            await _container.CreateItemAsync(item, new PartitionKey(item.Id));
        }

        public async Task<IEnumerable<DBmodel>> GetMultipleAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<DBmodel>(new QueryDefinition(queryString));
            var results = new List<DBmodel>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }
    }
}
