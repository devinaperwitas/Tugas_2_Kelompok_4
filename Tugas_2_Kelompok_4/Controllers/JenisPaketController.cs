using Microsoft.AspNetCore.Mvc;
using Tugas_2_Kelompok_4.Models;

namespace Tugas_2_Kelompok_4.Controllers
{
    public class JenisPaketController : Controller
    {
        private static List<Jenis_paket> Jenis_Pakets = InitializeData();

        private static List<Jenis_paket> InitializeData()
        {
            List<Jenis_paket> initialData = new List<Jenis_paket>
            {
                new Jenis_paket
                {
                    id_jenis = 1,
                    nama_jenis = "Barang",
                },
                new Jenis_paket
                {
                    id_jenis = 2,
                    nama_jenis = "Dokumen",
                }
            };
            return initialData;
        }

        public IActionResult Index()
        {
            List<Jenis_paket> jenis_paketList = Jenis_Pakets.ToList();
            return View(jenis_paketList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Jenis_paket jenis_paket)
        {
            if (ModelState.IsValid)
            {
                int new_id = 1;

                while (Jenis_Pakets.Any(b => b.id_jenis == new_id))
                {
                    new_id++;
                }

                jenis_paket.id_jenis = new_id;

                Jenis_Pakets.Add(jenis_paket);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }

            return View(jenis_paket);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var response = new { success = false, message = "Gagal menghapus data." };

            try
            {
                var jenis_paket = Jenis_Pakets.FirstOrDefault(b => b.id_jenis == id);
                if (jenis_paket != null)
                {
                    Jenis_Pakets.Remove(jenis_paket);
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
            Jenis_paket jenis_paket = Jenis_Pakets.FirstOrDefault(b => b.id_jenis == id);

            if (jenis_paket == null)
            {
                return NotFound();
            }

            return View(jenis_paket);
        }

        [HttpPost]
        public IActionResult Edit(Jenis_paket jenis_paket)
        {
            if (ModelState.IsValid)
            {
                Jenis_paket newJenisPaket = Jenis_Pakets.FirstOrDefault(b => b.id_jenis == jenis_paket.id_jenis);

                if (newJenisPaket == null)
                {
                    return NotFound();
                }

                newJenisPaket.nama_jenis = jenis_paket.nama_jenis;

                TempData["SuccessMessage"] = "Data berhasil diupdate.";
                return RedirectToAction("Index");
            }

            return View(jenis_paket);
        }
    }
}
