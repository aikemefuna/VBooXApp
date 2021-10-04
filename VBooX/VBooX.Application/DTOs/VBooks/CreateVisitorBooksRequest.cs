using System;
using System.ComponentModel.DataAnnotations;

namespace VBooX.Application.DTOs.VBooks
{
    public class CreateVisitorBooksRequest
    {
        [Display(Name = "Visitor First Name")]
        [RegularExpression("^[A-Z a-z.-]*$", ErrorMessage = "First name can only take alphabeths.")]
        [StringLength(50)]
        public string VisitorFirstName { get; set; }

        [Display(Name = "Visitor Last Name")]
        [RegularExpression("^[A-Z a-z.-]*$", ErrorMessage = "Last name can only take alphabeths.")]
        [StringLength(50)]
        public string VisitorLastName { get; set; }


        [Display(Name = "Visitor Phone number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid Phone number")]
        [RegularExpression("^[+0-9]*$", ErrorMessage = "Please enter a valid Phone number")]
        [MaxLength(15, ErrorMessage = "Please enter a valid Phone number")]
        [MinLength(11, ErrorMessage = "Please enter a valid Phone number")]
        [Phone(ErrorMessage = "Please enter a valid Phone number")]
        public string VisitorPhoneNo { get; set; }


        [Display(Name = "Visitor Email")]
        [EmailAddress]
        public string VisitorEmail { get; set; }


        [StringLength(150)]
        [Display(Name = "Visitor Address")]
        public string VisitorAddress { get; set; }


        [Display(Name = "Proposed Visit Date")]
        public DateTime ProposedVisitDate { get; set; }


        [Display(Name = "Proposed Visit Time")]
        public int Time { get; set; }


        [StringLength(500)]
        [Display(Name = "Purpose Of Visit")]
        public string PurposeOfVisit { get; set; }
        public bool IsCustomerCreated { get; set; }
        [Display(Name = "Purpose Of Visit")]
        public string AccountNumber { get; set; }
    }
}
