using NGestionDesk.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGestionDesk.Common.Entity
{
    public class Entidad : IEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
