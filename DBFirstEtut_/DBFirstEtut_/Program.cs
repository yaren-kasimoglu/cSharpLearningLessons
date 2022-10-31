// See https://aka.ms/new-console-template for more information
using DBFirstEtut_.Models;
using System.Linq;
using System.Reflection;

//OrdetDate();
//BetweenPrice();
//StartNameWithC();
//FaxNumber();
//CountryBrazil();
//CountryNotBrazil();
//Countries();
//OrderBy();
//Categories();
GetMostExp();

static void GetMostExp()
{
    using (NorthwindContext db = new NorthwindContext())
    {
        var result = db.Products.OrderByDescending(x => x.UnitPrice).FirstOrDefault();
        Console.WriteLine($"{result.ProductName}");
    }
}
static void Categories()
{
    using (NorthwindContext db = new NorthwindContext())
    {
        var result = db.Products.Where(x => x.CategoryId == 1);

        Console.WriteLine(result.Count());
    }
}
static void OrderBy()
{
    using (NorthwindContext db = new NorthwindContext())
    {
        var result = db.Products.OrderByDescending(x => x.UnitPrice).ThenBy(x=>x.UnitsInStock);

        foreach (var item in result)
        {
            Console.WriteLine($"{item.ProductName, -40} {item.UnitsInStock, -40} {item.UnitPrice} ");
        }
    }
}
static void OrdetDate()
{
    using (NorthwindContext db = new NorthwindContext())
    {
        var result = db.Orders.Where(x => x.OrderDate> Convert.ToDateTime("1996 - 07 - 01") && x.OrderDate < Convert.ToDateTime("1996 - 12 - 31"));

              foreach (var item in result)
        {
            Console.WriteLine($"{item.OrderId,-50} {item.OrderDate}");
        }
    }
}
//50 -100 arasında olanların fiyat ve isimleri
static void BetweenPrice()
{
    using (NorthwindContext db = new NorthwindContext())
    {
        var result = db.Products.Where(x => x.UnitPrice > 50 && x.UnitPrice < 100);

        foreach (var item in result)
        {
            Console.WriteLine($"{item.ProductName,-50} {item.UnitPrice}");
        }
    }
}
//adı c ile başlayan ürünler
static void StartNameWithC()
{
    using (NorthwindContext db = new NorthwindContext())
    {
        var result = db.Products.Where(x => x.ProductName.StartsWith("C"));

        foreach (var item in result)
        {
            Console.WriteLine($"{item.ProductName,-50} {item.UnitPrice}");
        }
    }
}
//Fax numarasını bilmediğim müşteriler
static void FaxNumber()
{
    using (NorthwindContext db = new NorthwindContext())
    {
        var result = db.Customers.Where(x => x.Fax == null);

        foreach (var item in result)
        {
            Console.WriteLine($"{item.CompanyName}");
        }
    }
}
//ülkesi brazil olanların  bilgileri
static void CountryBrazil()
{
    using (NorthwindContext db = new NorthwindContext())
    {
        var result = db.Customers.Where(x => x.Country.Equals("Brazil"))
                                                .Select(x => new
                                                {
                                                    CompanyName = x.CompanyName,
                                                    ContactName = x.ContactName,
                                                    Address = x.Address,
                                                    City = x.City,
                                                    Country = x.Country,
                                                });
        foreach (var item in result)
        {
            Console.WriteLine($"{item.CompanyName,-40}{item.ContactName,-40} {item.Address,-40}{item.City,-40} {item.Country} ");
        }

    }
}
//ülkesi brazil olmayanlar
static void CountryNotBrazil()
{
    using (NorthwindContext db = new NorthwindContext())
    {

        var result = db.Customers.Where(x => x.Country != "Brazil").ToList();
        foreach (var item in result)
        {
            Console.WriteLine($"{item.CompanyName,-30}{item.ContactName,-30} {item.Address,-30}{item.City,-30} {item.Country} ");
        }

    }
}
//ülkesi france germany veya spain olanlar
static void Countries()
{
    using (NorthwindContext db=new NorthwindContext())
    {
        string[] Ulkeler = { "Spain", "France", "Germany" };

        var result = db.Customers.Where(x => Ulkeler.Contains(x.Country));

        foreach (var item in result)
        {
            Console.WriteLine($"{item.CompanyName,-40}{item.ContactName,-40} {item.Address,-40}{item.City,-40} {item.Country} ");
        }   
}
}