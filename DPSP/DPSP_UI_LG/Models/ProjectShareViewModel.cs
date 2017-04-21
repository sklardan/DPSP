using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace DPSP_UI_LG.Models
{
    public class ProjectShareViewModel
    {
        public string Name { get; set; }

        public bool ForShare { get; set; }
    }

}
