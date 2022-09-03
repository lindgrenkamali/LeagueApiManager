using Library.Models.RiotDevPortal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enum
{
    public class ServerEnum
    {
        public static Server Get(int key)
        {
            return (Server)key;
        }
    }
}
