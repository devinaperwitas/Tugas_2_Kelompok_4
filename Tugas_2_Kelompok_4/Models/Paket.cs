﻿using System.ComponentModel.DataAnnotations;
using System;

namespace Tugas_2_Kelompok_4.Models
{
    public class Paket
    {
        public string? id { get; set; }


        [Required(ErrorMessage = "Jenis paket wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Jenis paket maksimal 30 karakter")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Jenis paket hanya memungkinkan huruf, spasi, dan backspace.")]
        public string jenis { get; set; }

        [Required(ErrorMessage = "Nama pemilik wajib diisi.")]
        [MaxLength(100, ErrorMessage = "Nama pemilik maksimal 100 karakter.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Nama pemilik hanya memungkinkan huruf, spasi, dan backspace.")]
        public string nama_pemilik { get; set; }

        //[Required(ErrorMessage = "Telepon wajib diisi.")]
        //[MaxLength(15, ErrorMessage = "Nomor telepon maksimal 15 karakter")]
        //public string telp { get; set; }

        [Required(ErrorMessage = "Telepon wajib diisi.")]
        [MinLength(12, ErrorMessage = "Nomor telepon minimal 12 karakter")]
        [MaxLength(15, ErrorMessage = "Nomor telepon maksimal 15 karakter")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Nomor telepon hanya boleh berisi angka.")]
        public string telp { get; set; }


        [Required(ErrorMessage = "Tanggal sampai wajib diisi.")]
        [DataType(DataType.Date)]
        public DateTime tanggal_sampai { get; set; }
    }
}
