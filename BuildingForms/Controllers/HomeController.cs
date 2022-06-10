using BuildingForms.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Search(string q)
        {
            // Gelen q değeri ile arama işlemleri yapılır.
            return View();
        }

    }
}
