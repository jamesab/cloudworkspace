
using CloudWorkSpace.DAL.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudWorkSpace.DAL.Repositories
{
    public class ProjectRepository : GenericRepository<Project>
    {
        public ProjectRepository(DALDbContext context)
            : base(context)
        {
        }
    }
}
