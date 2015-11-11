using System.Collections.Generic;
using Vivantio.Samples.DTO.TicketManagement;

namespace Vivantio.Samples.MvcSamples.ViewModels.TaskBoard
{
	public class TaskBoardViewModel
	{
		public IEnumerable<TicketType> TicketTypes { get; private set; }

		public TaskBoardViewModel(IEnumerable<TicketType> ticketTypes)
		{
			TicketTypes = ticketTypes;
		}
	}
}