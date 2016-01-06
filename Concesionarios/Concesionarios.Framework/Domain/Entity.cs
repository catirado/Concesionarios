using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Framework.Domain
{
    //http://stackoverflow.com/questions/7047662/why-does-dbset-add-work-so-slow
    public abstract class Entity
    {
        public int Id { get; private set; }

        public bool IsTransient()
        {
            return this.Id == 0;
        }

        public void ChangeCurrentIdentity(int id)
        {
            if (id != 0)
                this.Id = id;
        }
    }
}
