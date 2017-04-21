using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DPSP_DAL
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum e)
        {
            var attribute = e.GetType().GetMember(e.ToString()).FirstOrDefault()
                ?.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault() as DisplayAttribute;
            return attribute?.Name ?? Enum.GetName(e.GetType(), e);
        }
    }
}