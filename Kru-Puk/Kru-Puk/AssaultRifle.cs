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
    private int damage;
    

    public AssaultRifle( int clipAmount, int ammoInClip, int damage)
    {
      this.clipAmount = clipAmount;
      this.ammoInClip = ammoInClip;
      this.damage = damage;
    }

    public void Draw(SpriteBatch spritebatch)
    {
      throw new NotImplementedException();
    }

    public void Reload(int ammoInClip)
    {
      ammoInClip = clipAmount;
      
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
        
      }

      else if (ammoInClip <= 0)
      {
        this.Reload(ammoInClip);
      }
    }
  }
}
