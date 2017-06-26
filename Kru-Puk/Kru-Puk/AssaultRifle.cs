using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Kru_Puk
{
  class AssaultRifle : IWeapon
  {
    private int maxClipAmount;
    private int clipAmount;
    private int ammoInClip;
    private Projectile projectile;
    private int damage;

    AssaultRifle(int maxClipAmount, int clipAmount, int ammoInClip, Projectile projectile, int damage)
    {
      this.maxClipAmount = maxClipAmount;
      this.clipAmount = clipAmount;
      this.ammoInClip = ammoInClip;
      this.projectile = projectile;
      this.damage = damage;
    }

    public void Draw(SpriteBatch spritebatch)
    {
      throw new NotImplementedException();
    }

    public void Reload(int ammoInClip)
    {
      ammoInClip = 30;
      clipAmount = clipAmount - 1;
    }

    public void Update(float dt)
    {
      throw new NotImplementedException();
    }

    public void Use()
    {
      if (ammoInClip > 0)
      {
        ammoInClip = ammoInClip - 1;
        //TODO Create new projectile
      }

      else if (ammoInClip <= 0 && clipAmount > 0)
      {
        this.Reload(ammoInClip);
      }
    }
  }
}
