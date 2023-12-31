﻿using System.ComponentModel.DataAnnotations;

namespace Tugas_2_Kelompok_4.Models
{
    public class Jenis_paket
    {
        public string? id_jenis { get; set; }

        [Required(ErrorMessage = "Jenis paket wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Jenis paket maksimal 30 karakter")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Jenis paket hanya memungkinkan huruf, spasi, dan backspace.")]
        public string nama_jenis { get; set; }

    }
}
