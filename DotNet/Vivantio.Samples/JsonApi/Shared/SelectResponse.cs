using System.Collections.Generic;

namespace Vivantio.Samples.JsonApi.Shared
{
	public class SelectResponse<T> : Response
	{
		public List<T> Results { get; set; }

		public SelectResponse()
		{
			Results = new List<T>();
		}
	}
}