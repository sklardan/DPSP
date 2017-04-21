using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSP_DAL
{
    public interface IBasicEntity
    {
        Guid Id { get; }
        DateTime CreatedUtc { get; set; }
        DateTime? ModifiedUtc { get; set; }
        byte[] Version { get; set; }
        bool IsActive { get; set; }
        bool IsValid { get; }
    }
}
