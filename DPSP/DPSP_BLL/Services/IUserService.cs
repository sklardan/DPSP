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
        /// <summary>
        /// CreateUser will create user in database and connect him with AspNetUser. Give him role and projects if employee.
        /// </summary>
        /// <param name="aspUserId">String aspUserId.</param>
        /// <param name="role">String prefered role of user.</param>
        /// <returns>Returns created user.</returns>
        User CreateUser(string aspUserId, string role);

        /// <summary>
        /// AddNames will add first and last name to user.
        /// </summary>
        /// <param name="dbUser">User from database.</param>
        /// <param name="FirstName">String user's first name.</param>
        /// <param name="LastName">String user's last name.</param>
        /// <returns>Returns user with added names.</returns>
        User AddNames(User dbUser, string FirstName, string LastName);

        /// <summary>
        /// AddProject will add projects to user. 
        /// </summary>
        /// <param name="dbUser">User from database.</param>
        /// <param name="projetIds">IList of Guid project ids, which should be added.</param>
        /// <returns>Returns user with added projects.</returns>
        User AddProject(User dbUser, IList<Guid> projectIds);

        /// <summary>
        /// GetUser will return user with aspUserId.
        /// </summary>
        /// <param name="aspUserId">String aspUserId</param>
        /// <returns>Return user with aspUserId.</returns>
        User GetUser(string aspUserId);
    }
}
