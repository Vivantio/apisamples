using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Vivantio.Samples.DTO.Common;

namespace Vivantio.Samples.DTO.TicketManagement
{
	public class Ticket
	{
		public int Id { get; set; }
		public string DisplayId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public StatusType StatusType { get; set; }
		public int StatusId { get; set; }
		public string StatusName { get; set; }
		public int PriorityId { get; set; }
		public string PriorityName { get; set; }
		public int? CategoryId { get; set; }
		public string CategoryLineage { get; set; }
	}
}