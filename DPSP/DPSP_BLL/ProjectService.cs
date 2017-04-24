using DPSP_BLL.Models;
using DPSP_DAL;
using System.Collections.Generic;
using System.Linq;


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

        public IEnumerable<ProjectViewModel> RetypeToProjectViewModel (IEnumerable<Project> userProjects,IEnumerable<Role> role)
        {
            var roleType = role.FirstOrDefault().Enum;
            IEnumerable<ProjectViewModel> projects;
            switch (roleType)
            {
                case RoleType.Employee:
                    projects = userProjects.Select(x => new ProjectViewModel()
                    {
                        ProjectId = x.Id,
                        Name = x.Name,
                        Department = x.Department,
                        Client = x.Client,
                        Manager = x.Manager,
                        Employees = x.Employees,
                        Introduction = x.Introduction,
                        Content = x.Content,
                        Conclusion = x.Conclusion,
                        Budget = x.Budget,
                        OpenDate = x.OpenDate,
                        CloseDate = x.CloseDate
                    });
                    break;
                default:
                    projects = userProjects.Select(x => new ProjectViewModel()
                    {
                        ProjectId = x.Id,
                        Name = x.Name,
                        Department = x.Department,
                        Client = x.Client,
                        Manager = x.Manager,
                        Employees = x.Employees,
                        Introduction = x.Introduction,
                        Content = x.Content,
                        Conclusion = x.Conclusion,
                        OpenDate = x.OpenDate,
                        CloseDate = x.CloseDate
                    });
                    break;
            }
            //var listOfProjects =  new ListProjectViewModel()
            //{
            //    ProjectViewModels = projects
            //};
            return projects;
        }
    }
}
