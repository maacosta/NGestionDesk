using NGestionDesk.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGestionDesk.Common.Entity
{
    [Serializable]
    public class MateriaPrima : IEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Unidad Unidad { get; set; }
    }
}
