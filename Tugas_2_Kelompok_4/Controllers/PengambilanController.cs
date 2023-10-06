using Microsoft.AspNetCore.Mvc;
using Tugas_2_Kelompok_4.Models;

namespace Tugas_2_Kelompok_4.Controllers
{
    public class PengambilanController : Controller
    {
        private static List<Pengambilan> pengambilans = InitializeData();
        private static int currentId = 3;

        private static List<Pengambilan> InitializeData()
        {
            List<Pengambilan> initialData = new List<Pengambilan>
            {
                new Pengambilan
                {
                    id_pengambilan = "PGN001",
                    jenis = "Barang",
                    nama_pemilik = "Mukhasim",
                    nama_pengambil = "Mukhasim",
                    nim_npk = "0320220134",
                    tanggal_pengambilan = new DateTime(2023, 9, 28)
                },
                new Pengambilan
                {
                    id_pengambilan = "PGN002",
                    jenis = "Dokumen",
                    nama_pemilik = "Rafa",
                    nama_pengambil = "Dinda",
                    nim_npk = "0420220134",
                    tanggal_pengambilan = new DateTime(2023, 9, 29)
                }
            };
            currentId = 3; // Mengatur id berikutnya untuk data yang akan ditambahkan.
            return initialData;
        }


        public IActionResult Index()
        {
            List<Pengambilan> pengambilanList = pengambilans.ToList();
            return View(pengambilanList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pengambilan pengambilan)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(pengambilan.tanggal_pengambilan);
                string newId = $"PGN{currentId:D3}"; // Membuat id dengan format PKTXXX

                pengambilan.id_pengambilan = newId;

                pengambilans.Add(pengambilan);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                currentId++; // Menambahkan id berikutnya
                return RedirectToAction("Index");
            }

            return View(pengambilan);
        }
    }
}
