using Sprague.Andy.WeddingAzure.DataAccess.Rsvp;
using Sprague.Andy.WeddingAzure.Models.Rsvp;
using System.Threading.Tasks;
using System.Web.Mvc;
using Serilog;
using Sprague.Andy.WeddingAzure.DataAccess;
using Sprague.Andy.WeddingAzure.DataAccess.Mail;

namespace WeddingAzure.Controllers
{
    public class RsvpController : Controller
    {
        public static ILogger _log = Log.ForContext<RsvpController>();

        public ActionResult Index()
        {
            ViewBag.Message = "RSVP Page.";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(Models.RsvpFormData formData)
        {
            if (formData.SongRequestTextBoxData != null && formData.SongRequestTextBoxData.ToLower().Contains("spice girl"))
            {
                ModelState.AddModelError("SongRequestTextBoxData", "Spice Girls? Seriously?");    
            }

            if (ModelState.IsValid)
            {
                var config = new ServiceConfiguration();
                var repo = new RsvpRepository(config);

                var rsvpEntity = new RsvpEntity(formData.NameTextBoxData)
                {
                    AttendingWedding = formData.AttendingWeddingCheckBox,
                    WillToastFromAfar = formData.WillToastFromAfar,
                    AttendingPopInThePark = formData.AttendingSundayCheckBox,
                    DietaryRequirements = formData.DietaryRequirementsTextBoxData,
                    SongRequest = formData.SongRequestTextBoxData
                };

                await repo.AddOrReplaceRsvpAsync(rsvpEntity);

                var email = new EmailManager(config);
                email.SendRsvpRecieved(rsvpEntity);

                return View("Success", formData);
            }
            return View(formData);
        }

        public ActionResult Success(Models.RsvpFormData formData)
        {
           return View(formData);
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