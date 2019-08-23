using DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrgImageRepository : RepositoryBase<OrgImage>, IImageOrgRepository
    {
        public OrgImageRepository(MyOrganizationEntities ctx):base(ctx)
        {

        }
    }
}
