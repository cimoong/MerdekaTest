using System;
using System.Collections.Generic;

#nullable disable

namespace MerdekaReservasi.Models
{
    public partial class TblMStatus
    {
        public int StatusPk { get; set; }
        public string NamaStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
