using System.Collections.Generic;
using Vivantio.Samples.DTO.Common;
using Vivantio.Samples.DTO.TicketManagement;
using Vivantio.Samples.JsonApi.Shared;

namespace Vivantio.Samples.JsonApi
{
	public class TicketApi : BaseApi
	{
		public List<Ticket> Select(Query query)
		{
			return ApiUtility.SendRequest<SelectResponse<Ticket>, SelectRequest>("/Ticket/Select", new SelectRequest
																										{
																											Query = query
																										}).Results;
		}

		public Response ChangeStatus(int ticketId, int statusId)
		{
			return ApiUtility.SendRequest<Response, dynamic>("/Ticket/ChangeStatus", new
																						{
																							AffectedTickets = new[] { ticketId },
																							StatusId = statusId
																						});
		}

		public Response Close(int ticketId, int statusId)
		{
			return ApiUtility.SendRequest<Response, dynamic>("/Ticket/Close", new
																				{
																					AffectedTickets = new[] { ticketId },
																					CloseStatusId = statusId
																				});
		}
	}
}