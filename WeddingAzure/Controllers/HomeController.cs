using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingAzure.Factories;
using WeddingAzure.Models;
using WeddingAzure.Services;

namespace WeddingAzure.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IImageService _imageService = new AzureBlobStoreImageService(
            "landowedding",
            "8j7qKtXTrFUFK3xjrZ3GBRxqvIay+/8divHV6Mmy5rwis16+f5ACG9FDFbqcxVnB7l1vrM5EzAvB8IgautEI8g=="
        );

        public ActionResult Index()
        {
            ViewBag.DaysToGo = (DateTime.Parse("2018-05-26") - DateTime.Today).TotalDays;
            ViewBag.JumbotronImage = _imageService.GetImageUri("img", "italy-like-a-bird.jpg");
            ViewBag.IconImage = _imageService.GetImageUri("img", "wedding-love-bird-icon.png");
            var weddingParty = WeddingPartyFactory.GetWeddingPartyMembers(_imageService);
            return View(weddingParty);
        }

        public ActionResult Details()
        {
            var accommodations = AccommodationFactory.GetAccommodations();

            ViewBag.Message = "Your application details page.";

            return View(accommodations);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}