﻿using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Service
{
	public interface IParentService
	{
		IEnumerable<Parent?> GetAllParents();
		Parent? GetParentById(int id);
		int CreateParent(Parent parent);
		void DeleteParent(int id);
	}
}
