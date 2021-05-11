using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ludo_Web.DataAccess
{
    interface ILudoRepository
    {
        IQueryable<Player>
    }
}
