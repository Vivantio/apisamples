using System.Collections.Generic;
using Vivantio.Samples.DTO.Common;
using Vivantio.Samples.DTO.TicketManagement;
using Vivantio.Samples.JsonApi.Shared;

namespace Vivantio.Samples.JsonApi
{
	public class ConfigurationApi : BaseApi
	{
		public List<TicketType> TicketTypeSelectAll()
		{
			return ApiUtility.SendRequest<SelectResponse<TicketType>>("/Configuration/TicketTypeSelectAll").Results;
		}

		public List<Priority> PrioritySelectByRecordTypeId(int recordTypeId)
		{
			return ApiUtility.SendRequest<SelectResponse<Priority>>("/Configuration/PrioritySelectByRecordTypeId/" + recordTypeId).Results;
		}

		public List<Status> StatusSelectByRecordTypeId(int recordTypeId)
		{
			return ApiUtility.SendRequest<SelectResponse<Status>>("/Configuration/StatusSelectByRecordTypeId/" + recordTypeId).Results;
		}
	}
}