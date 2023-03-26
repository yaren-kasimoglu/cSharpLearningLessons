using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StockControlProject.Entities.Entities;
using System;
using System.Text;

namespace StockControlProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        string uri = "https://localhost:7109";
        public async Task<IActionResult> Index()
        {
            List<Category> kategoriler = new List<Category>();
            using (var httpClient = new HttpClient())
            {
                using (var cevap = await httpClient.GetAsync($"{uri}/api/Category/TumKategorileriGetir"))
                {
                    string apiCevap = await cevap.Content.ReadAsStringAsync();
                    kategoriler = JsonConvert.DeserializeObject<List<Category>>(apiCevap);
                }
            }
            return View(kategoriler);
        }
        [HttpGet]
        public async Task<IActionResult> KategoriAktiflestir(int id)
        {
            //List<Category> kategoriler = new List<Category>();
            using (var httpClient = new HttpClient())
            {
                using (var cevap = await httpClient.GetAsync($"{uri}/api/Category/KategoriAktiflestir/{id}"))
                {
                }
            }
            //return View(kategoriler);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> KategoriSil(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var cevap = await httpClient.DeleteAsync($"{uri}/api/Category/KategoriSil/{id}"))
                {

                }
            }
            //return View(kategoriler);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult KategoriEkle()
        {
            return View(); // Sadece Ekleme view'ını gösterecek
        }
        [HttpPost]
        public async Task<IActionResult> KategoriEkle(Category category)
        {
            category.IsActive = true;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");
                using (var cevap = await httpClient.PostAsync($"{uri}/api/Category/KategoriEkle", content))
                {
                    string apiCevap = await cevap.Content.ReadAsStringAsync();
                    //kategoriler = JsonConvert.DeserializeObject<List<Category>>(apiCevap);
                }
            }
            return RedirectToAction("Index");
        }
        //TODO : Kategori Güncelleme İşlemleri
        static Category updateCategory; 
        [HttpGet]
        public async Task<IActionResult> KategoriGuncelle(int id)// id ile ilgili kategoriyi bul getir.
        {

            using (var httpClient = new HttpClient())
            {
                using (var cevap = await httpClient.GetAsync($"{uri}/api/Category/IdyeGoreKategoriGetir/{id}"))
                {
                    string apiCevap = await cevap.Content.ReadAsStringAsync();
                    updateCategory = JsonConvert.DeserializeObject<Category>(apiCevap);
                }
            }
            return View(updateCategory); // update edilecek kategoriyi güncelleme View'ınıa gösterecek.
        }
        [HttpPost]
        public async Task<IActionResult> KategoriGuncelle(Category guncelKategori) // Guncellenmiş kategori parametre olarak alınır
        {

            using (var httpClient = new HttpClient())
            {

                guncelKategori.AddedDate = updateCategory.AddedDate;
                guncelKategori.IsActive = true;

                StringContent content = new StringContent(JsonConvert.SerializeObject(guncelKategori), Encoding.UTF8, "application/json");

                using (var cevap = await httpClient.PutAsync($"{uri}/api/Category/KategorileriGuncelle/{guncelKategori.Id}", content))
                {
                    string apiCevap = await cevap.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index"); // update edilecek kategoriyi güncelleme View'ınıa gösterecek.
        }
    }
}

