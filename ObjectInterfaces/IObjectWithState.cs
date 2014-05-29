using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todd.ObjectInterfaces
{
    public interface IObjectWithState
    {
        State State { get; set; }
        int Id { set; }
    }
    public enum State
    {
        Added,
        Unchanged,
        Modified,
        Deleted
    }
}
