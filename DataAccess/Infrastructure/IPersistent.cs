using System.Collections.Generic;

namespace DataAccess.Infrastructure
{
	public interface IPersistent<T> where T : class
    {
        T Create(T item);

        T Read(object id);

        void Update(T item);

        void Delete(T item);

        IEnumerable<T> All();

		int Count();
    }
}
