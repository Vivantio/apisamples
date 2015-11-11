using System.Linq;
using System.Web.Mvc;
using Vivantio.Samples.DTO.Common;
using Vivantio.Samples.DTO.TicketManagement;
using Vivantio.Samples.JsonApi;
using Vivantio.Samples.MvcSamples.ViewModels.TaskBoard;

namespace Vivantio.Samples.MvcSamples.Controllers
{
	public class TaskBoardController : Controller
	{
		private readonly ConfigurationApi _configApi;
		private readonly TicketApi _ticketApi;

		public TaskBoardController()
		{
			_configApi = new ConfigurationApi();
			_ticketApi = new TicketApi();
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Board()
		{
			var ticketTypes = _configApi.TicketTypeSelectAll();

			var viewModel = new TaskBoardViewModel(ticketTypes.Where(tt => tt.Enabled));
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Tickets(int ticketTypeId)
		{
			var query = new Query();
			query.Items.Add(new QueryItem
								{
									FieldName = "RecordTypeId",
									Op = Operator.Equals,
									Value = ticketTypeId
								});
			query.Items.Add(new QueryItem
								{
									FieldName = "StatusType",
									Op = Operator.DoesNotEqual,
									Value = (int)StatusType.Deleted
								});
			query.Items.Add(new QueryItem
								{
									FieldName = "IsDeferred",
									Op = Operator.Equals,
									Value = false
								});
			return Json(_ticketApi.Select(query));
		}

		[HttpPost]
		public ActionResult Statuses(int ticketTypeId)
		{
			return Json(_configApi.StatusSelectByRecordTypeId(ticketTypeId).Where(s => s.Type != StatusType.Pending));
		}

		[HttpPost]
		public ActionResult ChangeStatus(int ticketId, int statusId)
		{
			return Json(_ticketApi.ChangeStatus(ticketId, statusId));
		}

		[HttpPost]
		public ActionResult Close(int ticketId, int statusId)
		{
			return Json(_ticketApi.Close(ticketId, statusId));
		}
	}
}