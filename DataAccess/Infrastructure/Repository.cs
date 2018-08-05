using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Infrastructure
{
	public class Repository<T> : WorkManager, IPersistent<T> where T: class
	{
		private readonly UnityContext Context;

		private IDbSet<T> Entities
		{
			get
			{
				return this.Context.Set<T>();
			}
		}

		public Repository(IUnitOfWorkManager unitOfWorkManager, IUnityContext context) : base(unitOfWorkManager)
		{
			Context = context as UnityContext;
		}

		public T Create(T item)
		{
			using (var unitOfWork = UnitOfWorkManager.NewUnitOfWork())
			{
				Entities.Add(item);

				unitOfWork.Commit();

				return item;
			}				
		}

		public T Read(object id)
		{
			using (var unitOfWork = UnitOfWorkManager.NewUnitOfWork())
			{
				return Entities.Find(id);
			}
		}

		public void Update(T item)
		{
			using (var unitOfWork = UnitOfWorkManager.NewUnitOfWork())
			{
				 if (item != null)
                {
                    Context.Entry(item).State = EntityState.Modified;

                    unitOfWork.Commit();
                }
			}
		}

		public void Delete(T item)
		{
			using (var unitOfWork = UnitOfWorkManager.NewUnitOfWork())
			{
				Entities.Remove(item);

				unitOfWork.Commit();
			}
		}

		public IEnumerable<T> All()
		{
			using (var unitOfWork = UnitOfWorkManager.NewUnitOfWork())
			{
				return Entities.AsQueryable();
			}
		}

		public int Count()
		{
			using (var unitOfWork = UnitOfWorkManager.NewUnitOfWork())
			{
				return Entities.Count();
			}
		}
	}
}
