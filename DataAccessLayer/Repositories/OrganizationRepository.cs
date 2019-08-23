using DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrganizationRepository : RepositoryBase<Organization>,IOrganizationRepository
    {
        public OrganizationRepository(MyOrganizationEntities ctx):base(ctx)
        {

        }
    }
}
