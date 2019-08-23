using DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrgUserRepository : RepositoryBase<OrgUser>, IOrgUserRepository
    {
        public OrgUserRepository(MyOrganizationEntities ctx):base(ctx)
        {

        }
    }
}
