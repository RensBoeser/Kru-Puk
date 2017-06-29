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
    private int ammoInClip;
    private int damage;
    

    public AssaultRifle( int maxClipAmount, int ammoInClip, int damage)
    {
      this.maxClipAmount = maxClipAmount;
      this.ammoInClip = ammoInClip;
      this.damage = damage;
    }

    public int Reload(int ammo)
    {
      int amount = maxClipAmount - ammoInClip;
      
      if (ammo >= amount)
      {
        ammoInClip = maxClipAmount;
        return ammo - amount;
      }
      else if(amount == 0)
      {
        return ammo;
      }
      else
      {
        ammoInClip = ammoInClip + ammo;
        return 0;
      }
    }

    public void Update(float dt)
    {
      throw new NotImplementedException();
      //UPDATE TIMERS FOR THE RELOADING / USING OF WEAPON
    }

    public void Use(Action<int> createBullet)
    {
      if (ammoInClip > 0)
      {
        ammoInClip = ammoInClip - 1;
        createBullet(damage);
      }

      else if (ammoInClip <= 0)
      {
        this.Reload(ammoInClip);
      }
    }
  }
}
