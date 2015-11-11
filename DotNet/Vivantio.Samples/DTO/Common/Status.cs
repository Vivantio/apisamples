using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Vivantio.Samples.DTO.Common
{
	public class Status
	{
		public int Id { get; set; }
		public string Name { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public StatusType Type { get; set; }
	}
}