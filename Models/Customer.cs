using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name="Name of the customer")]
        public string Name { get; set; }
        public bool ISubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name="Select Membership")]
        public byte MembershiptypeId { get; set; }
            

    }   
}