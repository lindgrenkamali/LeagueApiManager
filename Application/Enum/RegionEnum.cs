﻿using Library.Models.RiotDevPortal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enum
{
    public sealed class RegionEnum
    {
        public static Region Get(int value)
        {
            return (Region)value;
        }
    }
}
