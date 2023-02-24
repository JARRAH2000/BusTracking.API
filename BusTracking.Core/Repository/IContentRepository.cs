using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Repository
{
	public  interface IContentRepository
	{
		IEnumerable<Content?> GetAllContents();
		void CreateContent(Content content);
		void UpdateContent(Content content);
	}
}
