﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = System.Drawing.Point;

namespace Krohonde
{
    public class Food : Resource
    {
        public Food (Point loc, int val) : base (loc, val) { }
    }
}
