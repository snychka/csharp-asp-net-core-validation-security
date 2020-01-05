using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferenceTracker.Entities
{
    public class Speaker : IValidatableObject
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public bool IsStaff { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            if(EmailAddress != null && EmailAddress.EndsWith("TechnologyLiveConference.com",StringComparison.InvariantCultureIgnoreCase))
            {
                var rejectedEmailAddress = new ValidationResult("Technology Live Conference staff should not use their conference email addresses.");
                validationResults.Add(rejectedEmailAddress);
            }
            return validationResults;
        }
    }
}
