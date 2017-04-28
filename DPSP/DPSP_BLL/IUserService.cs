using DPSP_DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSP_BLL
{
    public interface IUserService
    {
        User CreateUser(string aspUserId, string role);
        User AddNames(User dbUser, string FirstName, string LastName);
        User AddProject(User dbUser, IList<Guid> projectIds);
    }
}
