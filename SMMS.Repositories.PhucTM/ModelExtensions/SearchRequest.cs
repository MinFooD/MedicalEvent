using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.Repositories.PhucTM.ModelExtensions
{
	public class SearchRequest
	{
		public int? CurrentPage { get; set; }
		public int? PageSize { get; set; }
	}

	public class SearchMedicalEventRequest : SearchRequest
	{
		public string? Des1 { get; set; }
		public decimal? HeartRate { get; set; }
		public string? Des2 { get; set; }
	}


}
