using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ILAManagementPro.Data.Data
{
    [Table("WorkDetails")]
    public class WorkDetail
    {
        [Key]
        public int DetlCounter { get; set; }

        public DateTime? DateOfWork { get; set; }

        public decimal? Header { get; set; }

        public int? Seq { get; set; }

        public decimal? CardNo { get; set; }

        [StringLength(1)]
        public string CheckIn { get; set; }

        public DateTime? CheckInTime { get; set; }

        [StringLength(1)]
        public string CheckOut { get; set; }

        public DateTime? CheckOutTime { get; set; }

        [StringLength(250)]
        public string DetlComment { get; set; }

        public DateTime? AddedDate { get; set; }

        [StringLength(20)]
        public string AddedUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(20)]
        public string UpdateUser { get; set; }
    }
}