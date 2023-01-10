using FutbolcuUyg.Models;
using FutbolcuUyg.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace FutbolcuUyg.Controllers
{
    public class FutbolcuController : Controller
    {
        List<Mevki> mevkiler = new List<Mevki>()
        {
            new Mevki{Id=1, MevkiName="Kaleci"},
            new Mevki{Id=2, MevkiName="Defans"},
            new Mevki{Id=3, MevkiName="Orta Saha"},
            new Mevki{Id=4, MevkiName="Forvet"}

        };

        List<Takim> takimlar = new List<Takim>()
        {
            new Takim{TakimId=1,TakimAdi="Fenerbahçe"},
            new Takim{TakimId=2,TakimAdi="Galatasaray"},
            new Takim{TakimId=3,TakimAdi="Beşiktaş"},
            new Takim{TakimId=4,TakimAdi="TrabzonSpor"}
        };

        List<Futbolcu> futbolcular = new List<Futbolcu>()
        {
            new Futbolcu{Id=1, AdiSoyadi="Yaren Kasımoğlu", MevkiId=1, TakimId=1},
            new Futbolcu{Id=2, AdiSoyadi="Toprak", MevkiId=2, TakimId=2},
            new Futbolcu{Id=3, AdiSoyadi="Metin", MevkiId=3, TakimId=3},
            new Futbolcu{Id=4, AdiSoyadi="Birsen", MevkiId=4, TakimId=4},
            new Futbolcu{Id=5, AdiSoyadi="Berivan", MevkiId=1, TakimId=1},
            new Futbolcu{Id=6, AdiSoyadi="Berrin", MevkiId=3, TakimId=2},
        };

        public IActionResult Index()
        {
            ListVM list = new ListVM();
            list.Futbolcular = futbolcular;
            list.Mevkiler = mevkiler;
            list.Takimlar = takimlar;

            return View(list);
        }

        public IActionResult Create()
        {
            CreateVM create = new CreateVM();
            create.Futbolcu = new Futbolcu();
            create.Mevki = mevkiler;
            create.Takim = takimlar;
            return View(create);
        }
        [HttpPost]
        public IActionResult Create(Futbolcu futbolcu)
        {
            futbolcular.Add(futbolcu);

            ListVM list = new ListVM();
            list.Futbolcular = futbolcular;
            list.Mevkiler = mevkiler;
            list.Takimlar = takimlar;

            return View("Index",list);
        }

    }
}
