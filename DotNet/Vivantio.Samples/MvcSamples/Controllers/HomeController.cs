using System.Web.Mvc;

namespace Vivantio.Samples.MvcSamples.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Error()
		{
			return View();
		}
	}
}