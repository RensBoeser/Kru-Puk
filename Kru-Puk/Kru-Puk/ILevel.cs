﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Kru_Puk
{
    interface ILevel : IUpdateable , IDrawable
    {
        string GetLevelTime(); //Day/Night
    }
}
