using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Kru_Puk
{
    class AssaultRifle : IWeapon //TODO InterfaceNotImplemented
    {
        private int MaxClipAmount;
        private int ClipAmount;
        private int AmmoInClip;
        private Projectile projectile;

        AssaultRifle(int MaxClipAmount, int ClipAmount, int AmmoInClip, Projectile projectile)
        {
            this.MaxClipAmount = MaxClipAmount;
            this.ClipAmount = ClipAmount;
            this.AmmoInClip = AmmoInClip;
            this.projectile = projectile;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            throw new NotImplementedException();
        }

        public void Reload(int AmmoInClip)
        {
            AmmoInClip = 30;
            ClipAmount = ClipAmount - 1;
        }

        public void Update(float dt)
        {
            throw new NotImplementedException();
        }

        public void Use()
        {
            if (AmmoInClip > 0)
            {
                AmmoInClip = AmmoInClip - 1;
                //TODO Create new projectile
            }

            else if (AmmoInClip <= 0 && ClipAmount > 0)
            {
                this.Reload(AmmoInClip);
            }
        }
    }
}
