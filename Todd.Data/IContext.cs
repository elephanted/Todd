using System;

namespace Todd.Data
{
    public interface IContext : IDisposable
    {
        int SaveChanges();
        void SetModified(object entity);
        void SetAdd(object entity);
    }
}
