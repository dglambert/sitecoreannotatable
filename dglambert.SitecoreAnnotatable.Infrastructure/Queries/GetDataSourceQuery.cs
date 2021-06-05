using System;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace dglambert.SitecoreAnnotatable.Infrastructure.Queries
{
    public class GetDataSourceQuery : IGetDataSourceQuery
    {
        readonly Database _database;
        public GetDataSourceQuery(Database database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public string GetDataSourceItemPath(Guid id)
        {
            Item dataSourceItem = _database.GetItem(new ID(id));
            if(dataSourceItem == null)
            {
                return null;
            }
            return dataSourceItem.Paths.FullPath;
        }
    }
}
