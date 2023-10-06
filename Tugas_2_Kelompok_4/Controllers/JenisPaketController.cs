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
                    id_jenis = "JNS001",
                    nama_jenis = "Barang",
                },
                new Jenis_paket
                {
                    id_jenis = "JNS002",
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
                int maxId = Jenis_Pakets
                    .Where(p => p.id_jenis.StartsWith("JNS"))
                    .Select(p => int.TryParse(p.id_jenis.Replace("JNS", ""), out int num) ? num : 0)
                    .DefaultIfEmpty()
                    .Max();

                int new_id = maxId + 1;
                string new_id_string = $"JNS{new_id:D3}";

                jenis_paket.id_jenis = new_id_string;

                Jenis_Pakets.Add(jenis_paket);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }

            return View(jenis_paket);
        }

        [HttpPost]
        public IActionResult Delete(string id)
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
        public IActionResult Edit(string id)
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
                Jenis_paket existingJenisPaket = Jenis_Pakets.FirstOrDefault(b => b.id_jenis == jenis_paket.id_jenis);

                if (existingJenisPaket == null)
                {
                    return NotFound();
                }

                existingJenisPaket.nama_jenis = jenis_paket.nama_jenis;

                TempData["SuccessMessage"] = "Data berhasil diupdate.";
                return RedirectToAction("Index");
            }

            return View(jenis_paket);
        }
    }
}
