using DPSP_DAL;
using System.Collections.Generic;
using System.Linq;


namespace DPSP_BLL
{
    public class RoleService : IRoleService
    {
        public IEnumerable<Role> GetRole(string aspUserId)
        {
            using (var db = new DboContext())
            {
                var user = db.Users.FirstOrDefault(x => x.AspNetUsersId == aspUserId);
                var usersRoles = user.Roles;
                return usersRoles;
            }
        }
    }
}
