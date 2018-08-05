using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure
{
	public class WorkManager
	{
		protected readonly IUnitOfWorkManager UnitOfWorkManager;
		
		public WorkManager(IUnitOfWorkManager unitOfWorkManager)
		{
			UnitOfWorkManager = unitOfWorkManager;
		}
	}
}
