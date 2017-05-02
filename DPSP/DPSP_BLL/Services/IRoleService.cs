using DPSP_DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSP_BLL
{
    public interface IRoleService
    {
        /// <summary>
        /// GetRole returns user's role.
        /// </summary>
        /// <param name="aspUserId">String aspUserId</param>
        /// <returns>Returns roles from user.</returns>
        IEnumerable<Role> GetRole(string aspUserId);
    }
}
