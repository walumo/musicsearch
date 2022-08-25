using musicsearch.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace musicsearch.DBinterface
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<DBmodel>> GetMultipleAsync(string query);

        Task AddAsync(DBmodel item);

    }

}
