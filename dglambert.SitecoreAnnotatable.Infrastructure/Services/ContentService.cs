using System;
using Sitecore.Data;

namespace dglambert.SitecoreAnnotatable.Infrastructure.Services
{
    public class ContentService : IContentService
    {
        Database _database;
        public ContentService(Database database)
        {
            _database = database ?? throw new ArgumentNullException("database must be a non-null value.");
        }
    }
}
