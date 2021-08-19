using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MerdekaReservasi.Models
{
    public partial class TblTReservasi
    {
        public int ReservasiPk { get; set; }

        [Required]
        [DisplayName("Ruangan")]
        public int? RuanganFk { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        [DisplayName("Subject Reservasi")]
        public string SubjectReservasi { get; set; }

        [Required]
        [DisplayName("Tanggal Reservasi")]
        public DateTime? TanggalReservasi { get; set; }

        [Required]
        [DisplayName("Jam Mulai")]
        public TimeSpan? JamMulai { get; set; }

        [Required]
        [DisplayName("Jam Selesai")]
        public TimeSpan? JamSelesai { get; set; }


        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class TblTReservasiIndex
    {
        public int ReservasiPk { get; set; }

        [Required]
        [DisplayName("Ruangan")]
        public int? RuanganFk { get; set; }
        public string NamaRuangan { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        [DisplayName("Subject Reservasi")]
        public string SubjectReservasi { get; set; }

        [Required]
        [DisplayName("Tanggal Reservasi")]
        public DateTime? TanggalReservasi { get; set; }
        public string StringTanggalReservasi { get; set; }

        [Required]
        [DisplayName("Jam Mulai")]
        public TimeSpan? JamMulai { get; set; }

        [Required]
        [DisplayName("Jam Selesai")]
        public TimeSpan? JamSelesai { get; set; }


        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
