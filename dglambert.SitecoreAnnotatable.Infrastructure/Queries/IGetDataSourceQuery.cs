using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dglambert.SitecoreAnnotatable.Infrastructure.Queries
{
    public interface IGetDataSourceQuery
    {
        string GetDataSourceItemPath(Guid id);
    }
}
