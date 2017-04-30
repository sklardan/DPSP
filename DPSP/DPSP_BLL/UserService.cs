using DPSP_DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DPSP_BLL
{
    public class UserService : IUserService
    {
        public User CreateUser(string aspUserId, string role)
        {
            using (var db = new DboContext())
            {   
                var dbUser = db.Users.Add(new User
                {
                    AspNetUsersId = aspUserId,
                    Status = UserStatus.Active,
                    Roles = db.Roles.Where(x => x.Name == role).ToList(),
                    Projects = db.Projects.Where(x => x.IsActive && role == nameof(RoleType.Employee)).ToList()
                });
                db.SaveChanges();
                return dbUser;
            }
        }

        public User AddNames(User dbUser, string FirstName, string LastName)
        {
            using (var db = new DboContext())
            {
                dbUser.FirstName = FirstName;
                dbUser.LastName = LastName;
                db.SaveChanges();
                return dbUser;
            }
            
        }

        public User AddProject(User dbUser, IList<Guid> projectIds)
        {
            using (var db = new DboContext())
            {
                foreach (var item in projectIds)
                {
                    db.Users.FirstOrDefault(x => x.Id == dbUser.Id).Projects.Add(db.Projects.FirstOrDefault(x => x.Id == item));
                }
                db.SaveChanges();
                return dbUser;
            }
        }

        public User GetUser(string aspUserId)
        {
            using(var db = new DboContext())
            {
                return(db.Users.FirstOrDefault(x => x.AspNetUsersId == aspUserId));
            }
        }
    }
}
