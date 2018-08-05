using System;
using System.Data.Entity;

namespace DataAccess.Infrastructure
{
    public interface IUnitOfWorkManager : IDisposable
    {
        IUnitOfWork NewUnitOfWork();		
    }

    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private bool _isDisposed;

        private readonly UnityContext _context;

        public UnitOfWorkManager(IUnityContext context)
        {
            Database.SetInitializer<UnityContext>(null);
            _context = context as UnityContext;
        }

        public IUnitOfWork NewUnitOfWork()
        {
            return new UnitOfWork(_context);
        }

		public void Dispose()
		{
			if (!_isDisposed)
			{
				_context.Dispose();
				_isDisposed = true;
			}
		}

		public virtual void Dispose(bool disposing)
		{
			if (!_isDisposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			_isDisposed = true;
		}
	}
}
