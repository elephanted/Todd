using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todd.Data
{
    public class UnitOfWorkTodd
    {
        private readonly ToddEntities _context;

        public UnitOfWorkTodd()
        {
            _context = new ToddEntities();
        }

        public UnitOfWorkTodd(ToddEntities context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        internal ToddEntities Context
        {
            get { return _context; }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
