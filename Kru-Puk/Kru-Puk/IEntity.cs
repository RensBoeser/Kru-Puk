﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Kru_Puk
{
  interface IEntity : IUpdateable, IDrawable
  {
<<<<<<< HEAD
    bool Intersect(Rectangle rectangle);
=======
    bool Intersect(int x, int y, int w, int h);
>>>>>>> origin/master
    void AddEntity();
    void RemoveEntity();
    void TakeDamage(int damage);
    void DoDamage();
    Point getPosition();
  }
}
