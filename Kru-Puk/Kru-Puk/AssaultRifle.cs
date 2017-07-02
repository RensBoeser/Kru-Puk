using Microsoft.Xna.Framework.Graphics;
using System;


namespace Kru_Puk
{
  class AssaultRifle : IWeapon
  {
    private int maxClipAmount;
    private int ammoInClip;
    private int damage;
    private bool reloadable;
    private bool useable;
    private int reloadTimer;
    private int useTimer;
    private Texture2D sprite;
    

    public AssaultRifle( int maxClipAmount, int ammoInClip, int damage, Texture2D sprite)
    {
      this.maxClipAmount = maxClipAmount;
      this.ammoInClip = ammoInClip;
      this.damage = damage;
      this.useable = true;
      this.reloadable = true;
      this.reloadTimer = 0;
      this.useTimer = 0;
      this.sprite = sprite;
    }

    public int Reload(int ammo)
    {
      if (reloadable)
      {
        int amount = maxClipAmount - ammoInClip;

        if (ammo >= amount)
        {
          ammoInClip = maxClipAmount;
          reloadable = false;
          return ammo - amount;
        }
        else if (amount == 0)
        {
          return ammo;
        }
        else
        {
          ammoInClip = ammoInClip + ammo;
          reloadable = false;
          return 0;
        }
      }
      else
      {
        return ammo;
      }
    }

    public void Update(float dt)
    {
      //UPDATE TIMERS FOR THE RELOADING / USING OF WEAPON
      if (!reloadable)
      {
        reloadTimer = reloadTimer + 1;
      }
      if (!useable)
      {
        useTimer = useTimer + 1;
      }

      if (reloadTimer > 60) // 1 second
      {
        reloadable = true;
        reloadTimer = 0;
      }
      if (useTimer > 10)
      {
        useable = true;
        useTimer = 0;
      }

    }
    public bool IsReloading() { return !reloadable; }

    public void Use(Action<int> createBullet)
    {
      if (ammoInClip > 0 && useable && reloadable)
      {
        ammoInClip = ammoInClip - 1;
        createBullet(damage);
        useable = false;
      }
    }

    public int GetAmmo()
    {
      return ammoInClip;
    }

    public Texture2D GetSprite()
    {
      return sprite;
    }
  }
}
