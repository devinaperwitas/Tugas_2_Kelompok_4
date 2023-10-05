using Microsoft.AspNetCore.Mvc;
using Tugas_2_Kelompok_4.Models;
using System;


namespace Tugas_2_Kelompok_4.Controllers
{
    public class PaketController : Controller
    {
        private static List<Paket> pakets = InitializeData();

        private static List<Paket> InitializeData()
        {
            List<Paket> initialData = new List<Paket>
            {
                new Paket
                {
                    id = 1,
                    jenis = "Barang",
                    nama_pemilik = "Mukhasim",
                    telp = "085645212341",
                    tanggal_sampai = new DateOnly(2023, 9, 24)
                },
                new Paket
                {
                    id = 2,
                    jenis = "Dokumen",
                    nama_pemilik = "Rafa",
                    telp = "085645212112",
                    tanggal_sampai = new DateOnly(2023, 9, 24)
                }
            };
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
                int new_id = 1;

                while (pakets.Any(b => b.id == new_id))
                {
                    new_id++;
                }

                paket.id = new_id;

                pakets.Add(paket);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }

            return View(paket);
        }

        [HttpPost]
        public IActionResult Delete(int id)
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
        public IActionResult Edit(int id)
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
                Paket newPaket = pakets.FirstOrDefault(b => b.id == paket.id);

                if (newPaket == null)
                {
                    return NotFound();
                }

                newPaket.jenis = paket.jenis;
                newPaket.nama_pemilik = paket.nama_pemilik;
                newPaket.telp = paket.telp;
                newPaket.tanggal_sampai = paket.tanggal_sampai;

                TempData["SuccessMessage"] = "Data berhasil diupdate.";
                return RedirectToAction("Index");
            }

            return View(paket);
        }
    }
}
