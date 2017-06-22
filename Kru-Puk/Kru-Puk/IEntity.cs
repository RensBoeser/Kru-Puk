﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
    interface IEntity : IUpdateable, IDrawable
    {
        void Intersect(int x, int y, int w, int h);
        void AddEntity();
        void RemoveEntity();
    }
}
