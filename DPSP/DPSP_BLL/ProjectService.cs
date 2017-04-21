using DPSP_DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DPSP_BLL
{
    public class ProjectService : IProjectService
    {
        public IEnumerable<Project> GetUserProjects(string aspUserId)
        {
            using (var db = new DboContext())
            {
                var dbUser = db.Users.FirstOrDefault(x => x.AspNetUsersId == aspUserId);
                var projects = db.Projects.Where(x => x.Users.Any(y => y.Id == dbUser.Id)).ToList();
                return projects;
            }
        }
    }
}
