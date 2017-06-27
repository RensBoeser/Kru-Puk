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
    bool Intersect(Rectangle rectangle);
    void AddEntity(Level level);
    void RemoveEntity();
    void TakeDamage(int damage);
    void DoDamage(IEntity entity);
    void SetFollowingObject(IEntity entity);
    Point getPosition();
  }
}
