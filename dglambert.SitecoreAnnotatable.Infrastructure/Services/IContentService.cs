using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dglambert.SitecoreAnnotatable.Infrastructure.Services
{
    public interface IContentService
    {
        string GetDataSourceItemPath(Guid id);
    }
}
