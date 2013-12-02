using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models
{
    [MetadataType(typeof(Contact_Metadata))]
    public partial class Contact { }

    public class Contact_Metadata
    {
        [Required]
        [MaxLength(50)]
        [EmailAddress]
        [DisplayName("Epostadress")]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Efternamn")]
        public string LastName { get; set; }
    }
}