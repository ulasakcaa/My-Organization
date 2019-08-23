using DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository:RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MyOrganizationEntities ctx):base(ctx)
        {     
        }


    }
}
