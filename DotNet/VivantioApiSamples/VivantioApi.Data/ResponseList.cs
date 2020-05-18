using System.Collections.Generic;

namespace VivantioApi.Data
{
	public class ResponseList<T>
	{
		public List<T> Results { get; set; }

		public ResponseList()
		{
			Results = new List<T>();
		}
	}
}
