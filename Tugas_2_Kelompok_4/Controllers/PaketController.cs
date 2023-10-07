using Microsoft.AspNetCore.Mvc;
using Tugas_2_Kelompok_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tugas_2_Kelompok_4.Controllers
{
    public class PaketController : Controller
    {
        private static List<Paket> pakets = InitializeData();
        private static int currentId = 3;

        private static List<Paket> InitializeData()
        {
            List<Paket> initialData = new List<Paket>
            {
                new Paket
                {
                    id = "PKT001",
                    jenis = "Barang",
                    nama_pemilik = "Mukhasim",
                    telp = "085645212341",
                    tanggal_sampai = new DateTime(2023, 9, 24)
                },
                new Paket
                {
                    id = "PKT002",
                    jenis = "Dokumen",
                    nama_pemilik = "Rafa",
                    telp = "085645212112",
                    tanggal_sampai = new DateTime(2023, 9, 24)
                }
            };
            currentId = 3; 
            return initialData;
        }

        public IActionResult Index()
        {
            List<Paket> paketList = pakets.ToList();
            return View(paketList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Paket paket)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(paket.tanggal_sampai);
                string newId = $"PKT{currentId:D3}"; // Membuat id dengan format PKTXXX

                paket.id = newId;

                pakets.Add(paket);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                currentId++; // Menambahkan id berikutnya
                return RedirectToAction("Index");
            }

            return View(paket);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var response = new { success = false, message = "Gagal menghapus data." };

            try
            {
                var paket = pakets.FirstOrDefault(b => b.id == id);
                if (paket != null)
                {
                    pakets.Remove(paket);
                    response = new { success = true, message = "Data berhasil dihapus." };
                }
                else
                {
                    response = new { success = false, message = "Data tidak ditemukan." };
                }
            }
            catch (Exception ex)
            {
                response = new { success = false, message = ex.Message };
            }

            return Json(response);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            Paket paket = pakets.FirstOrDefault(b => b.id == id);

            if (paket == null)
            {
                return NotFound();
            }

            return View(paket);
        }

        [HttpPost]
        public IActionResult Edit(Paket paket)
        {
            if (ModelState.IsValid)
            {
                Paket existingPaket = pakets.FirstOrDefault(b => b.id == paket.id);

                if (existingPaket == null)
                {
                    return NotFound();
                }

                existingPaket.jenis = paket.jenis;
                existingPaket.nama_pemilik = paket.nama_pemilik;
                existingPaket.telp = paket.telp;
                existingPaket.tanggal_sampai = paket.tanggal_sampai;

                TempData["SuccessMessage"] = "Data berhasil diupdate.";
                return RedirectToAction("Index");
            }

            return View(paket);
        }
    }
}
