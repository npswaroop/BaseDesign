using DataAccess;
using DataAccess.Infrastructure;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public class UserManager : Repository<User>, IUserManager
	{
		private readonly IPersistent<User> _UserRepository;

		public UserManager(IUnitOfWorkManager unitOfWorkManager, IUnityContext context,
							  IPersistent<User> userRepository) : base(unitOfWorkManager, context)
		{
			_UserRepository = userRepository;
		}

		public bool isvaliduser(int UserId)
		{
			return _UserRepository.All().FirstOrDefault(f => f.Id == UserId) != null;
		}
	}
}
