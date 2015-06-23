using CloudWorkSpace.DAL.DTO;
using CloudWorkSpace.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AspNetUserRepository : GenericRepository<AspNetUser> 
    {
        public AspNetUserRepository(DALDbContext context) : base(context) { }
    }
}
