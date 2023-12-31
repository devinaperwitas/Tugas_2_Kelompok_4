﻿using System.ComponentModel.DataAnnotations;

namespace Tugas_2_Kelompok_4.Models
{
    public class Pengambilan
    {
        public string? id_pengambilan { get; set; }

        [Required(ErrorMessage = "Jenis paket wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Jenis paket maksimal 30 karakter")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Jenis paket hanya memungkinkan huruf, spasi, dan backspace   .")]
        public string jenis { get; set; }

        [Required(ErrorMessage = "Nama pemilik wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Nama pemilik maksimal 30 karakter.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Nama pemilik hanya hanya memungkinkan huruf, spasi, dan backspace.")]
        public string nama_pemilik { get; set; }

        [Required(ErrorMessage = "Nama pengambil wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Nama pengambil maksimal 30 karakter.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Nama pengambil hanya memungkinkan huruf, spasi, dan backspace.")]
        public string nama_pengambil { get; set; }

        //[Required(ErrorMessage = "NIM/NPK wajib diisi.")]
        //[MaxLength(11, ErrorMessage = "NIM/NPK maksimal 11 karakter")]
        //public string nim_npk { get; set; }

        [Required(ErrorMessage = "NIM/NPK wajib diisi.")]
        [RegularExpression("^[0-9]{8,11}$", ErrorMessage = "NIM/NPK harus terdiri dari 8 hingga 11 karakter angka.")]
        public string nim_npk { get; set; }


        [Required(ErrorMessage = "Tanggal pengambilan sampai wajib diisi.")]
        [DataType(DataType.Date)]
        public DateTime tanggal_pengambilan { get; set; }

    }
}
