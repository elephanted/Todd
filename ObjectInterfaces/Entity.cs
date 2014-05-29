using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todd.ObjectInterfaces;

namespace Todd.ObjectInterfaces
{
    public abstract class Entity : IObjectWithState
    {
        [NotMapped]
        public State State { get; set; }
        [NotMapped]
        public int Id { get; set; }

    }
}
