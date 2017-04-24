using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DPSP_UI_LG.Models
{
    //[JsonObject("Value")]
    //public class ProjectViewModel
    //{
    //    [JsonProperty("odata.type")]
    //    public string Type { set; get; }

    //    public string Name { get; set; }

    //    public string Department { get; set; }

    //    public string Client { get; set; }

    //    public string Manager { get; set; }

    //    public string Employees { get; set; }

    //    public string Introduction { get; set; }

    //    public string Content { get; set; }

    //    public string Conclusion { get; set; }

    //    public string Budget { get; set; }

    //    public DateTime OpenDate { get; set; }

    //    public DateTime? CloseDate { get; set; }

    //    //public DateTime CreatedUtc { get; set; }

    //    //public DateTime? ModifiedUtc { get; set; }

    //    //public byte[] Version { get; set; }

    //    //public bool IsActive { get; set; }

    //    public bool ForShare { get; set; }
    //}

    [JsonObject("Odata")]
    public class ODataProject
    {
        [JsonProperty("odata.metadata")]
        public string Metadata { get; set; }
        [JsonProperty("Value")]
        public List<ProjectViewModel> Projects { get; set; }
    }


}
