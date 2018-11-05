using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Estetica.Domain
{
    public class Entity : IEntity
    {
        [Key]
        private Guid id = Guid.NewGuid();
        
        public virtual Guid Id
        {
            get
            {
                return id;
            }
            protected set
            {
                id = value;
            }
        }
    }
}
