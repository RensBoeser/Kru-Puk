using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kru_Puk
{
  public interface IWeapon : IUpdateable
  {
    void Use(Action<int> createBullet);
    int Reload(int Ammo);
    int GetAmmo();
    Texture2D GetSprite();
  }
}
