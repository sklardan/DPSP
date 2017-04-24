using DPSP_DAL;
using System;
using System.Collections.Generic;

namespace DPSP_BLL.Models
{
    public class ProjectViewModel
    {
        public Guid ProjectId { get; set; }

        public string Name { get; set; }

        public Department Department { get; set; }

        public string Client { get; set; }

        public string Manager { get; set; }

        public string Employees { get; set; }

        public string Introduction { get; set; }

        public string Content { get; set; }

        public string Conclusion { get; set; }

        public string Budget { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime? CloseDate { get; set; }

        public bool ForShare { get; set; }
    }

    public class ListProjectViewModel
    {
        public IEnumerable<ProjectViewModel> ProjectViewModels { get; set; }
    }


}
