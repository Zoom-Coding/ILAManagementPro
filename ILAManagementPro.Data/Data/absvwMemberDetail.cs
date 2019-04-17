using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ILAManagementPro.Data.Data
{
    [Table("absvwMemberDetails")]
    public class absvwMemberDetail
    {
        [Required]
        public decimal CardNo { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(1)]
        public string MI { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        public DateTime? DateBirth { get; set; }

        [StringLength(3)]
        public string ClassCode { get; set; }

        public byte[] Photo { get; set; }
    }
}