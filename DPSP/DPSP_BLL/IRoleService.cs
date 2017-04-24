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
        IEnumerable<Role> GetRole(string aspUserId);
    }
}
