using BuildingForms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingForms.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(ProductRepository.Products);  /* _products ları göndermiş oluyorum */
                                                      /* Create formu içerisine girilen bilgiler product nesnesinin içine paketleniyor.
                                                       Ve Paketlenen bilgiler Index action metoduna gönderiliyor. Arka taraftaki Produts listesi tarafından
                                                      yapılıyor.*/
        }

        [HttpGet]
        public IActionResult Create()   //öreneğin create.cshtml yani view dosyasındaki tüm bilgilerin burada karşılanması gerekir.
                                        //Bu da @model Product ile mümkün. Çünkü Product modelinin içinde Name,Description,Price,IsApproved alanları var.
        {
            ViewBag.Categories = new SelectList(new List<string>() {"Hikaye","Roman","Siir" });    // ViewBag içerisinde Categories adında bir değişken oluşturuyoruz.
                                                                                                   // SelectList ile elemanlarımızı new List içerisinde tekrar oluşturalım.
                                                                                                   // ViewBag ile Categories leri Create.cshtml üzerine taşıyorum.
                                                                                                   // Sayfa üzerine taşıdıktan sonra Create.cshtml üzerinde typeof ile tür dönüşümü yapmama gerek kalmayacak.

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)    // Get metodundaki Create den farklı olması gerekiyor.
                                         // Post içinde tüm nesneleri almak için Product türüne product nesnesi yaratmalıyız
        {
            // Kayıt işlemi
            // Validation
            ProductRepository.AddProduct(product);  // product içindeki modelimizi AddProduct ile listemize ekliyoruz.AddProduct metodumuz ProductRepository içerisinde olduğu için ProductRepository.AddProduct(product) şeklinde yazıyoruz.
            return RedirectToAction("Index");   // Sayfamızı yönlendirmek için
        }

        // Home/Search?q=kelime

        [HttpGet]
        public IActionResult Search(string q)
        {
            if (string.IsNullOrWhiteSpace(q))    // Eğer q null ya da boşluk değerine eşitse search view ini göndereyim           
                return View();

            return View("Index",ProductRepository.Products.Where(a=>a.Name.Contains(q.ToUpper())));  // Eğer boş değilse Index view ine gitsin. Sadece view i çağrıyorum action ını çağırmıyorum.Model göndereceğim.
            // Gelen q değeri ile arama işlemleri yapılır.
           
        }

    }
}
