using System;
using System.Data.Entity;

namespace Todd.Data
{
    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }
        protected BaseContext()  : base("name=ToddEntities")
        { 
        
        }
    }
}
