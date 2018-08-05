using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace DataAccess.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly UnityContext _context;
        private readonly IDbTransaction _transaction;
        private readonly ObjectContext _objectContext;

        public UnitOfWork(IUnityContext context)
        {
			this._context = context as UnityContext ?? new UnityContext();

			this._objectContext = ((IObjectContextAdapter)this._context).ObjectContext;

            if (this._objectContext.Connection.State != ConnectionState.Open)
            {
				this._objectContext.Connection.Open();
				this._transaction = _objectContext.Connection.BeginTransaction();
            }
        }

        public void Commit()
        {
            try
            {
                this._context.SaveChanges();
                this._transaction.Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

        private void Rollback()
        {
            this._transaction.Rollback();

            foreach (var entry in this._context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        public void Dispose()
        {			
			if (this._objectContext.Connection.State == ConnectionState.Open)
				this._objectContext.Connection.Close();
        }
    }
}
