using Sprague.Andy.WeddingAzure.DataAccess.Rsvp;
using Sprague.Andy.WeddingAzure.Models.Rsvp;
using System.Threading.Tasks;
using System.Web.Mvc;
using Serilog;
using Sprague.Andy.WeddingAzure.DataAccess;
using Sprague.Andy.WeddingAzure.DataAccess.Mail;

namespace WeddingAzure.Controllers
{
    public class GalleryController : Controller
    {
        public static ILogger _log = Log.ForContext<GalleryController>();

        public ActionResult Index()
        {
            ViewBag.Message = "Gallery.";

            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            //Log the error!!
            _log.Error(filterContext.Exception.Message);

            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}