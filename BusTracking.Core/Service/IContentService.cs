using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Service
{
	public interface IContentService
	{
		IEnumerable<Content?> GetAllContents();
		void CreateContent(Content content);
		void UpdateContent(Content content);
	}
}
