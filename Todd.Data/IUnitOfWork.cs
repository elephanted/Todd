using System;
using System.Data.Entity;

namespace Todd.Data
{
    public interface IUnitOfWork:IDisposable
    {
        int Save();
        IContext Context { get; }
    }
}
