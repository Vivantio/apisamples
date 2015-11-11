using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Vivantio.Samples.DTO.Common
{
	public class Query
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public QueryMode Mode { get; set; }
		public List<QueryItem> Items { get; private set; }

		public Query()
		{
			Items = new List<QueryItem>();
		}
	}

	public class QueryItem
	{
		public string FieldName { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public Operator Op { get; set; }
		public object Value { get; set; }
	}
}