using NGestionDesk.Common.Entity;
using NGestionDesk.Dal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGestionDesk.Dal
{
    public class CompraDal : GenericDal<Compra>
    {
        public CompraDal(int aniomes)
            : base(aniomes)
        {
        }
    }
}
