using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPSP_DAL
{
    public class BasicEntity : IBasicEntity
    {
        protected const int ExtraSmallColumnLength = 10;
        protected const int SmallColumnLength = 50;
        protected const int MediumColumnLength = 255;

        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();

        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedUtc { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        public bool IsActive { get; set; } = true;

        [NotMapped]
        public bool IsValid
        {
            get { return Validate().Count == 0; }
        }

        public ICollection<ValidationResult> Validate()
        {
            var result = new List<ValidationResult>();
            Validator.TryValidateObject(this, new ValidationContext(this), result, true);
            return result;
        }

    }
}
