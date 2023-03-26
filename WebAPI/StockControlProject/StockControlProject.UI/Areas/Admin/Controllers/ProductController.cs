using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StockControlProject.Entities.Entities;
using System.Text;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StockControlProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        string uri = "https://localhost:7109";
        public async Task<IActionResult> Index()
        {
            List<Product> urunler = new List<Product>();
            using (var httpClient = new HttpClient())
            {
                using (var cevap = await httpClient.GetAsync($"{uri}/api/Product/TumUrunleriGetir"))
                {
                    string apiCevap = await cevap.Content.ReadAsStringAsync();
                    urunler = JsonConvert.DeserializeObject<List<Product>>(apiCevap);
                }
            }
            return View(urunler);
        }
        [HttpGet]
        public async Task<IActionResult> UrunAktiflestir(int id)
        {
            //List<Product> urunler = new List<Product>();
            using (var httpClient = new HttpClient())
            {
                using (var cevap = await httpClient.GetAsync($"{uri}/api/Product/UrunAktiflestir/{id}"))
                {
                    //string apiCevap = await cevap.Content.ReadAsStringAsync();
                    //urunler = JsonConvert.DeserializeObject<List<Product>>(apiCevap);
                }
            }
            //return View(urunler);
            return RedirectToAction("Index");
        }
        //[HttpDelete]
        public async Task<IActionResult> UrunSil(int id)
        {
            //List<Product> urunler = new List<Product>();
            using (var httpClient = new HttpClient())
            {
                using (var cevap = await httpClient.DeleteAsync($"{uri}/api/Product/UrunSil/{id}"))
                {
                    //string apiCevap = await cevap.Content.ReadAsStringAsync();
                    //urunler = JsonConvert.DeserializeObject<List<Product>>(apiCevap);
                }
            }
            //return View(urunler);
            return RedirectToAction("Index");
        }
       static List<Category> AktifKategoriler;
       static List<Supplier> AktifTedarikciler;

        [HttpGet]
        public async Task<IActionResult> UrunEkle()
        {
            
            using (var httpClient = new HttpClient())
            {
                using (var cevap = await httpClient.GetAsync($"{uri}/api/Product/AktifUrunleriGetir"))
                {
                    string apiCevap = await cevap.Content.ReadAsStringAsync();
                    AktifKategoriler = JsonConvert.DeserializeObject<List<Category>>(apiCevap);
                }
                using (var cevap = await httpClient.GetAsync($"{uri}/api/Supplier/AktifTedarikcileriGetir"))
                {
                    string apiCevap = await cevap.Content.ReadAsStringAsync();
                    AktifTedarikciler = JsonConvert.DeserializeObject<List<Supplier>>(apiCevap);
                }
            }

            @ViewBag.AktifKategoriler = new SelectList(AktifKategoriler, "Id","CategoryName");
            @ViewBag.AktifTedarikciler = new SelectList(AktifTedarikciler, "Id","SupplierName");
            return View(); // Sadece Ekleme view'ını gösterecek
        }
        [HttpPost]
        public async Task<IActionResult> UrunEkle(Product product)
        {
            product.IsActive = true;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
                using (var cevap = await httpClient.PostAsync($"{uri}/api/Product/UrunEkle", content))
                {
                    string apiCevap = await cevap.Content.ReadAsStringAsync();
                    //urunler = JsonConvert.DeserializeObject<List<Product>>(apiCevap);
                }
            }
            return RedirectToAction("Index");
        }
        //TODO : Urun Güncelleme İşlemleri
        static Product updateProduct; // İlgili urunyi guncelleme işleminin devamında(put) kullanacağımız için o metottan da ualaşabilmek adına globalde tanımlayalım.
        //DateTime eklenmeTarihi = updateProduct.AddedDate;
        [HttpGet]
        public async Task<IActionResult> UrunGuncelle(int id)// id ile ilgili urunyi bul getir.
        {

            using (var httpClient = new HttpClient())
            {
                using (var cevap = await httpClient.GetAsync($"{uri}/api/Product/IdyeGoreUrunleriGetir/{id}"))
                {
                    string apiCevap = await cevap.Content.ReadAsStringAsync();
                    updateProduct = JsonConvert.DeserializeObject<Product>(apiCevap);
                }

                using (var cevap = await httpClient.GetAsync($"{uri}/api/Product/AktifUrunleriGetir"))
                {
                    string apiCevap = await cevap.Content.ReadAsStringAsync();
                    AktifKategoriler = JsonConvert.DeserializeObject<List<Category>>(apiCevap);
                }
                using (var cevap = await httpClient.GetAsync($"{uri}/api/Supplier/AktifTedarikcileriGetir"))
                {
                    string apiCevap = await cevap.Content.ReadAsStringAsync();
                    AktifTedarikciler = JsonConvert.DeserializeObject<List<Supplier>>(apiCevap);
                }
            }
            @ViewBag.AktifKategoriler = new SelectList(AktifKategoriler, "Id", "CategoryName");
            @ViewBag.AktifTedarikciler = new SelectList(AktifTedarikciler, "Id", "SupplierName");
            return View(updateProduct); // update edilecek urunyi güncelleme View'ınıa gösterecek.
        }
        [HttpPost]
        public async Task<IActionResult> UrunGuncelle(Product guncelUrun) // Guncellenmiş urun parametre olarak alınır
        {

            using (var httpClient = new HttpClient())
            {

                guncelUrun.AddedDate = updateProduct.AddedDate;
                guncelUrun.IsActive = true;

                StringContent content = new StringContent(JsonConvert.SerializeObject(guncelUrun), Encoding.UTF8, "application/json");

                using (var cevap = await httpClient.PutAsync($"{uri}/api/Product/UrunGuncelle/{guncelUrun.Id}", content))
                {
                    string apiCevap = await cevap.Content.ReadAsStringAsync();
                    //urunler = JsonConvert.DeserializeObject<List<Product>>(apiCevap);
                }


            }
            return RedirectToAction("Index"); // update edilecek urunyi güncelleme View'ınıa gösterecek.
        }
    }
}