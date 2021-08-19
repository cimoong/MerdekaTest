using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MerdekaReservasi.Models
{
    public class Search
    {
        [DisplayName("Ruangan")]
        public int? RuanganFk { get; set; }
        [DisplayName("Subject Reservasi")]
        public string SubjectReservasi { get; set; }
        [DisplayName("Tanggal Reservasi")]
        public DateTime? TanggalReservasi { get; set; }
    }
}
